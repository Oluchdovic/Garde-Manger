using GardeManger.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public static List<StockElement> ConvertToEntity(StockElementDTO dto)
        {
            var stockElementList = new List<StockElement>();
            for (int i = 0; i < dto.Quantity; i++)
            {
                stockElementList.Add(new StockElement()
                {
                    Name = dto.Name,
                    PurchaseDate = dto.PurchaseDate,
                    ExpirationDate = dto.ExpirationDate != DateTime.MinValue ? dto.ExpirationDate : (DateTime?)null,
                    OpeningDate = dto.OpeningDate != DateTime.MinValue ? dto.OpeningDate : (DateTime?)null,
                    ConservationPeriodAfterOpening = dto.ConservationPeriodAfterOpening != TimeSpan.MinValue ? dto.ConservationPeriodAfterOpening : (TimeSpan?)null,
                });
            }

            return stockElementList;
        }

        /// <summary>
        /// Convert entity to dto
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static StockElementDTO ConvertToDto(StockElement entity)
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

        /// <summary>
        /// Convert a list of entities into a list of dtos
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<StockElementDTO> ConvertToDtos(List<StockElement> entities)
        {
            var stockElements = entities.GroupBy(x => new { x.Name, x.OpeningDate }).ToList();
            var stockElementDtos = new List<StockElementDTO>();
            foreach (var groupedElements in stockElements)
            {
                var dto = groupedElements.Select(StockElementFactory.ConvertToDto).FirstOrDefault();
                dto.Quantity = groupedElements.Count();

                stockElementDtos.Add(dto);
            }

            return stockElementDtos;
        }

        public static StockElement UpdateEntity(StockElement stockElement, OpeningStockElementDTO updateDto)
        {
            if(updateDto.ConservationPeriodAfterOpening != null)
                stockElement.ConservationPeriodAfterOpening = updateDto.ConservationPeriodAfterOpening;

            if (updateDto.OpeningDate != null)
                stockElement.OpeningDate = updateDto.OpeningDate;

            return stockElement;

        }


    }
}
