using Api.JWT.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.JWT.Contexts;

public class JWTContext : DbContext
{
    public JWTContext(DbContextOptions<JWTContext> options) : base(options)
    {
    }

    public DbSet<JWTEntity> JWT { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<JWTEntity>(JWTEntity.Map);
    }
}