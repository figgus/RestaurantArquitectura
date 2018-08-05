using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TiendaRestaurant.Models;
using TiendaRestaurant.Models.Clases;
using System.Web.Security;

namespace TiendaRestaurant.Controllers
{
    public class TiendaController : Controller
    {
        // GET: Tienda
        public ActionResult Index()
        {
            ViewBag.Message = "Pagina principal";
            ViewBag.Notis = new OperacionesNoticias().TraerTodo();
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

        [Authorize(Roles = "cliente")]
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

        [Authorize(Roles ="admin")]
        public ActionResult PanelUsuario()
        {
            ViewBag.Message = "Panel de usuario";
            return View();
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
            int id = 0;
            int tipo = 0;
            foreach (Usuarios user in opUsers.TraerTodo())
            {
                if (user.nombreUsuario.Equals(username) && user.password.Equals(password))
                {
                    id = user.idUsuario;
                    tipo =  user.tipoUsuario.Value;
                    res = "true";
                }
            }
            if (res.Equals("true"))
            {
                string identity = string.Empty;
                FormsAuthentication.SetAuthCookie(username,false);
                if (tipo==1)
                {
                    identity = "admin";
                    if (!Roles.RoleExists(identity))
                    {
                        Roles.CreateRole(identity);
                    }
                    if (!Roles.IsUserInRole(username,identity)) {
                        Roles.AddUserToRole(username, identity);
                    }
                }
                else if(tipo==2)
                {
                    identity = "cliente";
                    
                    if (!Roles.RoleExists("cliente"))
                    {
                        Roles.CreateRole(identity);
                    }
                    if (!Roles.IsUserInRole(username, identity))
                    {
                        Roles.AddUserToRole(username, identity);
                    }
                }
                
                Session["validUser"] = true;
                Session["idUsuario"] = id;
                res ="true"+tipo;
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

        [HttpPost]
        public JsonResult Pagar()
        {
            string res = "false";
            try
            {
                if (Session["carro"] == null)
                {
                    Session["carro"] = new List<Productos>();
                    res = "no hay productos";
                }
                else
                {
                    List<Productos> lista = (List<Productos>)Session["carro"];
                    OperacionesVentas oprod = new OperacionesVentas();
                    int id = (int) Session["idUsuario"];
                    foreach (Productos prod in lista)
                    {
                        if(!oprod.Guardar(id,prod.idProducto, DateTime.Now))
                        {
                            throw new Exception("Error al guardar");
                        }
                    }
                    Session["carro"] = new List<Productos>();
                    res = "true";
                }
            }
            catch (Exception ex)
            {
                res = ex.Message;
            }
            return Json(res);
        }

        [Authorize]
        public void CerrarSession()
        {
            FormsAuthentication.SignOut();
            Response.Redirect("/Tienda/Index");
        }





    }
}