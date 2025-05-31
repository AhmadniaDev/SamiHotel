using Domain.Models.HotelGalleries;
using Domain.Models.Prices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class RoomPriceHistoryConfiguraion : IEntityTypeConfiguration<RoomPriceHistory>
    {
        public void Configure(EntityTypeBuilder<RoomPriceHistory> builder)
        {
            builder.HasKey(x => x.Id);


            builder.HasOne(s => s.Room)
               .WithMany(s => s.RoomPriceHistorys)
               .OnDelete(DeleteBehavior.Restrict)
               .HasForeignKey(s => s.RoomId);
        }
    }
}
