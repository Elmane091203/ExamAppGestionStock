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
    public class StockProduitsController : ApiController
    {
        private BdStockExamContext db = new BdStockExamContext();

        // GET: api/StockProduits
        public IQueryable<StockProduit> GetStockProduits()
        {
            return db.StockProduits;
        }

        // GET: api/StockProduits/5
        [ResponseType(typeof(StockProduit))]
        public IHttpActionResult GetStockProduit(int id)
        {
            StockProduit stockProduit = db.StockProduits.Find(id);
            if (stockProduit == null)
            {
                return NotFound();
            }

            return Ok(stockProduit);
        }

        // PUT: api/StockProduits/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStockProduit(int id, StockProduit stockProduit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stockProduit.IdStockProduit)
            {
                return BadRequest();
            }

            db.Entry(stockProduit).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockProduitExists(id))
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

        // POST: api/StockProduits
        [ResponseType(typeof(StockProduit))]
        public IHttpActionResult PostStockProduit(StockProduit stockProduit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StockProduits.Add(stockProduit);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = stockProduit.IdStockProduit }, stockProduit);
        }

        // DELETE: api/StockProduits/5
        [ResponseType(typeof(StockProduit))]
        public IHttpActionResult DeleteStockProduit(int id)
        {
            StockProduit stockProduit = db.StockProduits.Find(id);
            if (stockProduit == null)
            {
                return NotFound();
            }

            db.StockProduits.Remove(stockProduit);
            db.SaveChanges();

            return Ok(stockProduit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StockProduitExists(int id)
        {
            return db.StockProduits.Count(e => e.IdStockProduit == id) > 0;
        }
    }
}