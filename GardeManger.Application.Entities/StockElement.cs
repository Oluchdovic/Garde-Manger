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
    }
}
