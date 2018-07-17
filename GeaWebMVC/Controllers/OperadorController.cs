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

namespace GeaWebMVC.Controllers
{
    public class OperadorController : Controller
    {
        private readonly IBusinessOperador _businessOperador;
        private readonly IBusinessEmpresa _businessEmpresa;
        private readonly IBusinessPerfil _businessPerfil;

        public OperadorController(IBusinessOperador businessOperador, IBusinessPerfil businessPerfil, 
            IBusinessEmpresa businessEmpresa)
        {
            _businessOperador = businessOperador;
            _businessEmpresa = businessEmpresa;
            _businessPerfil = businessPerfil;
        }
        private GeaContext db = new GeaContext();

        // GET: Operador
        public ActionResult Index()
        {
           
            return View(_businessOperador.GetAll());
        }

        // GET: Operador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operador operador = _businessOperador.GetById(id);
            if (operador == null)
            {
                return HttpNotFound();
            }
            return View(operador);
        }

        // GET: Operador/Create
        public ActionResult Create()
        {
            ViewBag.EmpresaId = new SelectList(_businessEmpresa.GetAll(), "Id", "Nome");
            ViewBag.PerfilId = new SelectList(_businessPerfil.GetAll(), "Id", "Tipo");
            return View();
        }

        // POST: Operador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Operador operador)
        {
            if (ModelState.IsValid)
            {
                _businessOperador.Create(operador);
                
                return RedirectToAction("Index");
            }

            ViewBag.EmpresaId = new SelectList(_businessEmpresa.GetAll(), "Id", "Nome", operador.EmpresaId);
            ViewBag.PerfilId = new SelectList(_businessPerfil.GetAll(), "Id", "Tipo", operador.PerfilId);
            return View(operador);
        }

        // GET: Operador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operador operador = _businessOperador.GetById(id);
            if (operador == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpresaId = new SelectList(_businessEmpresa.GetAll(), "Id", "Nome", operador.EmpresaId);
            ViewBag.PerfilId = new SelectList(_businessPerfil.GetAll(), "Id", "Tipo", operador.PerfilId);

            return View(operador);
        }

        // POST: Operador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Operador operador)
        {
            if (ModelState.IsValid)
            {
                _businessOperador.Update(operador);
                return RedirectToAction("Index");
            }
            ViewBag.EmpresaId = new SelectList(db.Empresas, "Id", "Nome", operador.EmpresaId);
            ViewBag.PerfilId = new SelectList(db.Perfils, "Id", "Tipo", operador.PerfilId);
            return View(operador);
        }

        // GET: Operador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operador operador = _businessOperador.GetById(id);
            if (operador == null)
            {
                return HttpNotFound();
            }
            return View(operador);
        }

        // POST: Operador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Operador operador = _businessOperador.GetById(id);
            _businessOperador.Remove(operador);
            return RedirectToAction("Index");
        }

    }
}
