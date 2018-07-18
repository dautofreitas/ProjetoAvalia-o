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
    public class FaturamentoController : Controller
    {
        private readonly IBusinessFaturamento _businessFaturamento;
        private readonly IBusinessEmpresa _businessEmpresa;

        public FaturamentoController(IBusinessFaturamento businessFaturamento, IBusinessEmpresa businessEmpresa)
        {
            _businessFaturamento = businessFaturamento;
            _businessEmpresa = businessEmpresa;
        }
        
        // GET: Faturamento
        public ActionResult Index()
        {
            //var faturamentos = db.Faturamentos.Include(f => f.Empresa);
                        
            return View(_businessFaturamento.GetAll());
        }

        // GET: Faturamento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faturamento faturamento = _businessFaturamento.GetById(id);
            if (faturamento == null)
            {
                return HttpNotFound();
            }
            return View(faturamento);
        }

        // GET: Faturamento/Create
        public ActionResult Create()
        {
            ViewBag.EmpresaId = new SelectList(_businessEmpresa.GetAll(), "Id", "Nome");
            return View();
        }

        // POST: Faturamento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmpresaId,DataCompetencia,DataPagamento,ValorCompetencia")] Faturamento faturamento)
        {
            if (ModelState.IsValid)
            {
                
                return RedirectToAction("Details", _businessFaturamento.GerarFaturamento(faturamento));
            }

            ViewBag.EmpresaId = new SelectList(_businessEmpresa.GetAll(), "Id", "Nome", faturamento.EmpresaId);
            return View(faturamento);
        }

       
        // GET: Faturamento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faturamento faturamento = _businessFaturamento.GetById(id);
            if (faturamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpresaId = new SelectList(_businessEmpresa.GetAll(), "Id", "Nome", faturamento.EmpresaId);
            return View(faturamento);
        }

        // POST: Faturamento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmpresaId,DataCompetencia,DataPagamento,ValorCompetencia")] Faturamento faturamento)
        {
            if (ModelState.IsValid)
            {
                _businessFaturamento.Update(faturamento);
                return RedirectToAction("Index");
            }
            ViewBag.EmpresaId = new SelectList(_businessEmpresa.GetAll(), "Id", "Nome", faturamento.EmpresaId);
            return View(faturamento);
        }

        // GET: Faturamento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faturamento faturamento = _businessFaturamento.GetById(id);
            if (faturamento == null)
            {
                return HttpNotFound();
            }
            return View(faturamento);
        }

        // POST: Faturamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Faturamento faturamento = _businessFaturamento.GetById(id);
            _businessFaturamento.Remove(faturamento);
            return RedirectToAction("Index");
        }

        public ActionResult SendEmail(int ? id)
        {
            if (id != null)
            {
                Faturamento faturamento = _businessFaturamento.GetById(id);
                _businessFaturamento.SendEmail(faturamento);
                
            }

            return View("Index");

        }


    }
}
