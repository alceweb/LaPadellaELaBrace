using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LaPadellaELaBeaceMVC.Models;
using System.Web.Helpers;
using System.IO;

namespace LaPadellaELaBeaceMVC.Controllers
{
    public class PromoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Promoes
        public ActionResult Index()
        {
            return View(db.Promos.ToList());
        }

        // GET: Promoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promo promo = db.Promos.Find(id);
            if (promo == null)
            {
                return HttpNotFound();
            }
            return View(promo);
        }

        // GET: Promoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Promoes/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Promo_Id,DataI,DataF,Nome,Attiva", Exclude = "Descrizione")] Promo promo)
        {
            FormCollection collection = new FormCollection(Request.Unvalidated().Form);
            promo.Descrizione = collection["Descrizione"];
            if (ModelState.IsValid)
            {
                db.Promos.Add(promo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(promo);
        }

        // GET: Promoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promo promo = db.Promos.Find(id);
            if (promo == null)
            {
                return HttpNotFound();
            }
            return View(promo);
        }

        // POST: Promoes/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Promo_Id,DataI,DataF,Nome,Attiva", Exclude = "Descrizione")] Promo promo)
        {
            FormCollection collection = new FormCollection(Request.Unvalidated().Form);
            promo.Descrizione = collection["Descrizione"];

            if (ModelState.IsValid)
            {
                db.Entry(promo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(promo);
        }

        public ActionResult EditImgP(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promo promo = db.Promos.Find(id);
            if (promo == null)
            {
                return HttpNotFound();
            }
            return View(promo);
        }

        [HttpPost]
        public ActionResult EditImgP(HttpPostedFileBase file, int? id)
        {
            if (file != null)
                try
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Immagini/"), id + ".jpg");
                    WebImage img = new WebImage(file.InputStream);
                    var larghezza = img.Width;
                    var altezza = img.Height;
                    var rapporto = altezza / larghezza;
                    if (rapporto != 1)
                    {
                       
                        ViewBag.Message = "L'immagine deve essere quadrata! Quella che hai scelto è di larghezza " + larghezza + " e altezza " + altezza;
                    }
                    else
                    {
                        img.Resize(500, 500);
                        img.Save(path);
                        ViewBag.Message = "Download immagine verticale avvenuto con successo. Dimensione immagine: larghezza " + larghezza + "Altezza" + altezza;
                    }

                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "Devi scegliere un file";
            }
            Promo promo = db.Promos.Find(id);
            if (promo == null)
            {
                return HttpNotFound();
            }
            return View(promo);

        }


        // GET: Promoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promo promo = db.Promos.Find(id);
            if (promo == null)
            {
                return HttpNotFound();
            }
            return View(promo);
        }

        // POST: Promoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Promo promo = db.Promos.Find(id);
            db.Promos.Remove(promo);
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
