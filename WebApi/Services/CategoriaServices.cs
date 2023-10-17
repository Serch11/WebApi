using webapi.Models;

namespace WebApi.Services
{
    public class CategoriaService : ICategoriaServices
    {
        TareasContext context;


        public CategoriaService(TareasContext dbcontext)
        {
            this.context = dbcontext;
        }
        public IEnumerable<Categoria> Get()
        {
            return context.Categorias;
        }

        public async Task Save(Categoria categoria)
        {
            context.Add(categoria);
            await context.SaveChangesAsync();
        }

        public async Task Update(Categoria categoria, Guid id)
        {
            var categoriaActual = context.Categorias.Find(id);

            if (categoriaActual != null)
            {
                categoriaActual.Nombre = categoria.Nombre;
                categoriaActual.Descripcion = categoria.Descripcion;
                categoriaActual.Peso = categoria.Peso;
                await context.SaveChangesAsync();
            }
        }


        public async Task Delete(Guid id)
        {
            var categoriaActual = context.Categorias.Find(id);

            if (categoriaActual != null)
            {
                context.Remove(id);
                await context.SaveChangesAsync();
            }
        }
    }


    public interface ICategoriaServices
    {
        IEnumerable<Categoria> Get();
        Task Save(Categoria categoria);
        Task Update(Categoria categoria, Guid id);
        Task Delete(Guid id);
    }
}
