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
    /// <summary>
    /// Lớp controller cơ sở
    /// </summary>
    /// <typeparam name="MISAEntity">Lớp thực thể</typeparam>
    /// CreatedBy: PTHIEU (2/8/2021)
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseEntitiesController<MISAEntity> : ControllerBase where MISAEntity : class
    {
        #region Fields

        IBaseService<MISAEntity> _baseService;

        #endregion

        #region Constructors

        public BaseEntitiesController(IBaseService<MISAEntity> baseService)
        {
            _baseService = baseService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// API lấy ra danh sách tất cả bản ghi
        /// </summary>
        /// <returns>
        /// - 200: lấy thành công, hiển thị danh sách bản ghi
        /// - 204: không có dữ liệu
        /// - 500: xảy ra exception
        /// </returns>
        /// CreatedBy: PTHIEU (2/8/2021)
        [HttpGet]
        public IActionResult GetAllEntites()
        {
            try
            {
                // Lấy dữ liệu trả về thông qua service
                var entities = _baseService.GetAll().Data;

                return Ok(entities);
            }
            catch (Exception e)
            {
                return StatusCode(500, new ServiceResult(e));
            }
        }

        /// <summary>
        /// API lấy ra đối tượng thực thể theo khóa chính(id)
        /// </summary>
        /// <param name="entityId">Khóa chính(id)</param>
        /// <returns>
        /// - 200: lấy thành công
        /// - 204: không có dữ liệu
        /// - 500: xảy ra exception
        /// </returns>
        /// CreatedBy: PTHIEU (2/8/2021)
        [HttpGet("{entityId}")]
        public IActionResult GetEntityById(Guid entityId)
        {
            try
            {
                // Lấy dữ liệu trả về thông qua service
                var entity = _baseService.GetById(entityId).Data;

                return Ok(entity);
            }
            catch (Exception e)
            {
                return StatusCode(500, new ServiceResult(e));
            }
        }

        /// <summary>
        /// API thêm mới đối tượng thực thể
        /// </summary>
        /// <param name="entity">Đối tượng cần thêm mới</param>
        /// <returns>
        /// - 201: thêm thành công
        /// - 204: không có bản ghi nào được thêm
        /// - 400: thực hiện thất bại do có lỗi khi xử lý nghiệp vụ (validate...)
        /// - 500: xảy ra exception
        /// </returns>
        /// CreatedBy: PTHIEU (2/8/2021)
        [HttpPost]
        public IActionResult PostEntity(MISAEntity entity)
        {
            try
            {
                // Thực hiện service thêm mới
                var serviceResult = _baseService.Insert(entity);

                // Trường hợp thêm mới thất bại (validate thất bại, dữ liệu truyền vào không hợp lệ...)
                if (serviceResult.IsSuccess == false)
                {
                    return BadRequest(serviceResult);
                }

                // Trường hợp thành công
                // => Lấy kết quả: số bản ghi được thêm
                var rowAffects = (int)serviceResult.Data;

                if (rowAffects > 0)
                {
                    return StatusCode(201, rowAffects);
                }

                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, new ServiceResult(e));
            }
        }

        /// <summary>
        /// API chỉnh sửa thông tin đối tượng thực thể
        /// </summary>
        /// <param name="entity">Đối tượng cần cập nhật</param>
        /// <returns>
        /// - 200: chỉnh sửa thành công
        /// - 204: không có bản ghi nào bị ảnh hưởng
        /// - 400: thực hiện thất bại do có lỗi khi xử lý nghiệp vụ (validate...)
        /// - 500: xảy ra exception
        /// </returns>
        /// CreatedBy: PTHIEU (2/8/2021)
        [HttpPut("{entityId}")]
        public IActionResult PutEntity(Guid entityId, MISAEntity entity)
        {
            try
            {
                // Thực hiện service cập nhật/chỉnh sửa
                var serviceResult = _baseService.Update(entityId, entity);

                // Trường hợp thực hiện thất bại (validate thất bại, dữ liệu truyền vào không hợp lệ...)
                if (serviceResult.IsSuccess == false)
                {
                    return BadRequest(serviceResult);
                }

                // Trường hợp thành công
                // => Lấy kết quả: số bản ghi bị ảnh hưởng
                var rowAffects = (int)serviceResult.Data;

                if (rowAffects > 0)
                {
                    return StatusCode(201, rowAffects);
                }

                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, new ServiceResult(e));
            }
        }


        /// <summary>
        /// API xóa đối tượng thực thể theo khóa chính(id)
        /// </summary>
        /// <param name="entityId">Khóa chính(id)</param>
        /// <returns>
        /// - 200: xóa thành công
        /// - 204: không có bản ghi nào bị xóa
        /// - 500: xảy ra exception
        /// </returns>
        /// CreatedBy: PTHIEU (2/8/2021)
        [HttpDelete("{entityId}")]
        public IActionResult DeleteEntity(Guid entityId)
        {
            try
            {
                // Thực hiện service xóa bản ghi
                // => Lấy kết quả: số bản ghi bị ảnh hưởng (bị xóa)
                var rowAffects = (int)_baseService.Delete(entityId).Data;

                if (rowAffects > 0)
                {
                    return Ok(rowAffects);
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
