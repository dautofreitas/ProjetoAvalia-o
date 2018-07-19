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
using GeaWebMVC.Utils;

namespace GeaWebMVC.Controllers
{
    [PerfilFilter(TipoPerfil = "Administrador")]
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Operador operador)
        {
            ViewBag.EmpresaId = new SelectList(_businessEmpresa.GetAll(), "Id", "Nome", operador.EmpresaId);
            ViewBag.PerfilId = new SelectList(_businessPerfil.GetAll(), "Id", "Tipo", operador.PerfilId);

            if (ModelState.IsValid)
            {
                MessageReturn messageReturn = _businessOperador.Create(operador);

                if (!messageReturn.IsValid)
                {
                    messageReturn.MessagesError.ForEach(error => ModelState.AddModelError("", error));

                    return View(operador);
                }

                return RedirectToAction("Index");
            }

            
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

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Operador operador)
        {
            ViewBag.EmpresaId = new SelectList(_businessEmpresa.GetAll(), "Id", "Nome", operador.EmpresaId);
            ViewBag.PerfilId = new SelectList(_businessPerfil.GetAll(), "Id", "Tipo", operador.PerfilId);
            if (ModelState.IsValid)
            {

                MessageReturn messageReturn = _businessOperador.Update(operador);

                if (!messageReturn.IsValid)
                {
                    messageReturn.MessagesError.ForEach(error => ModelState.AddModelError("", error));

                    return View(operador);
                }
                
                return RedirectToAction("Index");
            }
           
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
