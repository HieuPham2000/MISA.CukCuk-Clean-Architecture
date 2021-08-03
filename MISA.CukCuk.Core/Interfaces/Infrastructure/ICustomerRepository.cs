using MISA.CukCuk.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Interfaces.Infrastructure
{
    public interface ICustomerRepository: IBaseRepository<Customer>
    {
        bool CheckDuplicateCustomerCode(string customerCode);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerCode"></param>
        /// <param name="customerId"></param>
        /// <returns></returns>
        bool CheckDuplicateCustomerCode(string customerCode, string customerId);
    }
}
