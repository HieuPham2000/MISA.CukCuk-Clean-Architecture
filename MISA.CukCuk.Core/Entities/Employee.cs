using MISA.CukCuk.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Entities
{
    /// <summary>
    /// Thông tin nhân viên
    /// </summary>
    /// CreatedBy: PTHIEU (21/07/2021)
    public class Employee: BaseEntity
    {
        #region Properties

        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Tên
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Họ
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Họ và tên
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Giới tính (đại diện bằng số nguyên)
        /// </summary>
        public Gender? Gender { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Địa chỉ email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Số CMND/Căn cước công dân
        /// </summary>
        public string IdentityNumber { get; set; }

        /// <summary>
        /// Thời điểm cấp CMND/CCCD
        /// </summary>
        public DateTime? IdentityDate { get; set; }

        /// <summary>
        /// Nơi cấp CMND/CCCD
        /// </summary>
        public string IdentityPlace { get; set; }

        /// <summary>
        /// Thời điểm gia nhập công ty
        /// </summary>
        public DateTime? JoinDate { get; set; }

        /// <summary>
        /// Tình trạng hôn nhân (đại diện bằng số nguyên)
        /// </summary>
        public int? MaritalStatus { get; set; }

        /// <summary>
        /// Trình độ học vấn (đại diện bằng số nguyên)
        /// </summary>
        public int? EducationalBackground { get; set; }

        /// <summary>
        /// Khóa/id bằng cấp
        /// </summary>
        //public Guid? QualificationId { get; set; }

        /// <summary>
        /// Khóa/id phòng ban
        /// </summary>
        //public Guid? DepartmentId { get; set; }

        /// <summary>
        /// Khóa/id chức vụ
        /// </summary>
        //public Guid? PositionId { get; set; }

        /// <summary>
        /// Trạng thái công việc (đại diện bằng số nguyên)
        /// </summary>
        public int? WorkStatus { get; set; }

        /// <summary>
        /// Mã số thuế thu nhập cá nhân
        /// </summary>
        public string PersonalTaxCode { get; set; }

        /// <summary>
        /// Mức lương cơ bản
        /// </summary>
        public double? Salary { get; set; }

        /// <summary>
        /// Mã chức vụ
        /// </summary>
        public string PositionCode { get; set; }

        /// <summary>
        /// Tên chức vụ
        /// </summary>
        public string PositionName { get; set; }

        /// <summary>
        /// Mã phòng ban
        /// </summary>
        public string  DepartmentCode { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Tên bằng cấp
        /// </summary>
        public string QualificationName { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public string GenderName { get; set; }

        /// <summary>
        /// Trình độ học vấn
        /// </summary>
        public string EducationalBackgroundName { get; set; }

        /// <summary>
        /// Trạng thái hôn nhân
        /// </summary>
        public string MaritalStatusName { get; set; }

        #endregion
    }
}
