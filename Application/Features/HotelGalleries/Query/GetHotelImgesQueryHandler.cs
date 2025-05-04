using Domain.Models.HotelGalleries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.HotelGalleries.Query
{
    public class GetHotelImgesQueryHandler : IRequestHandler<GetHotelImgesQuery, List<HotelGallery>>
    {
        private readonly IHotelGalleryRepository _hotelGalleryRepository;

        public GetHotelImgesQueryHandler(IHotelGalleryRepository repository)
        {
            _hotelGalleryRepository = repository;
        }

        public async Task<List<HotelGallery>> Handle(GetHotelImgesQuery request, CancellationToken cancellationToken)
        {
            return await _hotelGalleryRepository.Get(a => a.HotelId == request.HotelId).ToListAsync();
        }
    }
}
