using liftplus_apiproject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace liftplus_apiproject.Data.Map
{
    public class Exercicio : IEntityTypeConfiguration<Treino>
    {
        public void Configure(EntityTypeBuilder<Treino> builder)
        {
            builder.HasKey(x => x.treinoId);
            builder.Property(x => x.treinoNome).IsRequired().HasMaxLength(150);
            builder.Property(x => x.grupoMusucular).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Status).IsRequired();
        }

        void IEntityTypeConfiguration<Treino>.Configure(EntityTypeBuilder<Treino> builder)
        {
            throw new NotImplementedException();
        }
    }
}
