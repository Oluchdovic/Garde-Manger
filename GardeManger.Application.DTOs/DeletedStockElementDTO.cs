using System;
using System.Collections.Generic;
using System.Text;

namespace GardeManger.Application.DTOs
{
    public class DeletedStockElementDTO
    {
        /// <summary>
        /// Quantity to delete
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Quantity to delete
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Is the product to delete is already opened
        /// </summary>
        public bool IsOpened { get; set; } 

        /// <summary>
        /// Is the product to delete is expired
        /// </summary>
        public bool IsExpired { get; set; }
    }
}
