using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using proyectoandresbeta.Datos;
using proyectoandresbeta.Models;

namespace proyectoandresbeta.Controllers
{
    public class articuloesController : ApiController
        
    {
        private sebastian_testEntities db = new sebastian_testEntities();
        ArticuloAdmin admin = new ArticuloAdmin();

        // GET: api/articuloes
        public async Task<IEnumerable <articulo>> Getarticulo()
        {
            return await  admin.Consultar();
        }

        // GET: api/articuloes/5
        [ResponseType(typeof(articulo))]
        public async Task<IHttpActionResult> Getarticulo(int id)
        {
            articulo articulo = await db.articulo.FindAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }

            return Ok(articulo);
        }

        // PUT: api/articuloes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putarticulo(int id, articulo articulo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != articulo.Id)
            {
                return BadRequest();
            }

            db.Entry(articulo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!articuloExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/articuloes
        [ResponseType(typeof(articulo))]
        public async Task<IHttpActionResult> Postarticulo(articulo articulo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.articulo.Add(articulo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = articulo.Id }, articulo);
        }

        // DELETE: api/articuloes/5
        [ResponseType(typeof(articulo))]
        public async Task<IHttpActionResult> Deletearticulo(int id)
        {
            articulo articulo = await db.articulo.FindAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }

            db.articulo.Remove(articulo);
            await db.SaveChangesAsync();

            return Ok(articulo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool articuloExists(int id)
        {
            return db.articulo.Count(e => e.Id == id) > 0;
        }
    }
}