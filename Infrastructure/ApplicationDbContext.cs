
using Domain.BaseEntity;
using Domain.Models.Capacity;
using Domain.Models.HotelGalleries;
using Domain.Models.Hotels;
using Domain.Models.Prices;
using Domain.Models.Roles;
using Domain.Models.Rooms;
using Domain.Models.Users;
using Domain.UnitOfWork;
using Infrastructure.Extenstion;
using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<User , Role , int >, IUnitOfWork
    {

        private readonly IMediator _mediator;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelGallery> HotelGalleries { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<RoomPrice> RoomPrices { get; set; }
        public DbSet<RoomPriceHistory> RoomPriceHistorys { get; set; }
        public DbSet<RoomCapacityHistory> RoomCapacityHistorys { get; set; }
        public DbSet<RoomCapacity> RoomCapacitys { get; set; }
       

        public async Task<int> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispachDomainEvent(this);

            var date = DateTime.Now;
            var entries = ChangeTracker.Entries<IBaseEntity<int>>();
            foreach(var entry in entries)
            {
                if(entry.State == EntityState.Added) 
                {
                    entry.Entity.Created = date;
                    entry.Entity.CreatedBy = 0;
                }

                if(entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    entry.Entity.Modified = date;
                    entry.Entity.ModifiedBy = 0;
                }

            }
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }


    }
}
