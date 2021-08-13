using MISA.CukCuk.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Interfaces.Service
{
    /// <summary>
    /// Interface quy định 1 số thao tác lấy dữ liệu riêng của Employee
    /// </summary>
    /// CreatedBy: PTHIEU (02/08/2021)
    public interface IEmployeeService: IBaseService<Employee>
    {
        /// <summary>
        /// Service xử lý khi lấy danh sách nhân viên theo các tiêu chí (lọc)
        /// </summary>
        /// <param name="employeeFilter">Thông tin tìm kiếm</param>
        /// <param name="departmentId">Mã phòng ban</param>
        /// <param name="positionId">Mã vị trí/chức vụ</param>
        /// <param name="pageIndex">Chỉ số của bản ghi đầu tiên muốn lấy</param>
        /// <param name="pageSize">Kích thước trang, hay số lượng bản ghi/trang</param>
        /// <returns>Đối tượng ServiceResult chứa kết quả thực hiện</returns>
        /// CreatedBy: PTHIEU (04/08/2021)
        ServiceResult GetEmployeeByFilter(string employeeFilter, Guid? departmentId, Guid? positionId, int pageIndex, int pageSize);

        /// <summary>
        /// Service xử lý khi lấy mã nhân viên mới
        /// </summary>
        /// <returns>Đối tượng ServiceResult chứa kết quả thực hiện</returns>
        /// CreatedBy: PTHIEU (04/08/2021)
        ServiceResult GetNewEmployeeCode();
    }
}
