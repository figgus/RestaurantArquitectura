using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaRestaurant.Models;
using TiendaRestaurant.Models.Clases;

namespace TiendaRestaurant.Controllers
{
    public class TiendaController : Controller
    {
        // GET: Tienda
        public ActionResult Index()
        {
            ViewBag.Message = "Pagina principal";
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Login";
            return View();
        }

        public ActionResult Registro()
        {
            ViewBag.Message = "Cree su cuenta";
            return View();
        }

        public ActionResult Carro()
        {
            ViewBag.Message = "Carro de compras";
            return View();
        }

        public ActionResult Tienda()
        {
            ViewBag.Message = "Login";
            OperacionesProductos prods = new OperacionesProductos();
            ViewBag.list = prods.TraerTodo();
            return View(ViewBag.list);
        }

        public ActionResult PanelUsuario()
        {
            ViewBag.Message = "Panel de usuario";
            RestaurantEntities1 db = new RestaurantEntities1();
            var result = (from c in db.Productos
                          from d in db.Usuarios
                          where c.idProducto>=d.idUsuario
                          select new GridTables
                          {
                              idProducto = c.idProducto,
                              precio = c.precio,
                              nombreProducto = c.nombreProducto,
                              stock = c.stock,
                              usuario=new GridTables.user { amat=d.amat,apat=d.apat,email=d.email,fechaRegistro=d.fechaRegistro,idUsuario=d.idUsuario,nombreUsuario=d.nombreUsuario,password=d.password,pnombre=d.pnombre,snombre=d.snombre,tipoUsuario=d.tipoUsuario} 
                          }).ToList();
            //var res2 = (from e in db.Noticias
            //            select new GridTables
            //            {
                            
            //            }
            //            );
            return View(result);
        }

        public ActionResult DetallesProducto()
        {
            ViewBag.Message = "Detalles";
            return View();
        }


        [HttpPost]
        public JsonResult validarLogin()
        {
            string res = "false";
            OperacionesUsuarios opUsers=new OperacionesUsuarios();
            string username = Request["username"];
            string password = Request["password"];
            if (opUsers.ExisteUsuario(username,password))
            {
                Session["validUser"] = true;
                res ="true";
            }
            return Json(res);
        }

        [HttpPost]
        public JsonResult RegistrarNuevoUsuario()
        {
            string res = "false";
            try
            {
                OperacionesUsuarios opUsers = new OperacionesUsuarios();
                string username= Request["nombreUsuario"];
                string pass= Request["password"];
                string pnom= Request["pnombre"];
                string snom= Request["snombre"];
                string apellidoPat= Request["apat"];
                string apmat= Request["amat"];
                DateTime fecha = DateTime.Now;
                int tipo = 2;
                string email= Request["email"];
                opUsers.Guardar(username, pass,pnom,snom,apellidoPat,apmat,fecha,tipo,email);
                res = "true";
            }
            catch (Exception ex)
            {
                res = ex.Message;
            }
            return Json(res);
        }

        [HttpPost]
        public JsonResult AgregarAlCarro()
        {
            string res = "false";
            try
            {
                if (Session["carro"] == null)
                {
                    Session["carro"] = new List<Productos>();
                }
                List<Productos> lista = (List<Productos>)Session["carro"];
                OperacionesProductos oprod = new OperacionesProductos();
                int paramenter = int.Parse(Request["id"]);
                lista.Add(oprod.TraerPorId(paramenter));
                res = "true";
            }
            catch (Exception ex)
            {
                res = ex.Message;
            }
            return Json(res);
        }




    }
}