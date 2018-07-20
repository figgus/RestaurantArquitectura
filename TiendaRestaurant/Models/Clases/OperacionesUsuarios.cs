using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaRestaurant.Models.Clases
{
    public class OperacionesUsuarios
    {

        private RestaurantEntities1 entidad;

        public OperacionesUsuarios()
        {
            entidad = new RestaurantEntities1();
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


        public bool ExisteUsuario(string username,string password)
        {
            bool res = false;
            List<Usuarios> listaUsuarios = new List<Usuarios>();
            foreach (Usuarios users in entidad.Usuarios)
            {
                if (users.nombreUsuario==username && users.password==password)
                {
                    listaUsuarios.Add(users);
                }
            }
            if (listaUsuarios.Count==1)
            {
                res = true;
            }
            return res;
        }
    }
}