using Domain.Models.Prices;
using Domain.Models.Rooms;
using Infrastructure.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class RoomPriceRepository : BaseRepository<RoomPrice, int>, IRoomPriceRepository
    {
        public RoomPriceRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
