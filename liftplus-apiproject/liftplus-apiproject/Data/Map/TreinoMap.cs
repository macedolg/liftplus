using liftplus_apiproject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace liftplus_apiproject.Data.Map
{
    public class TreinoMap : IEntityTypeConfiguration<Treino>
    {
        public void Configure(EntityTypeBuilder<Treino> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Nome).HasMaxLength(150);
            builder.Property(x => x.GrupoMuscular).HasMaxLength(150);
        }
    }
}
