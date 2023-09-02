using liftplus_apiproject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySqlConnector;

namespace liftplus_apiproject.Data.Map
{
    public class ExercicioMap : IEntityTypeConfiguration<Exercicio>
    {
        public void Configure(EntityTypeBuilder<Exercicio> builder)
        {
            builder.HasKey(x => x.exeId);
            builder.Property(x => x.exeNome).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Musculo).IsRequired().HasMaxLength(150);
            builder.HasAlternateKey(x => x.treinoId);
        }

        void IEntityTypeConfiguration<Exercicio>.Configure(EntityTypeBuilder<Exercicio> builder)
        {
            throw new NotImplementedException();
        }
    }
}
