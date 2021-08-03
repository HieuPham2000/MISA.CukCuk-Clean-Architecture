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
    [Route("api/v1/positions")]
    [ApiController]
    public class PositionsController : BaseEntitiesController<Position>
    {

        #region Constructors
        public PositionsController(IBaseRepository<Position> baseRepository, IBaseService baseService) :
            base(baseRepository, baseService)
        {

        }
        #endregion
    }
}
