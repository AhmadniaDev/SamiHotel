using Application.Common.Execption;
using Domain.Models.Capacity;
using Domain.Models.Prices;
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
    public class UpdateRoomCapacityCommandHamdler : IRequestHandler<UpdateRoomCapacityCommand, bool>
    {
       private readonly IRoomCapacityRepository _roomCapacityRepository;

    public UpdateRoomCapacityCommandHamdler(IRoomCapacityRepository roomCapacityRepository)
    {
        _roomCapacityRepository = roomCapacityRepository;
    }

        public async Task<bool> Handle(UpdateRoomCapacityCommand request, CancellationToken cancellationToken)
        {
            if (request.CapacityListss == null)
                throw new CustomException("لیست ظرفیت‌ها نمی‌تواند خالی باشد");

            foreach (var items in request.CapacityListss)
            {
               

                var Capacity = await _roomCapacityRepository.Get(a => a.DateVal.Date == items.DateVal.Date && a.RoomId == items.RoomId)
                    .FirstOrDefaultAsync();

                if (Capacity == null)
                {
                    var NewPrice = new RoomCapacity
                    {
                        Qty = items.Qty,
                        DateVal = items.DateVal,
                        RoomId = items.RoomId
                    };

                    _roomCapacityRepository.Add(NewPrice);
                }
                else
                {
                    Capacity.Qty = items.Qty;
                    _roomCapacityRepository.Update(Capacity);
                }
                var history = new RoomCapacityHistory(items.RoomId, items.Qty, items.DateVal, null , true);
                _roomCapacityRepository.AddHistory(history);
            }

            await _roomCapacityRepository.unitOfWork.SaveEntitiesAsync();
            return true;
        }
    }
}


