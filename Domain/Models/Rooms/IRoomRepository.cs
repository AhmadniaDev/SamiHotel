using Domain.IBaseRepository;
using Domain.Models.Prices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Rooms
{
    public interface IRoomRepository : IBaseRepository<Room , int>
    {
    }
}
