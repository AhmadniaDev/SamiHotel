using Domain.IBaseRepository;
using Domain.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Prices
{
    public interface IRoomPriceRepository : IBaseRepository<RoomPrice, int>
    {
        void AddHistory(RoomPriceHistory history);
    }
}
