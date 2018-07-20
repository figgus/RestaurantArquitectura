using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaRestaurant.Models.Clases;

namespace TiendaRestaurant.Controllers
{
    public class ContactoController : Controller
    {
        // GET: Contacto
        public ActionResult Contacto()
        {
            return View();
        }

        
        [HttpPost]
        public JsonResult EnviarMensaje()
        {
            string res = "false";
            try
            {
                string mail = Request["mail"];
                string texto = Request["texto"];
                string fecha = DateTime.Now.ToString();
                OperacionesMensajes opmen=new OperacionesMensajes();
                opmen.Guardar(texto,fecha,mail);
                res = "true";
            }
            catch (Exception e)
            {
                res = e.Message;
            }
            return Json(res);
        }
    }
}