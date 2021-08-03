using Dapper;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Infrastructure.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        #region Methods

        /// <summary>
        /// Hàm kiểm tra mã nhân viên đã tồn tại hay chưa?
        /// </summary>
        /// <param name="employeeCode">Mã nhân viên</param>
        /// <returns>true - đã tồn tại; false - mã chưa tồn tại</returns>
        /// CreatedBy: PTHIEU (29-07-2021)
        public bool CheckDuplicateEmployeeCode(string employeeCode)
        {
            var isDuplicate = false;

            // Thiết lập tham số:
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@EmployeeCode", employeeCode);

            // Lệnh truy vấn dữ liệu:
            string sqlCommand = "SELECT EmployeeCode FROM Employee WHERE EmployeeCode = @EmployeeCode";

            // Thực hiện truy vấn với Dapper:
            var result = DbConnection.QueryFirstOrDefault(sqlCommand, parameters);

            if (result != null)
            {
                isDuplicate = true;
            }

            return isDuplicate;

        }

        /// <summary>
        /// Hàm kiểm tra mã nhân viên đã tồn tại hay chưa? (trừ TH trùng mã nhân viên cũ)
        /// </summary>
        /// <param name="employeeCode">Mã nhân viên</param>
        /// <param name="employeeId">Khóa/Id nhân viên đang xét</param>
        /// <returns>true - đã tồn tại; false - mã chưa tồn tại</returns>
        /// CreatedBy: PTHIEU (29-07-2021)
        public bool CheckDuplicateEmployeeCode(string employeeCode, string employeeId)
        {
            // Thiết lập tham số:
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@EmployeeId", employeeId);

            // Lệnh truy vấn dữ liệu:
            string sqlCommand = "SELECT EmployeeCode FROM Employee WHERE EmployeeId = @EmployeeId";

            // Thực hiện truy vấn với Dapper:
            var result = DbConnection.QueryFirstOrDefault(sqlCommand, parameters);

            // Nếu mã nhân viên giống với mã cũ thì không phải duplicate
            if (result != null && employeeCode.Equals(result.EmployeeCode))
            {
                return false;
            }

            // Còn lại, kiểm tra việc trùng mã nhân viên
            return CheckDuplicateEmployeeCode(employeeCode);
        }
        #endregion


    }
}
