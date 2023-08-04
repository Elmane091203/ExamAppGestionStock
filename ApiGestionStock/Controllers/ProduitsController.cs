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
    public class ProduitsController : ApiController
    {
        private BdStockExamContext db = new BdStockExamContext();

        // GET: api/Produits
        /// <summary>
        /// Cette fonction permet de lister les produits qui sont dans la base
        /// </summary>
        /// <returns> IQueryable<Produits> </returns>
        public IQueryable<Produits> GetProduits()
        {
            return db.Produits;
        }

        // GET: api/Produits/5
        [ResponseType(typeof(Produits))]
        public IHttpActionResult GetProduits(string id)
        {
            Produits produits = db.Produits.Find(id);
            if (produits == null)
            {
                return NotFound();
            }

            return Ok(produits);
        }

        // PUT: api/Produits/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduits(string id, Produits produits)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != produits.CodeBar)
            {
                return BadRequest();
            }

            db.Entry(produits).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProduitsExists(id))
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

        // POST: api/Produits
        [ResponseType(typeof(Produits))]
        public IHttpActionResult PostProduits(Produits produits)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Produits.Add(produits);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProduitsExists(produits.CodeBar))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = produits.CodeBar }, produits);
        }

        // DELETE: api/Produits/5
        [ResponseType(typeof(Produits))]
        public IHttpActionResult DeleteProduits(string id)
        {
            Produits produits = db.Produits.Find(id);
            if (produits == null)
            {
                return NotFound();
            }

            db.Produits.Remove(produits);
            db.SaveChanges();

            return Ok(produits);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProduitsExists(string id)
        {
            return db.Produits.Count(e => e.CodeBar == id) > 0;
        }
    }
}