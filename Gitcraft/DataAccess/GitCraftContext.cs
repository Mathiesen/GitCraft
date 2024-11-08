using Gitcraft.Entities;
using Gitcraft.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gitcraft.DataAccess;

public class GitCraftContext : DbContext
{
    public DbSet<Character> Characters { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Item> Items  { get; set; }

    public GitCraftContext(DbContextOptions<GitCraftContext> options) 
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Gitcraft");
        modelBuilder.Entity<Inventory>().HasNoKey();
    }
}