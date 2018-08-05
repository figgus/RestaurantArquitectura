using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaRestaurant.Models.Clases
{
    public class OperacionesMensajes { 
        private RestaurantEntities2 entidad;

        public OperacionesMensajes()
        {
            entidad = new RestaurantEntities2();
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

        public bool Modificar(int id,string texto, string fecha1, string email)
        {
            bool res = false;
            try
            {
                Mensajes mensaje = entidad.Mensajes.FirstOrDefault(a=>a.idMensaje==id);
                mensaje.textoMensaje = texto;
                mensaje.fecha = fecha1;
                mensaje.emailRemitente = email;
                entidad.SaveChanges();
                res = true;
            }
            catch (Exception e)
            {
                res = false;
            }
            return res;
        }

        public bool Borrar(int id)
        {
            bool res = false;
            try
            {
                Mensajes mensaje;
                mensaje = entidad.Mensajes.FirstOrDefault(p=>p.idMensaje==id);
                entidad.Mensajes.Remove(mensaje);
                entidad.SaveChanges();
                res = true;
            }
            catch (Exception e)
            {
                res = false;
            }
            return res;
        }


        public List<Mensajes> TraerTodo()
        {
            List<Mensajes> listaMensajes = new List<Mensajes>();
            foreach (Mensajes prod in entidad.Mensajes)
            {
                listaMensajes.Add(prod);
            }
            return listaMensajes;
        }



    }
}