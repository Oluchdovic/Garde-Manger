using GardeManger.DatabaseAcces;
using GardeManger.Entities;
using System;

namespace GardeManger.Application.Services.Services
{
    public class StockElementApplicationService
    {
        private void CreateNewStockElement(string name, int quantity)
        {
            CreateNewStockElement(name, quantity);
        }

        private void CreateNewStockElement(string name, int quantity, DateTime? expirationDate = null, DateTime? openingDate = null, TimeSpan? conservationPeriodAfterOpening = null)
        {
            using (var dbContext = new DatabaseContext())
            {

                for (int i = 0; i < quantity; i++)
                {
                    var stockElement = new StockElement()
                    {
                        Name = name,
                        ExpirationDate = expirationDate,
                        OpeningDate = openingDate,
                        ConservationPeriodAfterOpening = conservationPeriodAfterOpening,
                        PurchaseDate = DateTime.Now
                    };

                    dbContext.Add(stockElement);
                }

                dbContext.SaveChanges();
            }
        }
    }
}
