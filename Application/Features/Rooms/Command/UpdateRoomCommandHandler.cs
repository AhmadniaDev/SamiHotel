using Application.Common.Execption;
using Application.Services.FileUpload;
using Domain.Models.Rooms;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Rooms.Command
{
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, bool>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IFileUploadService _fileUploadService;

        public UpdateRoomCommandHandler(IRoomRepository roomRepository, IFileUploadService fileUploadService)
        {
            _roomRepository = roomRepository;
            _fileUploadService = fileUploadService;
        }
        public async Task<bool> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.FindAsync(request.id);
            if (room == null) 
            {
                throw new CustomException("داده یادفت نشد");
            }

            if(request.path != null)
            {
                room.path = await _fileUploadService.UploadFileAsync(request.path);
            }

            room.Qty = request.Qty;
            room.Name = request.Name;
            room.View = request.View;
            room.MainCapaciary= request.MainCapaciary;
            room.ExtraCapaciary = request.ExtraCapaciary;

            _roomRepository.Update(room);
            await _roomRepository.unitOfWork.SaveEntitiesAsync(cancellationToken);
            return true;
        }
    }
}
