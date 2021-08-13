using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySqlConnector;
using System.Data;
using MISA.CukCuk.Core.Interfaces.Service;
using MISA.CukCuk.Core.Interfaces.Infrastructure;
using MISA.CukCuk.Core.Entities;

namespace MISA.CukCuk.Api.Controllers
{
    /// <summary>
    /// Lớp controller cung cấp api thao tác với dữ liệu Nhân viên (Employee)
    /// </summary>
    /// CreatedBy: PTHIEU (30/07/2021)
    public class EmployeesController : BaseEntitiesController<Employee>
    {
        #region Fields

        IEmployeeService _employeeService;

        #endregion

        #region Constructors
        public EmployeesController(IEmployeeService employeeService) : base(employeeService)
        {
            _employeeService = employeeService;
        }
        #endregion

        #region Methods

        /// <summary>
        /// API lấy ra mã nhân viên mới
        /// </summary>
        /// <returns>
        /// - 200: lấy thành công, hiển thị mã mới
        /// - 204: không có dữ liệu
        /// - 500: xảy ra exception
        /// </returns>
        /// CreatedBy: PTHIEU (2/8/2021)
        [HttpGet("NewEmployeeCode")]
        public IActionResult GetNewEmployeeCode()
        {
            try
            {
                var newEmployeeCode = (string)_employeeService.GetNewEmployeeCode().Data;

                if(string.IsNullOrEmpty(newEmployeeCode))
                {
                    return NoContent();
                }
                return Ok(newEmployeeCode);
            }
            catch (Exception e)
            {
                return StatusCode(500, new ServiceResult(e));
            }
        }


        /// <summary>
        /// API lấy ra danh sách nhân viên theo tiêu chí (lọc)
        /// </summary>
        /// <param name="employeeFilter">Thông tin tìm kiếm</param>
        /// <param name="departmentId">Mã phòng ban</param>
        /// <param name="positionId">Mã vị trí/chức vụ</param>
        /// <param name="pageIndex">Chỉ số của bản ghi đầu tiên muốn lấy</param>
        /// <param name="pageSize">Kích thước trang, hay số lượng bản ghi/trang</param>
        /// <returns>
        /// - 200: lấy thành công, hiển thị danh sách 
        /// - 204: không có dữ liệu
        /// - 400: Có lỗi xảy ra (validate thất bại..)
        /// - 500: xảy ra exception
        /// </returns>
        /// CreatedBy: PTHIEU (2/8/2021)
        [HttpGet("EmployeeFilter")]
        public IActionResult GetEmployeeByFilter(string employeeFilter = null, Guid? departmentId = null, Guid? positionId = null, int pageIndex = 0, int pageSize = 0)
        {
            try
            {
                var serviceResult = _employeeService.GetEmployeeByFilter(
                    employeeFilter: employeeFilter,
                    departmentId: departmentId,
                    positionId: positionId,
                    pageIndex: pageIndex,
                    pageSize: pageSize);

                if (serviceResult.IsSuccess == false)
                {
                    return BadRequest(serviceResult);
                }

                return Ok(serviceResult.Data);
            }
            catch (Exception e)
            {
                return StatusCode(500, new ServiceResult(e));
            }
        }


        #endregion

    }
}
