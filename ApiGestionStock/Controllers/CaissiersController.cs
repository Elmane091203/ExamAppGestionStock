using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ApiGestionStock.Models;

namespace ApiGestionStock.Controllers
{
    public class CaissiersController : ApiController
    {
        private BdStockExamContext db = new BdStockExamContext();

        // GET: api/Caissiers
        public IQueryable<Caissier> GetCaissiers()
        {
            return db.Caissiers;
        }

        // GET: api/Caissiers/5
        [ResponseType(typeof(Caissier))]
        public IHttpActionResult GetCaissier(int id)
        {
            Caissier caissier = db.Caissiers.Find(id);
            if (caissier == null)
            {
                return NotFound();
            }

            return Ok(caissier);
        }

        // PUT: api/Caissiers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCaissier(int id, Caissier caissier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != caissier.IdCaissier)
            {
                return BadRequest();
            }

            db.Entry(caissier).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaissierExists(id))
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

        // POST: api/Caissiers
        [ResponseType(typeof(Caissier))]
        public IHttpActionResult PostCaissier(Caissier caissier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Caissiers.Add(caissier);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = caissier.IdCaissier }, caissier);
        }

        // DELETE: api/Caissiers/5
        [ResponseType(typeof(Caissier))]
        public IHttpActionResult DeleteCaissier(int id)
        {
            Caissier caissier = db.Caissiers.Find(id);
            if (caissier == null)
            {
                return NotFound();
            }

            db.Caissiers.Remove(caissier);
            db.SaveChanges();

            return Ok(caissier);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CaissierExists(int id)
        {
            return db.Caissiers.Count(e => e.IdCaissier == id) > 0;
        }
    }
}