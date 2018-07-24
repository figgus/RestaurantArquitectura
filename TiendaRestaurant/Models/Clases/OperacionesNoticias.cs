using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaRestaurant.Models.Clases
{
    public class OperacionesNoticias
    {
        private RestaurantEntities1 entidad;

        public OperacionesNoticias()
        {
            entidad = new RestaurantEntities1();
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