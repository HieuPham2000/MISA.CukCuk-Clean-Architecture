using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Infrastructure;
using MISA.CukCuk.Core.Interfaces.Service;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    public class DepartmentsController : BaseEntitiesController<Department>
    {

        #region Constructors
        public DepartmentsController(IBaseRepository<Department> baseRepository, IBaseService<Department> baseService) : 
            base(baseRepository, baseService)
        {

        }
        #endregion

    }
}
