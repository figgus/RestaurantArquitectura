using System;
using System.Web.Mvc;
using TiendaRestaurant.Models.Clases;

namespace TiendaRestaurant.Controllers
{
    [Authorize(Roles ="admin")]
    public class MantenedorController : Controller
    {
        // GET: Mantenedor
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EditarMensaje()
        {
            return View();
        }
        public ActionResult EditarNoticia()
        {
            return View();
        }
        public ActionResult EditarProducto()
        {
            return View();
        }
        public ActionResult EditarUsuario()
        {
            return View();
        }
        public ActionResult EditarVenta()
        {
            return View();
        }

        public ActionResult AgregarMensaje()
        {
            return View();
        }
        public ActionResult AgregarNoticia()
        {
            return View();
        }
        public ActionResult AgregarProducto()
        {
            return View();
        }
        public ActionResult AgregarUsuario()
        {
            return View();
        }
        public ActionResult AgregarVenta()
        {
            return View();
        }

        public JsonResult Guardar()
        {
            string res="false";
            try
            {
                string bd = Request["bd"];
                
                if (bd=="Mensajes")
                {
                    string texto = texto = Request["textoMensaje"];
                    string date = DateTime.Now.ToString();
                    string emailR = Request["emailRemitente"];
                    OperacionesMensajes opmen = new OperacionesMensajes();
                    opmen.Guardar(texto,date,emailR);
                }
                else if (bd == "Productos")
                {
                    string nom = Request["nombreProducto"];
                    int precio= int.Parse( Request["precio"]);
                    int stock= int.Parse( Request["stock"]);
                    OperacionesProductos opprod = new OperacionesProductos();
                    opprod.Guardar(nom,precio,stock);
                }
                else if (bd == "Noticias")
                {
                    DateTime fecha = DateTime.Now;
                    string texto = Request["textoNoticia"];
                    int idAutor = int.Parse( Request["idAutor"]);
                    OperacionesNoticias opnot = new OperacionesNoticias();
                    opnot.Guardar(fecha,texto,idAutor);
                }
                else if (bd=="Usuarios")
                {
                    string nomusu = Request["nombreUsuario"];
                    string password = Request["password"];
                    string pnombre = Request["pnombre"];
                    string snombre = Request["snombre"];
                    string apat = Request["apat"];
                    string apmat = Request["apmat"];
                    DateTime fecha = DateTime.Now;
                    int tipo = 0;
                    if (Request["tipo"].ToString()=="Administrador")
                    {
                        tipo = 1;
                    }
                    else if (Request["tipo"].ToString() == "Cliente")
                    {
                        tipo = 2;
                    }
                    else
                    {
                        throw new Exception("tipo de usuario no valido");
                    }
                    string email = Request["email"];
                    OperacionesUsuarios opusu = new OperacionesUsuarios();
                    opusu.Guardar(nomusu,password,pnombre,snombre,apat,apmat,fecha,tipo,email);
                }
                else if (bd=="Ventas")
                {
                    OperacionesVentas opven = new OperacionesVentas();
                    int iduser =int.Parse( Request["idUsuario"]);
                    int producto = int.Parse(Request["idProducto"]);
                    if (!opven.Guardar(iduser, producto, DateTime.Now))
                    {
                        throw new Exception("no se guardo");
                    }
                }
                res = "true";
            }
            catch (Exception e)
            {
                res = e.Message;
            }
            return Json(res);
        }

        public string Borrar(int id, string bd)
        {
            string res = "false";
            try
            {
                if (bd=="Mensajes")
                {
                    OperacionesMensajes opmen=new OperacionesMensajes();
                    opmen.Borrar(id);
                }
                else if (bd == "Noticias")
                {
                    OperacionesNoticias opnot = new OperacionesNoticias();
                    opnot.Borrar(id);
                }
                else if (bd == "Productos")
                {
                    OperacionesProductos oprod = new OperacionesProductos();
                    oprod.Borrar(id);
                }
                else if (bd == "Usuarios")
                {
                    OperacionesUsuarios opusu = new OperacionesUsuarios();
                    opusu.Borrar(id);
                }
                else if (bd == "Ventas")
                {
                    OperacionesVentas opven = new OperacionesVentas();
                    opven.Borrar(1);
                }
                else
                {
                    res = "no hay ningun valor";
                }
                res = "true";
            }
            catch (Exception e)
            {

            }
            return res;
        }


        public JsonResult Actualizar()
        {
            string res = "false";
            try
            {
                string bd = Request["bd"];
                if (bd == "Mensajes")
                {
                    int id = int.Parse( Request["idMensaje"]);
                    string texto = Request["textoMensaje"];
                    string fecha = Request["fecha"].ToString();
                    string email = Request["emailRemitente"].ToString(); ;
                    OperacionesMensajes opmen = new OperacionesMensajes();
                    opmen.Modificar(id, texto, fecha, email);
                }
                else if (bd == "Noticias")
                {
                    int id = int.Parse(Request["idNoticia"]);
                    string texto = Request["textoNoticia"].ToString();
                    DateTime fecha = DateTime.Parse( Request["FechaNoticia"].ToString());
                    int idAut = int.Parse( Request["idAutor"]);
                    OperacionesNoticias opnot = new OperacionesNoticias();
                    if(!opnot.Modificar(id, fecha, texto, idAut))
                    {
                        throw new Exception("Error al actualizar");
                    }
                }
                else if (bd == "Productos")
                {
                    int id = int.Parse(Request["idProducto"]);
                    string nom = Request["nombreProducto"];
                    int precio = int.Parse( Request["precio"]);
                    int stock= int.Parse(Request["stock"]);
                    OperacionesProductos oprod = new OperacionesProductos();
                    oprod.Modificar(id,nom,precio,stock);
                }
                else if (bd == "Usuarios")
                {
                    int id = int.Parse(Request["idUsuario"]);
                    string nom = Request["nombreUsuario"].ToString();
                    string password = Request["password"].ToString();
                    string pnombre = Request["pnombre"].ToString();
                    string snombre = Request["snombre"].ToString();
                    string apat = Request["apat"].ToString();
                    string amat = Request["amat"].ToString();
                    DateTime fechaRegistro = DateTime.Parse( Request["fecha"].ToString());
                    int tipoUsuario = int.Parse( Request["tipoUsuario"]);
                    string email = Request["email"].ToString();
                    OperacionesUsuarios opusu = new OperacionesUsuarios();
                    opusu.Modificar(id,nom,password, pnombre, snombre,apat,amat,fechaRegistro,tipoUsuario,email);
                }
                else if (bd == "Ventas")
                {
                    int id = int.Parse( Request["idVenta"]);
                    int idUsuario = int.Parse(Request["idUsuario"]);
                    int idProd = int.Parse(Request["idProducto"]);
                    DateTime dt = DateTime.Parse(Request["fecha"].ToString());
                    OperacionesVentas opven = new OperacionesVentas();
                    if (!opven.Modificar(id, idUsuario, idProd, dt))
                    {
                        throw new Exception("problema en modificar");
                    }
                }
                else
                {
                    res = "no hay ningun valor";
                }
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