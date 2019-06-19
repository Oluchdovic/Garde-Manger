using System;

namespace GardeManger.Entities
{
    public class StockElement
    {
        public int StockElementId { get; set; }
        public string Name { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
