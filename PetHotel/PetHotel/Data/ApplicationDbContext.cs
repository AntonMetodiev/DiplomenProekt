using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using PetHotel.App.Models;
using PetHotel.App.Entities;

namespace PetHotel.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<PetHotel.App.Models.ClientBindingAllViewModel> ClientBindingAllViewModel { get; set; }
        public DbSet<Accomodation> Accomodations { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<TypePet> TypePets { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
    }
}
