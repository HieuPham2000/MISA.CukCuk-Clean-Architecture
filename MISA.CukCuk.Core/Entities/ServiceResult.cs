using MISA.CukCuk.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Entities
{
    /// <summary>
    /// Kết quả thực hiện service
    /// </summary>
    /// CreatedBy: PTHIEU (30-07-2021)
    public class ServiceResult
    {
        #region Properties
        /// <summary>
        /// Kết quả thực hiện (trạng thái service): true - thành công, false - lỗi/thất bại
        /// </summary>
        public bool IsSuccess { get; set; } = true;

        /// <summary>
        /// Thông báo dành cho người dùng
        /// </summary>
        public string UserMsg { get; set; }

        /// <summary>
        /// Thông báo dành cho lập trình viên
        /// </summary>
        public string DevMsg { get; set; }

        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Mã lỗi
        /// </summary>
        public string ErrorCode { get; set; }
        #endregion

        #region Constructors

        /// <summary>
        /// Hàm khởi tạo mặc định
        /// </summary>
        /// CreatedBy: PTHIEU (30-07-2021)
        public ServiceResult()
        {
              
        }

        /// <summary>
        /// Hàm khởi tạo trong TH xảy ra exception
        /// </summary>
        /// <param name="e">Ngoại lệ</param>
        /// CreatedBy: PTHIEU (30-07-2021)
        public ServiceResult(Exception e)
        {
            this.IsSuccess = false;
            this.UserMsg = Properties.Resources.ExceptionError;
            this.DevMsg = e.Message;
            this.Data = null;
            this.ErrorCode = MISAErrorCode.ExceptionErrorCode;
        }
        #endregion
    }
}
