using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaRestaurant.Models.Clases
{
    public class OperacionesVentas
    {
        private RestaurantEntities1 entidad;

        public OperacionesVentas()
        {
            entidad = new RestaurantEntities1();
        }


        public string Guardar(int idUsuFK,int idProductoFK,DateTime fecha)
        {
            string res = "false";
            try
            {
                Ventas ventas = new Ventas();
                ventas.idUsuario = idUsuFK;
                ventas.idProducto = idProductoFK;
                ventas.fecha = fecha;
                entidad.Ventas.Add(ventas);
                entidad.SaveChanges();
                res = "true";
            }
            catch (Exception e)
            {
                res = e.Message;
            }
            return res;
        }


        public List<Ventas> TraerTodo()
        {
            List<Ventas> listaVentas = new List<Ventas>();
            foreach (Ventas prod in entidad.Ventas)
            {
                listaVentas.Add(prod);
            }
            return listaVentas;
        }
    }
}