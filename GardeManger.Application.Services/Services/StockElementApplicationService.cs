using GardeManger.Application.DTOs;
using GardeManger.Application.DTOs.Factories;
using GardeManger.DatabaseAcces;
using GardeManger.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GardeManger.Application.Services.Services
{
    public class StockElementApplicationService
    {
        public void CreateNew(StockElementDTO newStockElements)
        {
            using (var dbContext = new DatabaseContext())
            {
                var stockElements = StockElementFactory.ConvertToEntity(newStockElements);
                stockElements.Select(x => { x.PurchaseDate = DateTime.Now; return x; }).ToList();
                dbContext.AddRange(stockElements);
                dbContext.SaveChanges();
            }
        }

        public List<StockElementDTO> GetAll()
        {
            using (var dbContext = new DatabaseContext())
            {
                var stockElements = dbContext.StockElements.ToList();
                var stockElementDtos = StockElementFactory.ConvertToDtos(stockElements);

                return stockElementDtos;
            }
        }

        public List<StockElementDTO> GetByFilter(string elementName)
        {
            using (var dbContext = new DatabaseContext())
            {
                var stockElements = dbContext.StockElements.Where(x => x.Name == elementName).ToList();
                var stockElementDtos = StockElementFactory.ConvertToDtos(stockElements);

                return stockElementDtos;
            }
        }

        public void UpdateStockElement(string elementName, TimeSpan conservationPeriod)
        {
            using (var dbContext = new DatabaseContext())
            {
                var stockElement = dbContext.StockElements.Where(x => x.Name == elementName && x.OpeningDate == null).FirstOrDefault();
                if(stockElement != null)
                {
                    stockElement.OpeningDate = DateTime.Now;
                    stockElement.ConservationPeriodAfterOpening = conservationPeriod;
                    dbContext.SaveChanges();
                }
            }
        }

    }
}
