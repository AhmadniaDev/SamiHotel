using Domain.Models.Hotels;
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
    internal class RoomPriceConfiguration : IEntityTypeConfiguration<RoomPrice>
    {
        public void Configure(EntityTypeBuilder<RoomPrice> builder)
        {
            builder.HasKey(x => x.Id);

          
            builder.HasOne(s => s.Room)
               .WithMany(s => s.roomprice)
               .OnDelete(DeleteBehavior.Restrict)
               .HasForeignKey(s => s.RoomId);
        }
    }
}
