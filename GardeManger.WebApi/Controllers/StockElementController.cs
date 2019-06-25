using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GardeManger.Application.DTOs;
using GardeManger.Application.Services.Services;
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
        private readonly StockElementApplicationService _stockElementApplicationService;

        public StockElementController()
        {
            _stockElementApplicationService = new StockElementApplicationService();
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<StockElementDTO>> Get()
        {
            var stockList = _stockElementApplicationService.GetAll();
            return stockList;
        }

        [HttpGet("{name}")]
        public ActionResult<IEnumerable<StockElementDTO>> Get(string name)
        {
            var stockList = _stockElementApplicationService.GetByFilter(name);

            if (stockList == null)
            {
                return NotFound();
            }

            return stockList;
        }

        [HttpPost]
        public void PostStockElement(StockElementDTO newStockElement)
        {
            _stockElementApplicationService.CreateNew(newStockElement);
        }

        [HttpPut]
        public void UpdateOpeningDate(OpeningStockElementDTO stockElementToUpdate)
        {
            _stockElementApplicationService.UpdateStockElement(stockElementToUpdate);
        }

        [HttpDelete("{name}")]
        public void DeleteElementStock( DeletedStockElementDTO stockElementToDelete)
        {

        }

    }
}