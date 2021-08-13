using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;
using Dapper;
using System.Data;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Infrastructure;
using MISA.CukCuk.Core.Interfaces.Service;

namespace MISA.CukCuk.Api.Controllers
{
    /// <summary>
    /// Lớp controller cung cấp api thao tác với dữ liệu Vị trí/Chức vụ (Position)
    /// </summary>
    /// CreatedBy: PTHIEU (30/07/2021)
    public class PositionsController : BaseEntitiesController<Position>
    {

        #region Constructors
        public PositionsController(IBaseService<Position> baseService) : base( baseService)
        {

        }
        #endregion
    }
}
