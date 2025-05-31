using Domain.IBaseRepository;
using Domain.Models.Prices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Capacity
{
    public interface IRoomCapacityRepository : IBaseRepository<RoomCapacity, int>
    {
        void AddHistory(RoomCapacityHistory history);
    }
}
