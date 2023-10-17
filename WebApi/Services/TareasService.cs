using System.Threading.Tasks;
using webapi.Models;

namespace WebApi.Services
{
    public class TareasService : ITareaService
    {
        TareasContext context;

        public TareasService(TareasContext dbcontext)
        {
            this.context = dbcontext;
        }

        public IEnumerable<Tarea> GetTareas()
        {
            return context.Tareas;
        }

        public async Task Save(Tarea tarea)
        {
            context.Tareas.Add(tarea);
            await context.SaveChangesAsync();
        }

        public async Task Update(Guid id, Tarea tarea)
        {
            var tareaActual = context.Tareas.Find(id);

            if (tareaActual != null)
            {
                tareaActual.CategoriaId = tarea.CategoriaId;
                tareaActual.TareaId = tarea.TareaId;
                tareaActual.PrioridadTarea = tarea.PrioridadTarea;
                tareaActual.Descripcion = tarea.Descripcion;
                tareaActual.FechaCreacion = tarea.FechaCreacion;
                tareaActual.Titulo = tarea.Titulo;

                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            var tareaActual = context.Tareas.Find(id);

            if (tareaActual != null)
            {
                context.Remove(tareaActual);
                await context.SaveChangesAsync();
            }
        }
    }

    public interface ITareaService
    {
        IEnumerable<Tarea> GetTareas();
        Task Save(Tarea tarea);
        Task Update(Guid id, Tarea tarea);
        Task Delete(Guid id);
    }
}
