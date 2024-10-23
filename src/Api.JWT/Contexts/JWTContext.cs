using Api.JWT.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.JWT.Contexts;

public class JWTContext(DbContextOptions<JWTContext> options) : DbContext(options)
{
    public DbSet<JWTEntity> JWT { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<JWTEntity>(JWTEntity.Map);
    }
}