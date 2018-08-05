using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaRestaurant.Models.Clases
{
    public class OperacionesUsuarios
    {

        private RestaurantEntities2 entidad;

        public OperacionesUsuarios()
        {
            entidad = new RestaurantEntities2();
        }

        public string Borrar(int id)
        {
            string res = "false";
            try
            {
                Usuarios usu;
                usu = entidad.Usuarios.FirstOrDefault(p => p.idUsuario == id);
                entidad.Usuarios.Remove(usu);
                entidad.SaveChanges();
                res = "true";
            }
            catch (Exception e)
            {
                res = e.Message;
            }
            return res;
        }

        public bool Modificar(int id, string nomU, string pass, string pnom, string snom, string appat, string apmat, DateTime fecha, int tipo, string mail)
        {
            bool res = false;
            try
            {
                Usuarios noti = entidad.Usuarios.FirstOrDefault(a => a.idUsuario == id);
                noti.nombreUsuario = nomU;
                noti.password = pass;
                noti.pnombre = pnom;
                noti.snombre = snom;
                noti.apat = appat;
                noti.amat = apmat;
                noti.fechaRegistro = fecha;
                noti.tipoUsuario= tipo;
                noti.email = mail;
                entidad.SaveChanges();
                res = true;
            }
            catch (Exception e)
            {
                res = false;
            }
            return res;
        }

        public string Guardar(string nomU, string pass, string pnom, string snom, string appat, string apmat, DateTime fecha, int tipo, string mail)
        {
            string res = "false";
            try
            {
                Usuarios users = new Usuarios(nomU,pass,pnom,snom,appat,apmat,fecha,tipo,mail);
                entidad.Usuarios.Add(users);
                entidad.SaveChanges();
                res = "true";
            }
            catch (Exception e)
            {
                res = e.Message;
            }
            return res;
        }


        


        public List<Usuarios> TraerTodo()
        {
            List<Usuarios> listaUsuarios = new List<Usuarios>();
            foreach (Usuarios prod in entidad.Usuarios)
            {
                listaUsuarios.Add(prod);
            }
            return listaUsuarios;
        }




    }
}