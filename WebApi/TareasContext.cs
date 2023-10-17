
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace WebApi
{
    public class TareasContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

        public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Categoria> categoriasInit = new List<Categoria>();
            categoriasInit.Add(new Categoria() { CategoriaId = Guid.NewGuid(), Nombre = "Actividades Pendientes", Peso = 20 });
            categoriasInit.Add(new Categoria() { CategoriaId = Guid.NewGuid(), Nombre = "Actividades Personales", Peso = 50 });

            modelBuilder.Entity<Categoria>(categoria =>
            {

                categoria.HasKey(c => c.CategoriaId);
                categoria.Property(c => c.Nombre).IsRequired().HasMaxLength(150);
                categoria.Property(c => c.Descripcion).IsRequired(false);
                categoria.Property(c => c.Peso);
                categoria.HasData(categoriasInit);
            });


            List<Tarea> tareasInit = new List<Tarea>();

            tareasInit.Add(new Tarea() { TareaId = Guid.NewGuid(), CategoriaId = Guid.NewGuid(), PrioridadTarea = Prioridad.Media, Titulo = "Pago de servicios", FechaCreacion = DateTime.UtcNow });
            tareasInit.Add(new Tarea() { TareaId = Guid.NewGuid(), CategoriaId = Guid.NewGuid(), PrioridadTarea = Prioridad.Alta, Titulo = "terminar de ver pelicula netflix", FechaCreacion = DateTime.UtcNow });

            modelBuilder.Entity<Tarea>(tarea =>
            {
                

                tarea.HasKey(t => t.TareaId);
                tarea.HasOne(t => t.Categoria).WithMany(t => t.Tareas).HasForeignKey(t => t.CategoriaId);
                tarea.Property(t => t.Titulo).IsRequired(true).HasMaxLength(200);
                tarea.Property(t => t.Descripcion).IsRequired(false);
                tarea.Property(t => t.Descripcion).IsRequired();
                tarea.Property(t => t.PrioridadTarea);
                tarea.Property(t => t.FechaCreacion);
                tarea.Ignore(t => t.Resumen);
                tarea.HasData(tareasInit);
            });
        }
    }
}
