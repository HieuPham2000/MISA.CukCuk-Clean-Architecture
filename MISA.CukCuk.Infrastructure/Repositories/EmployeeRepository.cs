using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Infrastructure.Repositories
{
    /// <summary>
    /// Lớp thao tác với CSDL: truy vấn, thêm, sửa, xóa... với dữ liệu Nhân viên (Employee)
    /// </summary>
    /// CreatedBy: PTHIEU (30-07-2021)
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        #region Constructors

        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {

        }
        #endregion

        #region Methods

        /// <summary>
        /// Hàm lấy danh sách nhân viên theo các tiêu chí (lọc)
        /// </summary>
        /// <param name="employeeFilter">Thông tin tìm kiếm</param>
        /// <param name="departmentId">Mã phòng ban</param>
        /// <param name="positionId">Mã vị trí/chức vụ</param>
        /// <param name="pageIndex">Chỉ số của bản ghi đầu tiên muốn lấy</param>
        /// <param name="pageSize">Kích thước trang, hay số lượng bản ghi/trang</param>
        /// <returns>Đối tượng FilterResult chứa kết quả lọc</returns>
        /// CreatedBy: PTHIEU (02/08/2021)
        public FilterResult<Employee> GetEmployeeByFilter(string employeeFilter, Guid? departmentId, Guid? positionId, int pageIndex, int pageSize) 
        {
            // Thiết lập các tham số
            var parameters = new DynamicParameters();
            // Thiết lập các tham số đầu vào
            parameters.Add("EmployeeFilter", employeeFilter);
            parameters.Add("PageIndex", pageIndex);
            parameters.Add("PageSize", pageSize);
            parameters.Add("DepartmentId", departmentId);
            parameters.Add("PositionId", positionId);

            // Kết quả đầu ra
            parameters.Add("TotalRecord", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("TotalPage", dbType: DbType.Int32, direction: ParameterDirection.Output);

            // Lưu kết quả danh sách bản ghi 
            var result = DbConnection.Query<Employee>(
                sql: "Proc_GetEmployeesFilterPaging",
                param: parameters,
                commandType: CommandType.StoredProcedure);

            // Trả về kết quả filter
            return new FilterResult<Employee> {
                TotalPages = parameters.Get<int?>("TotalPage"),
                TotalRecords = parameters.Get<int?>("TotalRecord"),
                Data = result
            };
        }

        /// <summary>
        /// Hàm lấy mã nhân viên mới
        /// </summary>
        /// <returns>Mã nhân viên mới</returns>
        /// CreatedBy: PTHIEU (02/08/2021)
        public string GetNewEmployeeCode()
        {
            return DbConnection.QueryFirstOrDefault<string>(
                sql: "Proc_GetNewEmployeeCode",
                commandType: CommandType.StoredProcedure);
        }
        #endregion


    }
}
