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
    public class EmployeeService : IEmployeeService
    {
        #region Fields

        ServiceResult _serviceResult;
        IEmployeeRepository _employeeRepository;

        #endregion

        #region Constructors

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _serviceResult = new ServiceResult();
    }
        #endregion

        #region Methods

        /// <summary>
        /// Xử lý nghiệp vụ khi thêm mới nhân viên
        /// </summary>
        /// <param name="employee">Đối tượng nhân viên</param>
        /// <returns>Kết quả thực hiện service</returns>
        /// CreatedBy: PTHIEU (29-07-2021)
        public ServiceResult Add(Employee employee)
        {
            // Validate dữ liệu:
            // 1. Check đã có thông tin mã nhân viên hay chưa?:
            if (string.IsNullOrEmpty(employee.EmployeeCode))
            {
                _serviceResult.IsSuccess = false;
                _serviceResult.UserMsg = Properties.Resources.ValidateError_EmployeeCodeEmpty;
                _serviceResult.ErrorCode = MISAErrorCode.ValidateRequiredErrorCode;
                return _serviceResult;
            }

            // 2. Check mã nhân viên có trùng hay không? - Không được phép trùng.
            if (_employeeRepository.CheckDuplicateEmployeeCode(employee.EmployeeCode) == true)
            {
                _serviceResult.IsSuccess = false;
                _serviceResult.UserMsg = Properties.Resources.ValidateError_EmployeeCodeDuplicate;
                _serviceResult.ErrorCode = MISAErrorCode.ValidateUniqueErrorCode;
                return _serviceResult;
            }

            // 3. Check email có đúng định dạng hay không?


            _serviceResult.Data = _employeeRepository.Add(employee);
            return _serviceResult;
        }


        /// <summary>
        /// Xử lý nghiệp vụ khi cập nhật thông tin nhân viên
        /// </summary>
        /// <param name="employee">Đối tượng nhân viên</param>
        /// <returns>Kết quả thực hiện service</returns>
        /// CreatedBy: PTHIEU (29-07-2021)
        public ServiceResult Update(Employee employee)
        {
            // Validate dữ liệu:
            // 1. Check đã có thông tin mã nhân viên hay chưa?:
            if (string.IsNullOrEmpty(employee.EmployeeCode))
            {
                _serviceResult.IsSuccess = false;
                _serviceResult.UserMsg = Properties.Resources.ValidateError_EmployeeCodeEmpty;
                _serviceResult.ErrorCode = MISAErrorCode.ValidateRequiredErrorCode;
                return _serviceResult;
            }

            // 2. Check mã nhân viên có trùng hay không? - Không được phép trùng. (trừ TH trùng mã cũ)
            if (_employeeRepository.CheckDuplicateEmployeeCode(employee.EmployeeCode, employee.EmployeeId.ToString()) == true)
            {
                _serviceResult.IsSuccess = false;
                _serviceResult.UserMsg = Properties.Resources.ValidateError_EmployeeCodeDuplicate;
                _serviceResult.ErrorCode = MISAErrorCode.ValidateUniqueErrorCode;
                return _serviceResult;
            }

            // 3. Check email có đúng định dạng hay không?


            _serviceResult.Data = _employeeRepository.Update(employee);
            return _serviceResult;
        }

        #endregion
    }
}
