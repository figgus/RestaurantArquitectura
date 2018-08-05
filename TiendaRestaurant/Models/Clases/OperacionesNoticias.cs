using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaRestaurant.Models.Clases
{
    public class OperacionesNoticias
    {
        private RestaurantEntities2 entidad;

        public OperacionesNoticias()
        {
            entidad = new RestaurantEntities2();
        }

        public string Guardar(DateTime fecha, string texto, int idAutor)
        {
            string res = "false";
            try
            {
                Noticias mensaje = new Noticias(fecha, texto, idAutor);
                entidad.Noticias.Add(mensaje);
                entidad.SaveChanges();
                res = "true";
            }
            catch (Exception e)
            {
                res = e.Message;
            }
            return res;
        }

        public bool Modificar(int id, DateTime fecha, string texto, int idAutorl)
        {
            bool res = false;
            try
            {
                Noticias noti = entidad.Noticias.FirstOrDefault(a => a.idNoticia == id);
                noti.FechaNoticia = fecha;
                noti.textoNoticia = texto;
                noti.idAutor = idAutorl;
                entidad.SaveChanges();
                res = true;
            }
            catch (Exception e)
            {
                res = false;
            }
            return res;
        }

        public string Borrar(int id)
        {
            string res = "false";
            try
            {
                Noticias noti;
                noti = entidad.Noticias.FirstOrDefault(p => p.idNoticia == id);
                entidad.Noticias.Remove(noti);
                entidad.SaveChanges();
                res = "true";
            }
            catch (Exception e)
            {
                res = e.Message;
            }
            return res;
        }

        public List<Noticias> TraerTodo()
        {
            List<Noticias> listaNoticias = new List<Noticias>();
            foreach (Noticias prod in entidad.Noticias)
            {
                listaNoticias.Add(prod);
            }
            return listaNoticias;
        }
    }
}