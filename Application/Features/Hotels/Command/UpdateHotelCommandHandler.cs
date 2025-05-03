using Domain.Models.Hotels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Hotels.Command
{
    internal class UpdateHotelCommandHandler : IRequestHandler<UpdateHotelCommand, bool>
    {
        private readonly IHotelRepository _hotelrepository;

        public UpdateHotelCommandHandler(IHotelRepository hotelrepository)
        {
            _hotelrepository = hotelrepository;
        }

        public async Task<bool> Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
        {
            var hotel = await _hotelrepository.FindAsync(request.HotelId.Value);
            if(hotel is not null)
            {
                hotel.Name = request.Name;
                hotel.City = request.City;
                hotel.Address = request.Address;
                hotel.Phone = request.Phone;
                hotel.Email = request.Email;
                hotel.Star = request.Star;
                hotel.Description = request.Description;
                hotel.State = request.State;

                _hotelrepository.Update(hotel);
                await _hotelrepository.unitOfWork.SaveEntitiesAsync(cancellationToken);

            }
            return true;
        }
    }
}
