using Microsoft.EntityFrameworkCore;
using liftplus_apiproject.Models;

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

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
