using Application.Common.Extenstios;
using Application.Features.Capacity.Dto;
using Application.Features.RoomPrices.Dto;
using Application.Features.RoomPrices.Query;
using Domain.Models.Capacity;
using Domain.Models.Prices;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Capacity.Query
{
    public class GetRoomCapacityQueryHandler : IRequestHandler<GetRoomCapacityQuery, RoomCapacityDto>
    {
        private readonly IRoomCapacityRepository _roomCapacity;

        public GetRoomCapacityQueryHandler(IRoomCapacityRepository roomCapacity)
        {
            _roomCapacity = roomCapacity;
        }

        public async Task<RoomCapacityDto> Handle(GetRoomCapacityQuery request, CancellationToken cancellationToken)
        {
            var prices = await _roomCapacity.Get(a => a.Room.HotelId == request.HotelId && a.Room.Enable
                 && (request.rooms != null ? request.rooms.Contains(a.RoomId) : true))
                .Include(a => a.Room)
                .GroupBy(r => new { r.RoomId, r.Room.Name })
                .Select(s => new RoomCapacityName()
                {
                    RoomId = s.Key.RoomId,
                    Name = s.Key.Name,
                    RoomCapacitys = s.Select(x => new RoomCapacityList()
                    {
                        Qty = x.Qty,
                        DateVal = x.DateVal,

                    }).ToList(),
                }).ToListAsync();


            var data = new RoomCapacityDto()
            {
                Rooms = prices,
                Days = DateTimeExtenstion.GetNextSevenDays(request.startDate),
            };


            return data;
        }
    }
}
