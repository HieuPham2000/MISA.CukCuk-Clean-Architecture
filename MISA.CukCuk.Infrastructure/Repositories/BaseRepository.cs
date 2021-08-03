using Dapper;
using MISA.CukCuk.Core.Interfaces.Infrastructure;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Infrastructure.Repositories
{
    public class BaseRepository<MISAEntity>: IBaseRepository<MISAEntity> where MISAEntity: class
    {
        #region Fields

        /// <summary>
        /// Thông tin về kết nối
        /// </summary>
        string _connectionString;

        /// <summary>
        /// Tên lớp entity
        /// </summary>
        string _entityClassName;

        /// <summary>
        /// Kết nối tới cơ sở dữ liệu
        /// </summary>
        protected IDbConnection DbConnection;

        #endregion

        #region Constructor
        public BaseRepository()
        {
            // Khai báo thông tin kết nối:
            _connectionString = "" +
                "Host=47.241.69.179;" +
                "Port=3306;" +
                "Database=MISA.CukCuk_Demo_NVMANH;" +
                "User Id=dev;" +
                "Password=12345678";

            // Khởi tạo kết nối:
            DbConnection = new MySqlConnection(_connectionString);

            // Lấy ra tên lớp entity
            _entityClassName = typeof(MISAEntity).Name;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Lấy ra danh sách tất cả đối tượng
        /// </summary>
        /// <returns>Danh sách đối tượng (List object)</returns>
        /// CreatedBy: PTHIEU (30-07-2021)
        public List<MISAEntity> GetAll()
        {

            // Khai báo lệnh sql
            var sqlCommand = $"SELECT * FROM {_entityClassName}";

            // Thực hiện truy vấn dữ liệu với Dapper
            var entities = DbConnection.Query<MISAEntity>(sqlCommand).ToList();

            // Trả về kết quả
            return entities;
        }

        /// <summary>
        /// Lấy thông tin đối tượng theo khóa chính (id)
        /// </summary>
        /// <param name="entityId">Khóa chính (id)</param>
        /// <returns>Đối tượng</returns>
        /// CreatedBy: PTHIEU (30-07-2021)
        public MISAEntity GetById(Guid entityId)
        {
            // Khai báo lệnh sql
            var sqlCommand = $"SELECT * FROM {_entityClassName} WHERE {_entityClassName}Id = @{_entityClassName}Id";
            var parameters = new DynamicParameters();
            parameters.Add($"@{_entityClassName}Id", entityId);

            // Thực hiện truy vấn dữ liệu với Dapper
            var entity = DbConnection.QueryFirstOrDefault<MISAEntity>(sqlCommand, param: parameters);

            return entity;
        }

        /// <summary>
        /// Thêm đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng cần thêm</param>
        /// <returns>Số bản ghi được thêm</returns>
        /// CreatedBy: PTHIEU (2/8/2021)
        public int Add(MISAEntity entity)
        {
            var properties = entity.GetType().GetProperties();
            var columns = string.Empty;
            var values = string.Empty;

            DynamicParameters parameters = new DynamicParameters();

            foreach(var prop in properties)
            {
                var propName = prop.Name;
                if(propName.ToLower() == $"{_entityClassName}Id".ToLower() && (prop.PropertyType == typeof(Guid) || prop.PropertyType == typeof(Guid?)))
                {
                    prop.SetValue(entity, Guid.NewGuid());
                }

                var propValue = prop.GetValue(entity);

                columns = $"{columns} {propName},";
                values = $"{values} @{propName},";
                parameters.Add($"@{propName}", propValue);
            }

            columns = columns.Remove(columns.Length - 1, 1);
            values = values.Remove(values.Length - 1, 1);

            var sqlCommand = $"INSERT INTO {_entityClassName}({columns}) VALUES ({values});";
            var rowAffects = DbConnection.Execute(sqlCommand, param: parameters, commandType: CommandType.Text);


            return rowAffects;
        }

        /// <summary>
        /// Chỉnh sửa thông tin đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng cần cập nhật thông tin</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: PTHIEU (2/8/2021)
        public int Update(MISAEntity entity)
        {
            var properties = entity.GetType().GetProperties();
            var values = string.Empty;

            DynamicParameters parameters = new DynamicParameters();
            //parameters.Add($"@{_entityClassName}Id", entityId);
            foreach (var prop in properties)
            {
                var propName = prop.Name;
                var propValue = prop.GetValue(entity);

                //if (propName.ToLower() == $"{_entityClassName}Id".ToLower())
                //{
                //    continue;
                //}

                values = $"{values} {propName} = @{propName},";
                parameters.Add($"@{propName}", propValue);
            }

            values = values.Remove(values.Length - 1, 1);

            var sqlCommand = $"UPDATE {_entityClassName} SET {values} WHERE {_entityClassName}Id = @{_entityClassName}Id;";
            var rowAffects = DbConnection.Execute(sqlCommand, param: parameters, commandType: CommandType.Text);


            return rowAffects;
        }

        /// <summary>
        /// Xóa đối tượng dựa theo khóa chính
        /// </summary>
        /// <param name="entityId">Khóa chính</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        public int Delete(Guid entityId)
        {
            // Khai báo lệnh sql
            var sqlCommand = $"DELETE FROM {_entityClassName} WHERE {_entityClassName}Id = @{_entityClassName}Id";
            var parameters = new DynamicParameters();
            parameters.Add($"@{_entityClassName}Id", entityId);

            // Thực hiện câu lệnh sql
            var rowAffected = DbConnection.Execute(sqlCommand, param: parameters);

            return rowAffected;
        }
        #endregion
    }
}
