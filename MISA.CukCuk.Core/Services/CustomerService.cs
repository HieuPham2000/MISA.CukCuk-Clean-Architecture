using MISA.CukCuk.Core.Constants;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Infrastructure;
using MISA.CukCuk.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Services
{
    public class CustomerService : ICustomerService
    {

        #region Fields

        ServiceResult _serviceResult;
        ICustomerRepository _customerRepository;

        #endregion

        #region Contructors

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        #endregion
        /// <summary>
        /// Xử lý nghiệp vụ khi thêm mới khách hàng
        /// </summary>
        /// <param name="customer">Đối tượng khách hàng</param>
        /// <returns>Kết quả thực hiện service</returns>
        /// CreatedBy: PTHIEU (29-07-2021)
        public ServiceResult Add(Customer customer)
        {
            // Validate dữ liệu:
            // 1. Check đã có thông tin mã khách hàng hay chưa?:
            if (string.IsNullOrEmpty(customer.CustomerCode))
            {
                _serviceResult.IsSuccess = false;
                _serviceResult.UserMsg = Properties.Resources.ValidateError_CustomerCodeEmpty;
                _serviceResult.ErrorCode = MISAErrorCode.ValidateRequiredErrorCode;
                return _serviceResult;
            }

            // 2. Check mã khách hàng có trùng hay không? - Không được phép trùng.
            if (_customerRepository.CheckDuplicateCustomerCode(customer.CustomerCode) == true)
            {
                _serviceResult.IsSuccess = false;
                _serviceResult.UserMsg = Properties.Resources.ValidateError_CustomerCodeDuplicate;
                _serviceResult.ErrorCode = MISAErrorCode.ValidateUniqueErrorCode;
                return _serviceResult;
            }

            // 3. Check email có đúng định dạng hay không?


            _serviceResult.Data = _customerRepository.Add(customer);
            return _serviceResult;
        }


        /// <summary>
        /// Xử lý nghiệp vụ khi cập nhật thông tin khách hàng
        /// </summary>
        /// <param name="customer">Đối tượng khách hàng</param>
        /// <returns>Kết quả thực hiện service</returns>
        /// CreatedBy: PTHIEU (29-07-2021)
        public ServiceResult Update(Customer customer)
        {

            // Validate dữ liệu:
            // 1. Check đã có thông tin mã khách hàng hay chưa?:
            if (string.IsNullOrEmpty(customer.CustomerCode))
            {
                _serviceResult.IsSuccess = false;
                _serviceResult.UserMsg = Properties.Resources.ValidateError_CustomerCodeEmpty;
                _serviceResult.ErrorCode = MISAErrorCode.ValidateRequiredErrorCode;
                return _serviceResult;
            }

            // 2. Check mã khách hàng có trùng hay không? - Không được phép trùng. (trừ TH trùng mã cũ)
            if (_customerRepository.CheckDuplicateCustomerCode(customer.CustomerCode, customer.CustomerId.ToString()) == true)
            {
                _serviceResult.IsSuccess = false;
                _serviceResult.UserMsg = Properties.Resources.ValidateError_CustomerCodeDuplicate;
                _serviceResult.ErrorCode = MISAErrorCode.ValidateUniqueErrorCode;
                return _serviceResult;
            }

            // 3. Check email có đúng định dạng hay không?


            _serviceResult.Data = _customerRepository.Update(customer);
            return _serviceResult;
        }
    }
}
