using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Infrastructure;
using MISA.CukCuk.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        #region Fields

        IBaseRepository<Customer> _baseRepository;
        ICustomerService _customerService;

        #endregion

        #region Constructors

        public CustomersController(IBaseRepository<Customer> baseRepository, ICustomerService customerService)
        {
            _baseRepository = baseRepository;
            _customerService = customerService;
        }
        #endregion

        #region Methods

        /// <summary>
        /// API lấy danh sách tất cả khách hàng
        /// </summary>
        /// <returns>
        /// - 200: Lấy thành công danh sách khách hàng
        /// - 204: Dữ liệu null
        /// - 500: Lỗi exception
        /// </returns>
        /// CreatedBy: PTHIEU (29-07-2021)
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            try
            {
                var customers = _baseRepository.GetAll();

                return Ok(customers);
            }
            catch (Exception e)
            {
                return StatusCode(500, new ServiceResult(e));
            }
        }

        /// <summary>
        /// API lấy thông tin khách hàng theo khóa chính/id
        /// </summary>
        /// <param name="customerId">Khóa chính</param>
        /// <returns>
        /// - 200: Lấy thành công thông tin khách hàng tương ứng
        /// - 204: Dữ liệu null
        /// - 500: Lỗi exception
        /// </returns>
        /// CreatedBy: PTHIEU (29-07-2021)
        [HttpGet("{customerId}")]
        public IActionResult GetCustomer(Guid customerId)
        {
            try
            {
                var customer = _baseRepository.GetById(customerId);

                return Ok(customer);
            }
            catch (Exception e)
            {
                return StatusCode(500, new ServiceResult(e));
            }
        }

        /// <summary>
        /// API thêm khách hàng mới
        /// </summary>
        /// <param name="customer">Đối tượng khách hàng</param>
        /// <returns>
        /// - 201: Thêm mới thành công => Hiển thị số bản ghi được thêm
        /// - 204: Không có bản ghi nào được thêm
        /// - 400: Có lỗi xảy ra khi validate dữ liệu
        /// - 500: Lỗi exception
        /// </returns>
        /// CreatedBy: PTHIEU (29-07-2021)
        [HttpPost]
        public IActionResult PostCustomer(Customer customer)
        {
            try
            {
                var serviceResult = _customerService.Add(customer);
                
                if(serviceResult.IsSuccess == false)
                {
                    return BadRequest(serviceResult);
                }

                var rowAffected = (int)serviceResult.Data;
                if(rowAffected > 0)
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
        /// API cập nhật thông tin khách hàng
        /// </summary>
        /// <param name="customer">Đối tượng khách hàng</param>
        /// <returns>
        /// - 200: Thay đổi thành công => Hiển thị số bản ghi thay đổi
        /// - 204: Không có bản ghi nào thay đổi
        /// - 400: Có lỗi xảy ra khi validate dữ liệu
        /// - 500: Lỗi exception
        /// </returns>
        /// CreatedBy: PTHIEU (29-07-2021)
        [HttpPut]
        public IActionResult PuttCustomer(Customer customer)
        {
            try
            {

                var serviceResult = _customerService.Update(customer);

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
        /// Tạo API xóa khách hàng theo khóa chính
        /// </summary>
        /// <param name="customerId">Khóa/id</param>
        /// <returns>
        /// - 200: Xóa thành công => Hiển thị số bản ghi bị ảnh hưởng
        /// - 204: Không có bản ghi nào bị ảnh hưởng
        /// - 500: Lỗi exception
        /// </returns>
        /// CreatedBy: PTHIEU (29/07/2021)
        [HttpDelete("{customerId}")]
        public IActionResult DeleteCustomer(Guid customerId)
        {
            try
            {
                var result = _baseRepository.Delete(customerId);
                if (result > 0)
                {
                    return Ok(result);
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
