using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Entities
{
    /// <summary>
    /// Lớp cơ sở cho các thực thể
    /// </summary>
    /// CreatedBy: PTHIEU (30/07/2021)
    public class BaseEntity
    {
        #region Properties

        /// <summary>
        /// Thời điểm tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Thời điểm cập nhật
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Người cập nhật
        /// </summary>
        public string ModifiedBy { get; set; }
        #endregion
    }
}
