using Application.Common.Execption;
using Domain.Models.Prices;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.RoomPrices.Command
{
    public class UpdateRoomPriceCommandHandler : IRequestHandler<UpdateRoomPriceCommand, bool>
    {
        private readonly IRoomPriceRepository _roomPriceRepository;

        public UpdateRoomPriceCommandHandler(IRoomPriceRepository roomPriceRepository)
        {
            _roomPriceRepository = roomPriceRepository;
        }

        public async Task<bool> Handle(UpdateRoomPriceCommand request, CancellationToken cancellationToken)
        {
            foreach (var items in request.priceListss)
            {
                if (items == null) throw new CustomException("مبلغ نمیتواند خالی باشد");

                var price = await _roomPriceRepository.Get(a => a.DateVal.Date == items.DateVal.Date && a.RoomId == items.RoomId)
                    .FirstOrDefaultAsync();

                if (price == null)
                {
                    var NewPrice = new RoomPrice
                    {
                        Price = items.Price,
                        DateVal = items.DateVal,
                        BedPrice = items.BedPrice,
                        RoomId = items.RoomId
                    };

                    _roomPriceRepository.Add(NewPrice);
                }
                else
                {
                    price.Price = items.Price;
                    price.BedPrice = items.BedPrice;
                    _roomPriceRepository.Update(price);
                }
            }

            await _roomPriceRepository.unitOfWork.SaveEntitiesAsync();
            return true;
        }
    }
}
