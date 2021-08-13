using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Infrastructure;
using MISA.CukCuk.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    /// <summary>
    /// Lớp controller cung cấp api thao tác với dữ liệu Khách hàng (Customer)
    /// </summary>
    /// CreatedBy: PTHIEU (30/07/2021)
    public class CustomersController : BaseEntitiesController<Customer>
    {

        #region Constructors

        public CustomersController(IBaseService<Customer> baseService) : base(baseService)
        {

        }
        #endregion

    }
}
