using Domain.Models.HotelGalleries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class HotelGalleryConfiguraion : IEntityTypeConfiguration<HotelGallery>
    {
        public void Configure(EntityTypeBuilder<HotelGallery> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.path)
                  .IsRequired();

            builder.HasOne(s => s.Hotel)
               .WithMany(s => s.HotelGalleries)
               .OnDelete(DeleteBehavior.Restrict)
               .HasForeignKey(s => s.HotelId);

        }
    }
}
