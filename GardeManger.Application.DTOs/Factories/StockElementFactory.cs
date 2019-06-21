using GardeManger.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GardeManger.Application.DTOs.Factories
{
    public static class StockElementFactory
    {
        /// <summary>
        /// Convert dto to Entity
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static StockElement ConvertToEntity(this StockElementDTO dto)
        {

            var entity = new StockElement()
            {
                Name = dto.Name,
                PurchaseDate = dto.PurchaseDate,
                ExpirationDate = dto.ExpirationDate != DateTime.MinValue ? dto.ExpirationDate : (DateTime?)null,
                OpeningDate = dto.OpeningDate != DateTime.MinValue ? dto.OpeningDate : (DateTime?)null,
                ConservationPeriodAfterOpening = dto.ConservationPeriodAfterOpening != TimeSpan.MinValue ? dto.ConservationPeriodAfterOpening : (TimeSpan?)null,
            };

            return entity;
        }


        /// <summary>
        /// Convert entity to dto
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static StockElementDTO ConvertToDtos(this StockElement entity)
        {
            var dto = new StockElementDTO()
            {
                Name = entity.Name,
                PurchaseDate = entity.PurchaseDate,
                ExpirationDate = entity.ExpirationDate,
                OpeningDate = entity.OpeningDate,
                ConservationPeriodAfterOpening = entity.ConservationPeriodAfterOpening,
            };

            return dto;
        }


    }
}
