using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Matricula_Proyecto.Controllers.Error
{
    public class ErrorController : Controller
    {
        // GET: Error404
        public ActionResult Error404()
        {
            return View();
        }

        // GET: ErrorGeneral
        public ActionResult ErrorGeneral()
        {
            return View();
        }
    }
}