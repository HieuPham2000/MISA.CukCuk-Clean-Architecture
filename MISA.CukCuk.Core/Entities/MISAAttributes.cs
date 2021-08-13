using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Entities
{
    /// <summary>
    /// Thuộc tính xác định tên hiển thị của Property
    /// </summary>
    /// CreatedBy: PTHIEU (04/08/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class MISADisplayName : Attribute
    {
        public string DisplayName = string.Empty;

        public MISADisplayName(string displayName)
        {
            DisplayName = displayName;
        }
    }

    /// <summary>
    /// Thuộc tính xác định Property là trường bắt buộc (không được để trống)
    /// </summary>
    /// CreatedBy: PTHIEU (04/08/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class MISARequired : Attribute
    {
    }

    /// <summary>
    /// Thuộc tính xác định Property là trường duy nhất (không được phép trùng)
    /// </summary>
    /// CreatedBy: PTHIEU (04/08/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class MISAUnique : Attribute
    {
    }

    /// <summary>
    /// Thuộc tính xác định Property là trường email
    /// </summary>
    /// CreatedBy: PTHIEU (04/08/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class MISAEmail : Attribute
    {
    }

    /// <summary>
    /// Thuộc tính xác định Property là trường số điện thoại
    /// </summary>
    /// CreatedBy: PTHIEU (04/08/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class MISAPhoneNumber : Attribute
    {
    }

    /// <summary>
    /// Thuộc tính xác định Property là trường số (chỉ chấp nhận chữ số)
    /// </summary>
    /// CreatedBy: PTHIEU (04/08/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class MISANumber : Attribute
    {
    }

    /// <summary>
    /// Thuộc tính xác định độ dài tối đa
    /// </summary>
    /// CreatedBy: PTHIEU (04/08/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class MISAMaxLength : Attribute
    {
        public int MaxLength = 0;

        public MISAMaxLength(int maxLength)
        {
            MaxLength = maxLength;
        }
    }


}
