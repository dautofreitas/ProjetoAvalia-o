using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeaWeb.Controllers
{
    public class OperadorController : Controller
    {
        // GET: Operador
        public ActionResult Index()
        {
            return View();
        }

        // GET: Operador/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Operador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Operador/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Operador/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Operador/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Operador/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Operador/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
