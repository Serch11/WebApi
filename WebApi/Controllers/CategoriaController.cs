using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    //se requiere heredar de ControllerBase para obtener todos los componentes
    // necesarios para realizar peticiones HTTP

    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        ICategoriaServices categoriaServices;

        //el constructor toma el mismo nombre de la clase
        public CategoriaController(ICategoriaServices service)
        {
            this.categoriaServices = service;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(categoriaServices.Get());
        }

        [HttpPost]
        public ActionResult Post([FromBody] Categoria categoria)
        {
            categoriaServices.Save(categoria);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id,[FromBody] Categoria categoria)
        {
            categoriaServices.Update(categoria,id);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            categoriaServices.Delete(id);
            return Ok();
        }
    }
}
