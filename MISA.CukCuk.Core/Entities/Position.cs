using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Entities
{
    /// <summary>
    /// Thông tin chức vụ
    /// </summary>
    /// CreatedBy: PTHIEU (30-07-2021)
    public class Position: BaseEntity
    {
        #region Properties
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid PositionId { get; set; }

        /// <summary>
        /// Mã chức vụ
        /// </summary>
        [MISARequired]
        [MISAUnique]
        [MISADisplayName("Mã vị trí/chức vụ")]
        public string PositionCode { get; set; }

        /// <summary>
        /// Tên chức vụ
        /// </summary>
        [MISARequired]
        [MISAUnique]
        [MISADisplayName("Tên vị trí/chức vụ")]
        public string PositionName { get; set; }

        /// <summary>
        /// Mô tả chức vụ
        /// </summary>
        public string Description { get; set; }
        #endregion
    }
}
