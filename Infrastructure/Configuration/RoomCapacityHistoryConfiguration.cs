using Domain.Models.Prices;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Capacity;

namespace Infrastructure.Configuration
{
    public class RoomCapacityHistoryConfiguration : IEntityTypeConfiguration<RoomCapacityHistory>
    {
        public void Configure(EntityTypeBuilder<RoomCapacityHistory> builder)
        {
            builder.HasKey(x => x.Id);


            builder.HasOne(s => s.Room)
               .WithMany(s => s.RoomCapacityHistorys)
               .OnDelete(DeleteBehavior.Restrict)
               .HasForeignKey(s => s.RoomId);
        }
    }
}
