using MISA.CukCuk.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Interfaces.Infrastructure
{
    /// <summary>
    /// Interface quy định việc lấy dữ liệu liên quan đến Employee
    /// </summary>
    /// CreatedBy: PTHIEU (30/07/2021)
    public interface IEmployeeRepository: IBaseRepository<Employee>
    {
        /// <summary>
        /// Hàm lấy danh sách nhân viên theo các tiêu chí (lọc)
        /// </summary>
        /// <param name="employeeFilter">Thông tin tìm kiếm</param>
        /// <param name="departmentId">Mã phòng ban</param>
        /// <param name="positionId">Mã vị trí/chức vụ</param>
        /// <param name="pageIndex">Chỉ số của bản ghi đầu tiên muốn lấy</param>
        /// <param name="pageSize">Kích thước trang, hay số lượng bản ghi/trang</param>
        /// <returns>Đối tượng FilterResult chứa kết quả lọc</returns>
        /// CreatedBy: PTHIEU (02/08/2021)
        FilterResult<Employee> GetEmployeeByFilter(string employeeFilter, Guid? departmentId, Guid? positionId, int pageIndex, int pageSize);

        /// <summary>
        /// Hàm lấy mã nhân viên mới
        /// </summary>
        /// <returns>Mã nhân viên mới</returns>
        /// CreatedBy: PTHIEU (02/08/2021)
        public string GetNewEmployeeCode();
    }
}
