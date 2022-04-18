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
      
        public DbSet<Accomodation> Accomodations { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<TypePet> TypePets { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<PetHotel.App.Models.CreatePetViewModel> CreatePetViewModel { get; set; }

        public DbSet<PetHotel.App.Models.CreateRequestViewModel> CreateRequestViewModel { get; set; }

        public DbSet<PetHotel.App.Models.ListingPetsViewModel> ListingPetsViewModel { get; set; }
    }
}
