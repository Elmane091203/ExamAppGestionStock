using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApiGestionStock.Models;

namespace ApiGestionStock.Controllers
{
    public class CaissiersController : Controller
    {
        private BdStockExamContext db = new BdStockExamContext();

        // GET: Caissiers
        public ActionResult Index()
        {
            return View(db.Caissiers.ToList());
        }

        // GET: Caissiers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caissier caissier = db.Caissiers.Find(id);
            if (caissier == null)
            {
                return HttpNotFound();
            }
            return View(caissier);
        }

        // GET: Caissiers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Caissiers/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCaissier,NomCaissier,PreomCaissier,TelephoneCaissier,AdresseCaissier,LoginCaissier,MotDePasseCaissier,PremierCon,Role")] Caissier caissier)
        {
            if (ModelState.IsValid)
            {
                db.Caissiers.Add(caissier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(caissier);
        }

        // GET: Caissiers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caissier caissier = db.Caissiers.Find(id);
            if (caissier == null)
            {
                return HttpNotFound();
            }
            return View(caissier);
        }

        // POST: Caissiers/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCaissier,NomCaissier,PreomCaissier,TelephoneCaissier,AdresseCaissier,LoginCaissier,MotDePasseCaissier,PremierCon,Role")] Caissier caissier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caissier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(caissier);
        }

        // GET: Caissiers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caissier caissier = db.Caissiers.Find(id);
            if (caissier == null)
            {
                return HttpNotFound();
            }
            return View(caissier);
        }

        // POST: Caissiers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Caissier caissier = db.Caissiers.Find(id);
            db.Caissiers.Remove(caissier);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
