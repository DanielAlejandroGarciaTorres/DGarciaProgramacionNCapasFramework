using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebApi.Controllers
{
    public class ProductoController : ApiController
    {

        [Route("api/Producto/Add")]
        [HttpPost]  ///Codigos de error HTTP 
        public IHttpActionResult Add([FromBody] ML.Producto producto)
        {
            ML.Result result = BL.Producto.Add(producto);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("api/Producto/Update")]
        [HttpPut]  ///Codigos de error HTTP 
        public IHttpActionResult Update([FromUri] int idProducto, [FromBody] ML.Producto producto)
        {
            ML.Result result = BL.Producto.Update(idProducto, producto);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [Route("api/Producto/Delete")]
        [HttpDelete]  ///Codigos de error HTTP 
        public IHttpActionResult Delete([FromUri] int idProducto)
        {
            ML.Result result = BL.Producto.Delete(idProducto);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [Route("api/Producto/GetAll")]
        [HttpGet]  ///Codigos de error HTTP 
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Producto.GetAll();
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [Route("api/Producto/GetById")]
        [HttpGet]  ///Codigos de error HTTP 
        public IHttpActionResult GetById([FromUri] int idProducto)
        {
            ML.Result result = BL.Producto.GetById(idProducto);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
    }
}
