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
    /// <summary>
    /// Lớp controller cung cấp api thao tác với dữ liệu Phòng ban (Department)
    /// </summary>
    /// CreatedBy: PTHIEU (30/07/2021)
    public class DepartmentsController : BaseEntitiesController<Department>
    {

        #region Constructors
        public DepartmentsController(IBaseService<Department> baseService) : base(baseService)
        {

        }
        #endregion

    }
}
