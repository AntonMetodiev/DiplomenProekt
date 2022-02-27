using PetHotel.App.Domain;
using PetHotel.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using PetHotel.App.Models;

namespace PetHotel.Data
{
    public class ApplicationDbContext : IdentityDbContext<PetHotelUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Event> Events { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PetHotel.App.Models.OrderListingViewModel> OrderListingViewModel { get; set; }
    }
}
