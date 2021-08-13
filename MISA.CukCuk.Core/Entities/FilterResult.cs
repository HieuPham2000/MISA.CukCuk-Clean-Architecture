using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Entities
{
    /// <summary>
    /// Kết quả lọc/phân trang dữ liệu
    /// </summary>
    /// <typeparam name="MISAEntity">Đối tượng thực thể</typeparam>
    /// CreatedBy: PTHIEU (02/08/2021)
    public class FilterResult<MISAEntity>
    {
        #region Properties

        /// <summary>
        /// Tổng số bản ghi trả về
        /// </summary>
        public int? TotalRecords { get; set; }

        /// <summary>
        /// Tổng số trang
        /// </summary>
        public int? TotalPages { get; set; }

        /// <summary>
        /// Danh sách bản ghi trả về
        /// </summary>
        public IEnumerable<MISAEntity> Data { get; set; }

        #endregion
    }
}
