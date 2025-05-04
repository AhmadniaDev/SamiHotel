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
    public class RemoveImgCommandHandler : IRequestHandler<RemoveImgCommand, bool>
    {
        private readonly IHotelGalleryRepository _galleryRepository;
        private readonly IFileUploadService _fileUploadService;

        public RemoveImgCommandHandler(IHotelGalleryRepository hotelGalleryRepository, IFileUploadService fileUpload)
        {
            _galleryRepository = hotelGalleryRepository;
            _fileUploadService = fileUpload;
        }
        public async Task<bool> Handle(RemoveImgCommand request, CancellationToken cancellationToken)
        {
            var file = await _galleryRepository.FindAsync(request.id);
            var res = await _fileUploadService.RemoveFile(file.path);
            if(res)
            {
                _galleryRepository.Delete(file);
                await _galleryRepository.unitOfWork.SaveEntitiesAsync();
                return true;

            }
            return false;
        }
    }
}
