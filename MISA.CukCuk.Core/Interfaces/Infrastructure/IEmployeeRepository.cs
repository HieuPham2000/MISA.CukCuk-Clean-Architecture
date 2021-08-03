using MISA.CukCuk.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Interfaces.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEmployeeRepository: IBaseRepository<Employee>
    {
        bool CheckDuplicateEmployeeCode(string employeeCode);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        bool CheckDuplicateEmployeeCode(string employeeCode, string employeeId);
    }
}
