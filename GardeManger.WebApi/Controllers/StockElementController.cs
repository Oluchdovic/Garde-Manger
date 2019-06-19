using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GardeManger.DatabaseAcces;
using GardeManger.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GardeManger.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockElementController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<StockElement>> Get()
        {
            using (var dbContext = new DatabaseContext())
            {
                var stockList = dbContext.StockElements.ToList();
                return stockList;
            }          
        }
    }
}