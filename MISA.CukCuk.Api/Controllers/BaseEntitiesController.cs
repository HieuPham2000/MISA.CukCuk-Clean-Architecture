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
    public class BaseEntitiesController<MISAEntity> : ControllerBase
    {
        #region Fields

        IBaseRepository<MISAEntity> _baseRepository;
        IBaseService<MISAEntity> _baseService;

        #endregion

        #region Constructors

        public BaseEntitiesController(IBaseRepository<MISAEntity> baseRepository, IBaseService<MISAEntity> baseService)
        {
            _baseRepository = baseRepository;
            _baseService = baseService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// API lấy ra danh sách tất cả thực thể
        /// </summary>
        /// <returns>
        /// - 200: lấy thành công, hiển thị danh sách các đối tượng thực thể
        /// - 204: không có dữ liệu
        /// - 500: xảy ra exception
        /// </returns>
        /// CreatedBy: PTHIEU (2/8/2021)
        [HttpGet]
        public IActionResult GetAllEntites()
        {
            try
            {
                var entities = _baseRepository.GetAll();

                if(entities == null || entities.Count() == 0)
                {
                    return NoContent();
                }

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
                var entity = _baseRepository.GetById(entityId);

                if (entity == null)
                {
                    return NoContent();
                }

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
        /// - 500: xảy ra exception
        /// </returns>
        /// CreatedBy: PTHIEU (2/8/2021)
        [HttpPost]
        public IActionResult PostEntity(MISAEntity entity)
        {
            try
            {
                var rowAffects = _baseRepository.Add(entity);
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
        /// - 500: xảy ra exception
        /// </returns>
        /// CreatedBy: PTHIEU (2/8/2021)
        [HttpPut]
        public IActionResult PutEntity(MISAEntity entity)
        {
            try
            {
                var rowAffects = _baseRepository.Update(entity);
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
                var rowAffects = _baseRepository.Delete(entityId);

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
