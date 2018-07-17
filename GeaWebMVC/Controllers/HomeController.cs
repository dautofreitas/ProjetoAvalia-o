using GeaWebMVC.Models;
using Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeaWebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositoryCarro _repositoryCarro;

       public HomeController(IRepositoryCarro repositoryCarro)
        {
            _repositoryCarro = repositoryCarro;
        }


        

        public ActionResult Index()
        {
            //Carro carro = new Carro();

            //carro.Marca = "Teste";
            //carro.Modelo = "Mteste";
            //carro.Placa = "Placa";
            
            //_repositoryCarro.Add(carro);
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}