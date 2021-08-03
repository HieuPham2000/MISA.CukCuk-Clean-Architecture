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
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        #region Methods
        /// <summary>
        /// Hàm kiểm tra mã khách hàng đã tồn tại hay chưa?
        /// </summary>
        /// <param name="customerCode">Mã khách hàng</param>
        /// <returns>true - đã tồn tại; false - mã chưa tồn tại</returns>
        /// CreatedBy: PTHIEU (29-07-2021)
        public bool CheckDuplicateCustomerCode(string customerCode)
        {
            var isDuplicate = false;

            // Thiết lập tham số:
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CustomerCode", customerCode);

            // Lệnh truy vấn dữ liệu:
            string sqlCommand = "SELECT CustomerCode FROM Customer WHERE CustomerCode = @CustomerCode";

            // Thực hiện truy vấn với Dapper:
            var result = DbConnection.QueryFirstOrDefault(sqlCommand, parameters);

            if (result != null)
            {
                isDuplicate = true;
            }

            return isDuplicate;

        }

        /// <summary>
        /// Hàm kiểm tra mã khách hàng đã tồn tại hay chưa? (trừ TH trùng mã khách hàng cũ)
        /// </summary>
        /// <param name="customerCode">Mã khách hàng</param>
        /// <param name="customerId">Khóa/Id khách hàng đang xét</param>
        /// <returns>true - đã tồn tại; false - mã chưa tồn tại</returns>
        /// CreatedBy: PTHIEU (29-07-2021)
        public bool CheckDuplicateCustomerCode(string customerCode, string customerId)
        {
            // Thiết lập tham số:
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CustomerId", customerId);

            // Lệnh truy vấn dữ liệu:
            string sqlCommand = "SELECT CustomerCode FROM Customer WHERE CustomerId = @CustomerId";

            // Thực hiện truy vấn với Dapper:
            var result = DbConnection.QueryFirstOrDefault(sqlCommand, parameters);

            // Nếu mã khách hàng giống với mã cũ thì không phải duplicate
            if (result != null && customerCode.Equals(result.CustomerCode))
            {
                return false;
            }

            // Còn lại, kiểm tra việc trùng mã khách hàng
            return CheckDuplicateCustomerCode(customerCode);
        }
        #endregion
    }
}
