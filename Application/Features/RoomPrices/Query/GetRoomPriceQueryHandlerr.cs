using Application.Features.RoomPrices.Dto;
using Domain.Models.Prices;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;

using Application.Common.Extenstios;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.RoomPrices.Query
{

    public class GetRoomPriceQueryHandlerr : IRequestHandler<GetRoomPriceQuery, RoomPriceDto>
    {
        private readonly IRoomPriceRepository _roomPrice;

        public GetRoomPriceQueryHandlerr(IRoomPriceRepository roomPrice)
        {
            _roomPrice = roomPrice;
        }

        public async Task<RoomPriceDto> Handle(GetRoomPriceQuery request, CancellationToken cancellationToken)
        {
            var prices = await _roomPrice.Get(a => a.Room.HotelId == request.HotelId && a.Room.Enable
                 && (request.rooms != null ? request.rooms.Contains(a.RoomId) : true) )
                .Include(a => a.Room)
                .GroupBy(r => new { r.RoomId, r.Room.Name })
                .Select(s => new RoomPriceName()
                {
                    RoomId = s.Key.RoomId,
                    Name = s.Key.Name,
                    RoomPrices = s.Select(x => new RoomPriceList()
                    {
                        BedPrice = x.BedPrice,
                        DateVal = x.DateVal,
                        Price = x.Price,
                    }).ToList(),
                }).ToListAsync();


            var data = new RoomPriceDto()
            {
                Rooms = prices,
                Days = DateTimeExtenstion.GetNextSevenDays(request.startDate),
            };


            return data;
        }
    }
}
