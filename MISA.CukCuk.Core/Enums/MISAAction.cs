using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Enums
{
    /// <summary>
    /// Kiểu hành động
    /// </summary>
    /// CreatedBy: PTHIEU (04/08/2021)
    public enum MISAAction
    {
        /// <summary>
        /// Hành động lấy tất cả dữ liệu
        /// </summary>
        GetAll = 0,

        /// <summary>
        /// Hành động lấy dữ liệu 
        /// </summary>
        GetById = 1,

        /// <summary>
        /// Hành động thêm dữ liệu mới
        /// </summary>
        Insert = 2,

        /// <summary>
        /// Hành động cập nhật/chỉnh sửa dữ liệu
        /// </summary>
        Update = 3,

        /// <summary>
        /// Hành động xóa dữ liệu
        /// </summary>
        Delete = 4
    }
}
