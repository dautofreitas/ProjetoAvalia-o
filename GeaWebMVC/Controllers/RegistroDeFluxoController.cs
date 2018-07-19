using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Data;
using GeaWebMVC.Business.RepositoryInterfaces;
using GeaWebMVC.Models;

namespace GeaWebMVC.Controllers
{
    public class RegistroDeFluxoController : Controller
    {
        private readonly IBusinessRegistroDeFluxo _businessRegistroDeFluxo;
        private readonly IBusinessCarro _businessCarro;
        private readonly IBusinessOperador _businessOperador;
        private readonly IBusinessFaturamento _businessFaturamento;

        public RegistroDeFluxoController(IBusinessRegistroDeFluxo businessRegistroDeFluxo, IBusinessOperador businessOperador, IBusinessCarro businessCarro, IBusinessFaturamento businessFaturamento)
        {
            _businessRegistroDeFluxo = businessRegistroDeFluxo;
            _businessCarro = businessCarro;
            _businessOperador = businessOperador;
            _businessFaturamento = businessFaturamento;

        }
       
        // GET: RegistroDeFluxo
        public ActionResult Index()
        {

            return View(_businessRegistroDeFluxo.GetAll());
        }

        // GET: RegistroDeFluxo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroDeFluxo registroDeFluxo = _businessRegistroDeFluxo.GetById(id);
            if (registroDeFluxo == null)
            {
                return HttpNotFound();
            }
            return View(registroDeFluxo);
        }

        // GET: RegistroDeFluxo/Create
        public ActionResult Create()
        {
            ViewBag.CarroId = new SelectList(_businessCarro.GetAll(), "Id", "Placa");
            ViewBag.FaturamentoId = new SelectList(_businessFaturamento.GetAll(), "Id", "Id");
            ViewBag.OperadorId = new SelectList(_businessOperador.GetAll(), "Id", "Nome");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegistroDeFluxoWihtCarro registroDeFluxoWihtCarro)
        {
            if (ModelState.IsValid)
            {
                Carro carro = new Carro();
                RegistroDeFluxo registroDeFluxo = new RegistroDeFluxo();

                Carro carroExistente = _businessCarro.FindByPlaca(registroDeFluxoWihtCarro.Placa);
                string loginOperador = Request.GetOwinContext().Authentication.User.Identity.Name.Split('|')?[0];


                Operador operador = _businessOperador.FindByLogin(loginOperador);

                registroDeFluxo.DataEntrada = registroDeFluxoWihtCarro.DataEntrada;
                registroDeFluxo.HoraEntrada = registroDeFluxoWihtCarro.HoraEntrada;
                registroDeFluxo.OperadorId = operador.Id;
                if (carroExistente == null)
                {
                    carro.Placa = registroDeFluxoWihtCarro.Placa;
                    carro.Modelo = registroDeFluxoWihtCarro.Modelo;
                    carro.Marca = registroDeFluxoWihtCarro.Marca;
                    registroDeFluxo.Carro = carro;
                }
                else
                {
                    registroDeFluxo.CarroId = carroExistente.Id;
                }

                _businessRegistroDeFluxo.Create(registroDeFluxo);

                TempData["RegistroDeFluxoId"] = registroDeFluxo.Id;

                return RedirectToAction("MenuRegistroDeFluxo");
            }

            return View();
        }

        // GET: RegistroDeFluxo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroDeFluxo registroDeFluxo = _businessRegistroDeFluxo.GetById(id);
            if (registroDeFluxo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarroId = new SelectList(_businessCarro.GetAll(), "Id", "Placa", registroDeFluxo.CarroId);
            ViewBag.FaturamentoId = new SelectList(_businessFaturamento.GetAll(), "Id", "Id", registroDeFluxo.FaturamentoId);
            ViewBag.OperadorId = new SelectList(_businessOperador.GetAll(), "Id", "Nome", registroDeFluxo.OperadorId);

            return View(registroDeFluxo);
        }
             
       

        // GET: RegistroDeFluxo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroDeFluxo registroDeFluxo = _businessRegistroDeFluxo.GetById(id);
            if (registroDeFluxo == null)
            {
                return HttpNotFound();
            }
            return View(registroDeFluxo);
        }

        // POST: RegistroDeFluxo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistroDeFluxo registroDeFluxo = _businessRegistroDeFluxo.GetById(id);
            _businessRegistroDeFluxo.Rmove(registroDeFluxo);
            
            return RedirectToAction("Index");
        }

        public ActionResult MenuRegistroDeFluxo()
        {
            if (TempData.ContainsKey("RegistroDeFluxoId"))
                ViewBag.RegistroDeFluxoId = TempData["RegistroDeFluxoId"].ToString();

            return View();
        }

        public ActionResult FindCodigoRegistro()
        {

            return View();
        }


        [HttpPost]
        public ActionResult FindCodigoRegistro(string CodigoRegistro = "")
        {
            if (!Regex.Match(CodigoRegistro, @"^\d*$").Success)
            {
                ModelState.AddModelError("CodigoRegistro", "Favor informar um valor válido para o código de registro, deve se usado apenas números");

                return View();
            }

            if(_businessRegistroDeFluxo.GetById(Convert.ToInt32(CodigoRegistro))==null)
            {                
                ModelState.AddModelError("CodigoRegistro", "O código de registro informado não foi encontrado");
                return View();
            }

            RegistroDeFluxo registroDeFluxo = _businessRegistroDeFluxo.CalculaValorAPagar(DateTime.Now, Convert.ToInt32(CodigoRegistro));
            return View("Details", registroDeFluxo);
        }


    }
}
