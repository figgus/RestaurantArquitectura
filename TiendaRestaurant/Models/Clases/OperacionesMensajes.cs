using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaRestaurant.Models.Clases
{
    public class OperacionesMensajes { 
        private RestaurantEntities1 entidad;

        public OperacionesMensajes()
        {
            entidad = new RestaurantEntities1();
        }

        public string Guardar(string texto, string fecha1, string email)
        {
            string res = "false";
            try
            {
                Mensajes mensaje = new Mensajes(texto,fecha1,email);
                entidad.Mensajes.Add(mensaje);
                entidad.SaveChanges();
                res = "true";
            }
            catch (Exception e)
            {
                res = e.Message;
            }
            return res;
        }
    }
}