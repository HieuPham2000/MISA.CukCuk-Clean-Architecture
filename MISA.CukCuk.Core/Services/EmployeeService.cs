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
    /// <summary>
    /// Lớp xử lý nghiệp vụ khi thao tác với dữ liệu Nhân viên (Employee)
    /// </summary>
    /// CreatedBy: PTHIEU (02/08/2021) 
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        #region Fields

        IEmployeeRepository _employeeRepository;

        #endregion

        #region Constructors

        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Service xử lý khi lấy danh sách nhân viên theo các tiêu chí (lọc)
        /// </summary>
        /// <param name="employeeFilter">Thông tin tìm kiếm</param>
        /// <param name="departmentId">Mã phòng ban</param>
        /// <param name="positionId">Mã vị trí/chức vụ</param>
        /// <param name="pageIndex">Chỉ số của bản ghi đầu tiên muốn lấy</param>
        /// <param name="pageSize">Kích thước trang, hay số lượng bản ghi/trang</param>
        /// <returns>Đối tượng ServiceResult chứa kết quả thực hiện</returns>
        /// CreatedBy: PTHIEU (04/08/2021)
        public ServiceResult GetEmployeeByFilter(string employeeFilter, Guid? departmentId, Guid? positionId, int pageIndex, int pageSize)
        {
            if(pageIndex < 0 || pageSize < 0)
            {
                ServiceResult.IsSuccess = false;
                ServiceResult.UserMsg = Properties.Resources.GeneralError;
                ServiceResult.DevMsg = Properties.Resources.QueryStringError;
                ServiceResult.ErrorCode = MISAErrorCode.QueryStringError;
                return ServiceResult;
            }

            ServiceResult.IsSuccess = true;
            ServiceResult.Data = _employeeRepository.GetEmployeeByFilter(
                employeeFilter: employeeFilter, 
                departmentId: departmentId, 
                positionId: positionId, 
                pageIndex: pageIndex, 
                pageSize: pageSize);

            return ServiceResult;
        }

        /// <summary>
        /// Service xử lý khi lấy mã nhân viên mới
        /// </summary>
        /// <returns>Đối tượng ServiceResult chứa kết quả thực hiện</returns>
        /// CreatedBy: PTHIEU (04/08/2021)
        public ServiceResult GetNewEmployeeCode()
        {
            ServiceResult.IsSuccess = true;
            ServiceResult.Data = _employeeRepository.GetNewEmployeeCode();
            return ServiceResult;
        }

        #endregion

    }
}
