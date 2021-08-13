using MISA.CukCuk.Core.Constants;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Enums;
using MISA.CukCuk.Core.Interfaces.Infrastructure;
using MISA.CukCuk.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Services
{
    /// <summary>
    /// Lớp cơ sở cho việc xử lý nghiệp vụ
    /// </summary>
    /// <typeparam name="MISAEntity">Lớp thực thể</typeparam>
    /// CreatedBy: PTHIEU (02/08/2021) 
    public class BaseService<MISAEntity> : IBaseService<MISAEntity> where MISAEntity: class
    {
        #region Fields

        IBaseRepository<MISAEntity> _baseRepository;

        protected ServiceResult ServiceResult;

        #endregion


        #region Constructors

        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            ServiceResult = new ServiceResult();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Service xử lý khi lấy tất cả dữ liệu
        /// </summary>
        /// <returns>Đối tượng ServiceResult chứa kết quả thực hiện</returns>
        /// CreatedBy: PTHIEU (04/08/2021) 
        public ServiceResult GetAll()
        {
            ServiceResult.IsSuccess = true;

            // Thực hiện lấy dữ liệu 
            ServiceResult.Data = _baseRepository.GetAll();

            return ServiceResult;
        }

        /// <summary>
        /// Service xử lý khi lấy dữ liệu theo Khóa chính (id)
        /// </summary>
        /// <param name="entityId">Khóa chính</param>
        /// <returns>Đối tượng ServiceResult chứa kết quả thực hiện</returns>
        /// CreatedBy: PTHIEU (04/08/2021) 
        public ServiceResult GetById(Guid entityId)
        {
            ServiceResult.IsSuccess = true;

            // Thực hiện lấy dữ liệu
            ServiceResult.Data = _baseRepository.GetById(entityId);

            return ServiceResult;
        }

        /// <summary>
        /// Service xử lý khi xóa dữ liệu theo Khóa chính (id)
        /// </summary>
        /// <param name="entityId">Khóa chính</param>
        /// <returns>Đối tượng ServiceResult chứa kết quả thực hiện</returns>
        /// CreatedBy: PTHIEU (04/08/2021) 
        public ServiceResult Delete(Guid entityId)
        {
            ServiceResult.IsSuccess = true;

            // Thực hiện lấy dữ liệu
            ServiceResult.Data = _baseRepository.Delete(entityId);

            return ServiceResult;
        }

        /// <summary>
        /// Service xử lý khi thêm dữ liệu
        /// </summary>
        /// <param name="entity">Đối tượng muốn thêm</param>
        /// <returns>Đối tượng ServiceResult chứa kết quả thực hiện</returns>
        /// CreatedBy: PTHIEU (02/08/2021) 
        public ServiceResult Insert(MISAEntity entity)
        {
            // Validate dữ liệu
            var isValid = ValidateData(entity, MISAAction.Insert);

            // Validate thành công (dữ liệu hợp lệ)
            if(isValid)
            {
                ServiceResult.IsSuccess = true;
                
                // Thêm dữ liệu và lấy kết quả trả về (số bản ghi được thêm)
                ServiceResult.Data = _baseRepository.Insert(entity);
                return ServiceResult;
            }

            // Validate thất bại (dữ liệu không hợp lệ)
            return ServiceResult;
        }

        /// <summary>
        /// Service xử lý khi cập nhật/chỉnh sửa dữ liệu
        /// </summary>
        /// <param name="entityId">Khóa chính</param>
        /// <param name="entity">Đối tượng muốn cập nhật</param>
        /// <returns>Đối tượng ServiceResult chứa kết quả thực hiện</returns>
        /// CreatedBy: PTHIEU (02/08/2021) 
        public ServiceResult Update(Guid entityId, MISAEntity entity)
        {
            var propId = typeof(MISAEntity).GetProperty($"{typeof(MISAEntity).Name}Id");
            propId.SetValue(entity, entityId);

            // Validate dữ liệu
            var isValid = ValidateData(entity, MISAAction.Update);

            // Validate thành công (dữ liệu hợp lệ)
            if (isValid)
            {
                ServiceResult.IsSuccess = true;

                // Cập nhật dữ liệu và lấy kết quả trả về (số bản ghi bị ảnh hưởng)
                ServiceResult.Data = _baseRepository.Update(entity);
                return ServiceResult;
            }

            // Validate thất bại (dữ liệu không hợp lệ)
            return ServiceResult;
        }

        /// <summary>
        /// Validate dữ liệu
        /// </summary>
        /// <param name="entity">Đối tượng thực thể cần validate</param>
        /// <returns>true - validate thành công, false - validate thất bại</returns>
        /// CreatedBy: PTHIEU (04/08/2021)
        private bool ValidateData(MISAEntity entity, MISAAction action)
        {
            // Cờ xác định trạng thái hợp lệ/không hợp lệ của dữ liệu entity
            var isValid = true;

            // Validate chung

            // Lấy ra tất cả thuộc tính
            var properties = typeof(MISAEntity).GetProperties();

            // Kiểm tra từng thuộc tính
            foreach(var prop in properties)
            {
                var propName = prop.Name;
                var propValue = prop.GetValue(entity);
                var propType = prop.GetType();

                // Lấy ra tên hiển thị - nếu có (dùng trong câu thông báo lỗi với người dùng)
                var displayName = string.Empty;
                var hasDisplayName = prop.GetCustomAttributes(typeof(MISADisplayName), true);
                // Kiểm tra nếu prop có attribute MISADisplayName thì:
                if(hasDisplayName.Length > 0)
                {
                    // Lấy ra tên hiển thị
                    displayName = (hasDisplayName[0] as MISADisplayName).DisplayName;
                }

                // Kiểm tra trường bắt buộc
                if ( prop.IsDefined(typeof(MISARequired)) )
                {
                    if((propType == typeof(string) && string.IsNullOrEmpty(propValue.ToString())) || propValue == null)
                    {
                        ServiceResult.IsSuccess = false;
                        ServiceResult.UserMsg = string.Format(Properties.Resources.ValidateRequiredError, displayName);
                        ServiceResult.ErrorCode = MISAErrorCode.ValidateRequiredErrorCode;
                        ServiceResult.Data = propName;
                        return false;
                    }
                }

                // Kiểm tra độ dài tối đa
                if (prop.IsDefined(typeof(MISAMaxLength)))
                {
                    var maxLengthAttr = prop.GetCustomAttributes(typeof(MISAMaxLength), true)[0];
                    var maxLength = (maxLengthAttr as MISAMaxLength).MaxLength;

                    if(propValue.ToString().Trim().Length > maxLength)
                    {
                        ServiceResult.IsSuccess = false;
                        ServiceResult.UserMsg = string.Format(Properties.Resources.ValidateMaxLengthError, displayName, maxLength);
                        ServiceResult.ErrorCode = MISAErrorCode.ValidateMaxLengthErrorCode;
                        ServiceResult.Data = propName;
                        return false;
                    }
                }

                // Kiểm tra định dạng email
                if (prop.IsDefined(typeof(MISAEmail)))
                {
                    var pattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                + "@"
                                + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";

                    if (Regex.IsMatch(propValue.ToString(), pattern) == false)
                    {
                        ServiceResult.IsSuccess = false;
                        ServiceResult.UserMsg = string.Format(Properties.Resources.ValidateFormatError, displayName);
                        ServiceResult.ErrorCode = MISAErrorCode.ValidateFormatErrorCode;
                        ServiceResult.Data = propName;
                        return false;
                    }
                }

                // Kiểm tra chỉ chứa số
                if (prop.IsDefined(typeof(MISANumber)))
                {
                    if (propValue.ToString().All(char.IsDigit))
                    {
                        ServiceResult.IsSuccess = false;
                        ServiceResult.UserMsg = string.Format(Properties.Resources.ValidateFormatError, displayName);
                        ServiceResult.ErrorCode = MISAErrorCode.ValidateFormatErrorCode;
                        ServiceResult.Data = propName;
                        return false;
                    }
                }

                // Kiểm tra định dạng số điện thoại
                if (prop.IsDefined(typeof(MISAPhoneNumber)))
                {
                    var pattern = @"^[+\d]?(?:[\d-.\s()]*)$";

                    if (Regex.IsMatch(propValue.ToString(), pattern) == false)
                    {
                        ServiceResult.IsSuccess = false;
                        ServiceResult.UserMsg = string.Format(Properties.Resources.ValidateFormatError, displayName);
                        ServiceResult.ErrorCode = MISAErrorCode.ValidateFormatErrorCode;
                        ServiceResult.Data = propName;
                        return false;
                    }
                }

                // Kiểm tra trường duy nhất
                if ( prop.IsDefined(typeof(MISAUnique)) )
                {
                    // Cờ xác định trạng thái trùng lặp của giá trị prop
                    var isDuplicate = false;

                    // Dựa trên hành động (là sửa hay thêm mới?)
                    // gọi hàm kiểm tra tương ứng
                    switch(action)
                    {
                        case MISAAction.Insert:
                            isDuplicate = _baseRepository.CheckDuplicate(propName, propValue);
                            break;
                        case MISAAction.Update:
                            isDuplicate = _baseRepository.CheckDuplicateBeforeUpdate(propName, propValue, entity);
                            break;
                    }

                    // Nếu giá trị prop bị trùng
                    if ( isDuplicate )
                    {
                        ServiceResult.IsSuccess = false;
                        ServiceResult.UserMsg = string.Format(Properties.Resources.ValidateUniqueError, displayName);
                        ServiceResult.ErrorCode = MISAErrorCode.ValidateUniqueErrorCode;
                        ServiceResult.Data = propName;
                        return false;
                    }
                }

                
            }
            

            // validate riêng
            isValid = ValidateCustom(entity);

            return isValid;
        }

        /// <summary>
        /// Hàm validate riêng
        /// Cho phép lớp kế thừa ghi đè, tự triển khai (nếu cần)
        /// </summary>
        /// <param name="entity">Đối tượng thực thể cần validae</param>
        /// <returns>true - validate thành công, false - validate thất bại</returns>
        /// CreatedBy: PTHIEU (04/08/2021)
        protected virtual bool ValidateCustom(MISAEntity entity)
        {
            return true;
        }


        #endregion

    }
}
