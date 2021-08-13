using MISA.CukCuk.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Interfaces.Service
{
    /// <summary>
    /// Interface quy định các service xử lý nghiệp vụ khi thao tác dữ liệu
    /// </summary>
    /// <typeparam name="MISAEntity">ớp thực thể</typeparam>
    /// CreatedBy: PTHIEU (02/08/2021)
    public interface IBaseService<MISAEntity> where MISAEntity : class
    {
        /// <summary>
        /// Service xử lý khi lấy tất cả dữ liệu
        /// </summary>
        /// <returns>Đối tượng ServiceResult chứa kết quả thực hiện</returns>
        /// CreatedBy: PTHIEU (04/08/2021) 
        ServiceResult GetAll();

        /// <summary>
        /// Service xử lý khi lấy dữ liệu theo Khóa chính (id)
        /// </summary>
        /// <param name="entityId">Khóa chính</param>
        /// <returns>Đối tượng ServiceResult chứa kết quả thực hiện</returns>
        /// CreatedBy: PTHIEU (04/08/2021) 
        ServiceResult GetById(Guid entityId);

        /// <summary>
        /// Service xử lý khi thêm dữ liệu
        /// </summary>
        /// <param name="entity">Đối tượng muốn thêm</param>
        /// <returns>Đối tượng ServiceResult chứa kết quả thực hiện</returns>
        /// CreatedBy: PTHIEU (02/08/2021) 
        ServiceResult Insert(MISAEntity entity);

        /// <summary>
        /// Service xử lý khi cập nhật/chỉnh sửa dữ liệu
        /// </summary>
        /// <param name="entityId">Khóa chính</param>
        /// <param name="entity">Đối tượng muốn cập nhật</param>
        /// <returns>Đối tượng ServiceResult chứa kết quả thực hiện</returns>
        /// CreatedBy: PTHIEU (02/08/2021) 
        ServiceResult Update(Guid entityId, MISAEntity entity);

        /// <summary>
        /// Service xử lý khi xóa dữ liệu theo Khóa chính (id)
        /// </summary>
        /// <param name="entityId">Khóa chính</param>
        /// <returns>Đối tượng ServiceResult chứa kết quả thực hiện</returns>
        /// CreatedBy: PTHIEU (04/08/2021) 
        ServiceResult Delete(Guid entityId);
    }
}
