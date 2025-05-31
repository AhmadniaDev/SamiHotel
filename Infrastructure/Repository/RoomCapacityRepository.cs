using Domain.Models.Capacity;
using Domain.Models.Prices;
using Infrastructure.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class RoomCapacityRepository : BaseRepository<RoomCapacity, int>, IRoomCapacityRepository
    {
        public RoomCapacityRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void AddHistory(RoomCapacityHistory history)
        {
            _context.RoomCapacityHistorys.Add(history);
        }
    }
}
