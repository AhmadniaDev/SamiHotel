using Domain.Models.HotelGalleries;
using Domain.Models.Rooms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(x => x.Id);

            //builder.Property(x => x.path)
            //      .IsRequired();

            //builder.HasOne(s => s.Hotel)
            //   .WithMany(s => s.HotelGalleries)
            //   .OnDelete(DeleteBehavior.Restrict)
            //   .HasForeignKey(s => s.HotelId);
        }
    }
}
