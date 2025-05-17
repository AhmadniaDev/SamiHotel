using Application.Common.Execption;
using Application.Features.HotelGalleries.Command;
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
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, bool>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IFileUploadService _fileUploadService;

        public CreateRoomCommandHandler(IRoomRepository roomRepository, IFileUploadService fileUploadService)
        {
            _roomRepository = roomRepository;
            _fileUploadService = fileUploadService;
        }

        public async Task<bool> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {

            if (request.path == null)
            {
                throw new CustomException("نیاز به عکس");
            }


            var room = new Room()
            {
                Name = request.Name,
                Qty = request.Qty,
                path = await _fileUploadService.UploadFileAsync(request.path),
                HotelId = request.HotelId.Value,
                View = request.View,
                MainCapaciary = request.MainCapaciary,
                ExtraCapaciary = request.ExtraCapaciary,
             
            };
            _roomRepository.Add(room);
            await _roomRepository.unitOfWork.SaveEntitiesAsync(cancellationToken);
            return true;       
        }
    }
}
