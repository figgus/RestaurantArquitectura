using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaRestaurant.Models.Clases
{
    public class OperacionesTablas
    {
        private RestaurantEntities1 entidad;

        public OperacionesTablas()
        {
            entidad = new RestaurantEntities1();
        }

        public List<Tablas> TraerTodo()
        {
            List<Tablas> listaTablas = new List<Tablas>();
            foreach (Tablas prod in entidad.Tablas)
            {
                listaTablas.Add(prod);
            }
            return listaTablas;
        }
    }
}