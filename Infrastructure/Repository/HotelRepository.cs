using Domain.Models.Hotels;
using Infrastructure.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class HotelRepository : BaseRepository<Hotel, int>, IHotelRepository
    {
        public HotelRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
