using ControleTarefas.Data.Map;
using ControleTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleTarefas.Data
{
    public class ControleTarefasDBContex : DbContext
    {
        public ControleTarefasDBContex(DbContextOptions<ControleTarefasDBContex> options)
            :base(options)
        {

        }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Adicionando o mapeamento
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
