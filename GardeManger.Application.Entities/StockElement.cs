using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GardeManger.Entities
{
    [Table("StockElements")]
    public class StockElement
    {
        /// <summary>
        /// Stock element Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StockElementId { get; set; }

        /// <summary>
        /// Name of the element
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Date of expiration
        /// </summary>
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        /// Date of expiration after opening
        /// </summary>
        public DateTime? OpeningDate { get; set; }

        /// <summary>
        /// Purchase date of the product
        /// </summary>
        public DateTime PurchaseDate { get; set; }

        /// <summary>
        /// Duration of conservation after opening
        /// </summary>
        public TimeSpan? ConservationPeriodAfterOpening { get; set; }

        /// <summary>
        /// Is the product expired
        /// </summary>
        [NotMapped]
        public bool IsExpired
        {
            get
            {
                var isExpirationDateReached = ExpirationDate.HasValue ? ExpirationDate < DateTime.Now : false;
                var isConsomptionPeriodReached = ConservationPeriodAfterOpening.HasValue && OpeningDate.HasValue ? OpeningDate.Value.Add(ConservationPeriodAfterOpening.Value) < DateTime.Now : false;

                return isExpirationDateReached || isConsomptionPeriodReached;
            }

        }

        /// <summary>
        /// Is the product expired
        /// </summary>
        [NotMapped]
        public bool IsOpened
        {
            get
            {
                return OpeningDate.HasValue;
            }

        }

    }
}
