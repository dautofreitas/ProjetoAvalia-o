//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using Data;
//using GeaWebMVC.Business.RepositoryInterfaces;
//using GeaWebMVC.Models;
//using GeaWebMVC.Utils;

//namespace GeaWebMVC.Controllers
//{
//    [PerfilFilter(TipoPerfil = "Administrador")]
//    public class PerfilController : Controller
//    {
//        private readonly IBusinessPerfil _businessPerfil;

//        public PerfilController(IBusinessPerfil businessPerfil)
//        {
//            _businessPerfil = businessPerfil;
//        }
//        private GeaContext db = new GeaContext();

//        // GET: Perfil
//        public ActionResult Index()
//        {
//           /// return View(db.Perfils.ToList());
//        }

//        // GET: Perfil/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//           Perfil perfil = db.Perfils.Find(id);
//            if (perfil == null)
//            {
//                return HttpNotFound();
//            }
//            return View(perfil);
//        }

//        // GET: Perfil/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

     
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "Id,Tipo")] Perfil perfil)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Perfils.Add(perfil);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(perfil);
//        }

//        // GET: Perfil/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Perfil perfil = db.Perfils.Find(id);
//            if (perfil == null)
//            {
//                return HttpNotFound();
//            }
//            return View(perfil);
//        }

      
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "Id,Tipo")] Perfil perfil)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(perfil).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(perfil);
//        }

//        // GET: Perfil/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Perfil perfil = db.Perfils.Find(id);
//            if (perfil == null)
//            {
//                return HttpNotFound();
//            }
//            return View(perfil);
//        }

//        // POST: Perfil/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            Perfil perfil = db.Perfils.Find(id);
//            db.Perfils.Remove(perfil);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
