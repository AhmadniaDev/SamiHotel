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
    internal class RoomCapacityConfiguration : IEntityTypeConfiguration<RoomCapacity>
    {
        public void Configure(EntityTypeBuilder<RoomCapacity> builder)
        {
            builder.HasKey(x => x.Id);


            builder.HasOne(s => s.Room)
               .WithMany(s => s.RoomCapacitys)
               .OnDelete(DeleteBehavior.Restrict)
               .HasForeignKey(s => s.RoomId);
        }
    
    }
}
