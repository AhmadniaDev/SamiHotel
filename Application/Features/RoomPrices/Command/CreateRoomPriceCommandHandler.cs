using Application.Common.Execption;
using Application.Common.Extenstios;
using Domain.Models.Prices;
using Domain.Models.Rooms;
using Infrastructure.Migrations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Features.RoomPrices.Command
{
    public class CreateRoomPriceCommandHandler : IRequestHandler<CreateRoomPriceCommand, bool>
    {
        private readonly IRoomPriceRepository _roomPriceRepository;
        private readonly IRoomRepository _roomRepository;
        public CreateRoomPriceCommandHandler(IRoomPriceRepository roomPriceRepository , IRoomRepository roomRepository)
        {
            _roomPriceRepository = roomPriceRepository;
            _roomRepository = roomRepository;
        }
        public async Task<bool> Handle(CreateRoomPriceCommand request, CancellationToken cancellationToken)
        {

            var form = request.form.ToMildaiDateTime();
            var to = request.to.ToMildaiDateTime();
            int days = (to - form).Days;

            var roomPrices = await _roomPriceRepository.Get(a => request.Rooms.Contains(a.RoomId) && (a.DateVal >= form && a.DateVal < to))
                        .ToListAsync();
            foreach (var roomId in request.Rooms)
            {
                var room = await _roomRepository.FindAsync(roomId);
                if (room == null) continue;
                if (room.HotelId != request.HotelId.Value) throw new CustomException("خطا امیتی :این اتاق برای این هتل نیست ");


                for (int i = 0; i < days; i++)
                { 
                    DateTime date = form.AddDays(i);
                    var roomPrice = roomPrices.Where(a => a.RoomId == roomId && a.DateVal.Date == date.Date)
                        .FirstOrDefault(); 

                    if(roomPrice == null)
                    {

                        var newRoomPrice = new Domain.Models.Prices.RoomPrice()
                        {
                            RoomId = roomId,
                            Price = request.Price,
                            BedPrice = request.BedPrice,
                            DateVal = date
                        };
                        _roomPriceRepository.Add(newRoomPrice);
                    }
                    else
                    {
                        roomPrice.Price =   request.Price;
                        roomPrice.BedPrice = request.BedPrice;

                        _roomPriceRepository.Update(roomPrice);
                    }
                }          
            }
             await _roomPriceRepository.unitOfWork.SaveEntitiesAsync();
            return true;
        }
    }
}
