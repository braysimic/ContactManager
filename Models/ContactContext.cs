using Microsoft.EntityFrameworkCore;
using System;

namespace ContactManager.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options)
            : base(options)
        { }

        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Family" },
                new Category { CategoryId = 2, Name = "Friends" },
                new Category { CategoryId = 3, Name = "Work" }
            );
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    ContactId = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Phone = "123-456-7890",
                    Email = "johndoe@example.com",
                    CategoryId = 1,
                    DateAdded = new DateTime(2025, 1, 1)
                },
                new Contact
                {
                    ContactId = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Phone = "987-654-3210",
                    Email = "janesmith@example.com",
                    CategoryId = 2,
                    DateAdded = new DateTime(2025, 1, 1)
                }
            );
        }
    }
}

