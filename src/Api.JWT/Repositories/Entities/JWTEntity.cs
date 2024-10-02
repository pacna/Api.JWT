using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.JWT.Repositories.Entities;

[Table("jwt", Schema = "test")]
public class JWTEntity(string id)
{ 
    public string Id => id;
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }

    public static void Map(EntityTypeBuilder<JWTEntity> entity)
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.CreateDate).IsRequired();
        entity.Property(e => e.UpdateDate).IsRequired();
    }
}