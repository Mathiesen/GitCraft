using Gitcraft.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gitcraft.DataAccess;

public class GitCraftContext : DbContext
{
    public DbSet<Character> Characters { get; set; }

    public GitCraftContext(DbContextOptions<GitCraftContext> options) 
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Gitcraft");
    }
}