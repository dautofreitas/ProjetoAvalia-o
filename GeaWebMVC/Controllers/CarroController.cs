using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;
using GeaWebMVC.Business.RepositoryInterfaces;
using GeaWebMVC.Models;
using Repository.RepositoryInterfaces;

namespace GeaWebMVC.Controllers
{
    public class CarroController : Controller
    {

        private readonly IBusinessCarro _businessCarro;

        public CarroController(IBusinessCarro businessCarro)
        {
            _businessCarro = businessCarro;
        }


        // GET: Carro
        public ActionResult Index()
        {
            return View(_businessCarro.GetAll());
        }

        // GET: Carro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = _businessCarro.GetById(id);

            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // GET: Carro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carro/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Placa,Marca,Modelo")] Carro carro)
        {
            if (ModelState.IsValid)
            {
                _businessCarro.Create(carro);
                return RedirectToAction("Index");
            }

            return View(carro);
        }

        // GET: Carro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = _businessCarro.GetById(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // POST: Carro/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Placa,Marca,Modelo")] Carro carro)
        {
            if (ModelState.IsValid)
            {
                _businessCarro.Update(carro);
                return RedirectToAction("Index");
            }
            return View(carro);
        }

        // GET: Carro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = _businessCarro.GetById(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // POST: Carro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carro carro = _businessCarro.GetById(id);
            _businessCarro.Remove(carro);            
            return RedirectToAction("Index");
        }
             
    }
}
