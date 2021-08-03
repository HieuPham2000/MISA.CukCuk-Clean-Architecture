using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Constants
{
    /// <summary>
    /// Chứa các mã lỗi
    /// </summary>
    /// CreatedBy: PTHIEU (30-07-2021)
    public static class MISAErrorCode
    {
        /// <summary>
        /// Mã lỗi khi xảy ra exception
        /// </summary>
        public const string ExceptionErrorCode = "MISA_001";

        /// <summary>
        /// Mã lỗi khi validate trường bắt buộc thất bại
        /// </summary>
        public const string ValidateRequiredErrorCode = "MISA_002";

        /// <summary>
        /// Mã lỗi khi validate trường duy nhất thất bại
        /// </summary>
        public const string ValidateUniqueErrorCode = "MISA_003";
    }
}
