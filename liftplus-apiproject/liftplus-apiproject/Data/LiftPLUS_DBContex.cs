using Microsoft.EntityFrameworkCore;
using liftplus_apiproject.Models;
using liftplus_apiproject.Data.Map;

namespace liftplus_apiproject.Data
{
    public class LiftPLUS_DBContex : DbContext
    {
        public LiftPLUS_DBContex(DbContextOptions<LiftPLUS_DBContex> options) 
            : base(options) 
        {
        
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Treino> Treino { get; set; }  
        
        public DbSet<Exercicio> Exercicios { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TreinoMap());
            modelBuilder.ApplyConfiguration(new ExercicioMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
