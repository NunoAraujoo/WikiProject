using Microsoft.EntityFrameworkCore;
using WikiProject.Domain.Entities;

namespace WikiProject.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Id = 1,
                    Name = "Placeholder1",
                    Description = "Does something something.",
                    ImageUrl = "https://placehold.co/600x400",
                },
                new Item
                {
                    Id = 2,
                    Name = "Placeholder2",
                    Description = "Does something something.",
                    ImageUrl = "https://placehold.co/600x401",
                },
                new Item
                {
                    Id = 3,
                    Name = "Placeholder3",
                    Description = "Does something something.",
                    ImageUrl = "https://placehold.co/600x402",
                }

                ) ;
        }
    }
}
