using System;
using System.Collections.Generic;
using System.Text;

namespace GardeManger.Application.DTOs
{
    public class OpeningStockElementDTO
    {
        /// <summary>
        /// Name of the element
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Date of expiration after opening
        /// </summary>
        public DateTime? OpeningDate { get; set; }

        /// <summary>
        /// Duration of conservation after opening
        /// </summary>
        public TimeSpan? ConservationPeriodAfterOpening { get; set; }
    }
}
