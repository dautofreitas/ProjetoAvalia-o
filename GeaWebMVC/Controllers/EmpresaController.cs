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
    public class EmpresaController : Controller
    {
        private readonly IBusinessEmpresa _businessEmpresa;

        public EmpresaController(IBusinessEmpresa businessEmpresa)
        {
            _businessEmpresa = businessEmpresa;
        }

        // GET: Empresa
        public ActionResult Index()
        {
            return View(_businessEmpresa.GetAll());
        }

        // GET: Empresa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = _businessEmpresa.GetById(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // GET: Empresa/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                MessageReturn messageReturn = _businessEmpresa.Create(empresa);
                
                if (!messageReturn.IsValid)
                {
                    messageReturn.MessagesError.ForEach( error =>  ModelState.AddModelError("",error));

                    return View(empresa);
                }
                return RedirectToAction("Index");
            }

            return View(empresa);
        }

        // GET: Empresa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = _businessEmpresa.GetById(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Empresa empresa)
        {
            if (ModelState.IsValid)
            {

                

                MessageReturn messageReturn = _businessEmpresa.Update(empresa);

                if (!messageReturn.IsValid)
                {
                    messageReturn.MessagesError.ForEach(error => ModelState.AddModelError("", error));

                    return View(empresa);
                }

                return RedirectToAction("Index");
            }
            return View(empresa);
        }

        // GET: Empresa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index"); ;
            }
            Empresa empresa = _businessEmpresa.GetById(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // POST: Empresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empresa empresa = _businessEmpresa.GetById(id);
            _businessEmpresa.Remove(empresa);
            
            return RedirectToAction("Index");
        }
            
    }
}
