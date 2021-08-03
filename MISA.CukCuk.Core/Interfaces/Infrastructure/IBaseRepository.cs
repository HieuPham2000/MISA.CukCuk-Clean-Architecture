using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Interfaces.Infrastructure
{
    public interface IBaseRepository<MISAEntity>
    {
        /// <summary>
        /// Lấy ra toàn bộ các thực thể
        /// </summary>
        /// <returns>Danh sách các thực thể</returns>
        /// CreatedBy: PTHIEU (30/07/2021)
        List<MISAEntity> GetAll();

        /// <summary>
        /// Lấy ra đối tượng thực thể theo khóa chính(id)
        /// </summary>
        /// <param name="entityId">Khóa chính</param>
        /// <returns>Đối tượng thực thể</returns>
        /// CreatedBy: PTHIEU (30/07/2021)
        MISAEntity GetById(Guid entityId);

        /// <summary>
        /// Thêm mới đối tượng thực thể
        /// </summary>
        /// <param name="entity">Đối tượng cần thêm mới</param>
        /// <returns>Số bản ghi được thêm</returns>
        /// CreatedBy: PTHIEU (2/8/2021)
        int Add(MISAEntity entity);

        /// <summary>
        /// Chỉnh sửa đối tượng thực thể
        /// </summary>
        /// <param name="entity">Đối tượng cần chỉnh sửa</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: PTHIEU (2/8/2021)
        int Update(MISAEntity entity);

        /// <summary>
        /// Xóa đối tượng thực thể theo khóa chính(id)
        /// </summary>
        /// <param name="entityId">Khóa chính</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: PTHIEU (30/07/2021)
        int Delete(Guid entityId);
    }
}
