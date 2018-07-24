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