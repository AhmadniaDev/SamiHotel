using Application.Common.Execption;
using Application.Common.Extenstios;
using Application.Features.RoomPrices.Command;
using Domain.Models.Capacity;
using Domain.Models.Prices;
using Domain.Models.Rooms;
using Infrastructure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Capacity.Command
{
    public class CreateRoomCapacityCommandHandler : IRequestHandler<CreateRoomCapacityCommand, bool>
    {
        private readonly IRoomCapacityRepository _roomCapacityRepository;
        private readonly IRoomRepository _roomRepository;
        public CreateRoomCapacityCommandHandler(IRoomCapacityRepository roomCapacityRepository, IRoomRepository roomRepository)
        {
            _roomCapacityRepository = roomCapacityRepository;
            _roomRepository = roomRepository;
        }

        public async Task<bool> Handle(CreateRoomCapacityCommand request, CancellationToken cancellationToken)
        {
            var form = request.form.ToMildaiDateTime();
            var to = request.to.ToMildaiDateTime();
            int days = (to - form).Days;

            var roomCapacitys = await _roomCapacityRepository.Get(a => request.Rooms.Contains(a.RoomId) && (a.DateVal >= form && a.DateVal < to))
                        .ToListAsync();

            foreach (var roomId in request.Rooms)
            {
                var room = await _roomRepository.FindAsync(roomId);
                if (room == null) continue;
                if (room.HotelId != request.HotelId.Value) throw new CustomException("خطا امیتی :این اتاق برای این هتل نیست ");


                for (int i = 0; i < days; i++)
                {
                    DateTime date = form.AddDays(i);
                    var roomCapacity = roomCapacitys.Where(a => a.RoomId == roomId && a.DateVal.Date == date.Date)
                        .FirstOrDefault();

                    if (roomCapacity == null)
                    {
                        var newRoomCapacity = new Domain.Models.Capacity.RoomCapacity()
                        {
                            RoomId = roomId,
                            Qty = request.Qty,
                            DateVal = date,
                            State = request.State,
                        };
                        _roomCapacityRepository.Add(newRoomCapacity);
                    }

                    else
                    {
                        roomCapacity.Qty = request.Qty;

                        _roomCapacityRepository.Update(roomCapacity);
                    }
                }

                var history = new RoomCapacityHistory(roomId, request.Qty, form, to ,request.State);
                _roomCapacityRepository.AddHistory(history);
            }
            await _roomCapacityRepository.unitOfWork.SaveEntitiesAsync();
            return true;
        }
    }
}
