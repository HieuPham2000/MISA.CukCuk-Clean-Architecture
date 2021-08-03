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
    [Route("api/v1/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        #region Fields

        IEmployeeService _employeeService;
        IBaseRepository<Employee> _baseRepository;

        #endregion

        #region Constructors
        public EmployeesController(IEmployeeService employeeService, IBaseRepository<Employee> baseRepository)
        {
            _employeeService = employeeService;
            _baseRepository = baseRepository;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Tạo API lấy thông tin của tất cả nhân viên
        /// </summary>
        /// <returns>
        /// - 200: Truy vấn thành công danh sách nhân viên
        /// - 204: Dữ liệu null
        /// - 500: Xảy ra exception
        /// </returns>
        /// CreatedBy: PTHIEU 21/07/2021
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            try
            {
                var employees = _baseRepository.GetAll();
                return Ok(employees);
            }
            catch (Exception e)
            {
                return StatusCode(500, new ServiceResult(e));
            }

        }


        /// <summary>
        /// Tạo API lấy thông tin của nhân viên cụ thể (thông qua EmployeeId)
        /// </summary>
        /// <param name="employeeId">Khóa chính/id nhân viên</param>
        /// <returns>
        /// - 200: Truy vấn thành công => Trả về thông tin nhân viên tương ứng
        /// - 204: Không có nhân viên tương ứng
        /// - 500: Xảy ra exception
        /// </returns>
        /// CreatedBy: PTHIEU 21/07/2021
        [HttpGet("{employeeId}")]
        public IActionResult GetEmployeeById(Guid employeeId)
        {
            try
            {
                var employee = _baseRepository.GetById(employeeId);
                return Ok(employee);
            }
            catch (Exception e)
            {
                return StatusCode(500, new ServiceResult(e));
            }

        }

        /// <summary>
        /// Tạo API thêm nhân viên mới
        /// </summary>
        /// <param name="employee">Thông tin nhân viên thêm mới</param>
        /// <returns>
        /// - 201: Thêm mới thành công => Hiển thị số bản ghi được thêm
        /// - 204: Không có bản ghi nào được thêm
        /// - 400: Có lỗi xảy ra khi validate dữ liệu
        /// - 500: Lỗi exception
        /// </returns>
        /// CreatedBy: PTHIEU 26/07/2021
        [HttpPost]
        public IActionResult PostEmployee(Employee employee)
        {
            try
            {
                var serviceResult = _employeeService.Add(employee);

                if(serviceResult.IsSuccess == false)
                {
                    return BadRequest(serviceResult);
                }

                var rowAffected = (int)serviceResult.Data;
                if (rowAffected > 0)
                {
                    return StatusCode(201, rowAffected);
                }

                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, new ServiceResult(e));
            }
        }


        /// <summary>
        /// Tạo API thay đổi thông tin nhân viên
        /// </summary>
        /// <param name="employee">Thông tin nhân viên</param>
        /// <returns>
        /// - 200: Thay đổi thành công => Hiển thị số bản ghi thay đổi
        /// - 204: Không có bản ghi nào thay đổi
        /// - 400: Có lỗi xảy ra khi validate dữ liệu
        /// - 500: Lỗi exception
        /// </returns>
        /// CreatedBy: PTHIEU 26/07/2021
        [HttpPut]
        public IActionResult PutEmployee([FromBody] Employee employee)
        {
            try
            {
                var serviceResult = _employeeService.Update(employee);

                if (serviceResult.IsSuccess == false)
                {
                    return BadRequest(serviceResult);
                }

                var rowAffected = (int)serviceResult.Data;
                if (rowAffected > 0)
                {
                    return Ok(rowAffected);
                }

                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, new ServiceResult(e));
            }
        }


        /// <summary>
        /// Tạo API xóa nhân viên
        /// </summary>
        /// <param name="employeeId">Khóa/id nhân viên</param>
        /// <returns>
        /// - 200: Xóa thành công => Hiển thị số bản ghi bị ảnh hưởng
        /// - 204: Không có bản ghi nào bị ảnh hưởng
        /// - 500: Lỗi exception
        /// </returns>
        /// CreatedBy: PTHIEU 26/07/2021
        [HttpDelete("{employeeId}")]
        public IActionResult DeleteEmployee(Guid employeeId)
        {
            try
            {
                var rowAffected = _baseRepository.Delete(employeeId);
                if (rowAffected > 0)
                {
                    return Ok(rowAffected);
                }

                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, new ServiceResult(e));
            }
        }

        #endregion

    }
}
