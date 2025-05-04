using Application.Services.FileUpload;
using Domain.Models.HotelGalleries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.HotelGalleries.Command
{
    public class CreateImgCommandHandler : IRequestHandler<CreateImgCommand, bool>
    {
        private readonly IHotelGalleryRepository _galleryRepository;
        private readonly IFileUploadService _fileUploadService;

        public CreateImgCommandHandler(IHotelGalleryRepository hotelGalleryRepository, IFileUploadService fileUpload )
        {
            _galleryRepository = hotelGalleryRepository;
            _fileUploadService = fileUpload;
        }

        public async Task<bool> Handle(CreateImgCommand request, CancellationToken cancellationToken)
        {
            var name = await _fileUploadService.UploadFileAsync(request.file);
            var hotelGallery = new HotelGallery
            {
                HotelId = request.HotelId.Value,
                path = name,
            };

            _galleryRepository.Add( hotelGallery );
            await _galleryRepository.unitOfWork.SaveEntitiesAsync();

            return true;


        }
    }
}
