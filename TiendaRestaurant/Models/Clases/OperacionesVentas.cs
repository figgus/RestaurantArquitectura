using System;
using System.Collections.Generic;
using System.Linq;

namespace TiendaRestaurant.Models.Clases
{
    public class OperacionesVentas
    {
        private RestaurantEntities2 entidad;

        public OperacionesVentas()
        {
            entidad = new RestaurantEntities2();
        }

        public string Borrar(int id)
        {
            string res = "false";
            try
            {
                Ventas ventas;
                ventas = entidad.Ventas.FirstOrDefault(p => p.idVenta == id);
                entidad.Ventas.Remove(ventas);
                entidad.SaveChanges();
                res = "true";
            }
            catch (Exception e)
            {
                res = e.Message;
            }
            return res;
        }

        public bool Modificar(int id, int idUsuFK, int idProductoFK, DateTime fecha)
        {
            bool res = false;
            try
            {
                Ventas noti = entidad.Ventas.FirstOrDefault(a => a.idVenta == id);
                noti.idUsuario = idUsuFK;
                noti.idProducto = idProductoFK;
                noti.fecha = fecha;
                entidad.SaveChanges();
                res = true;
            }
            catch (Exception e)
            {
                res = false;
            }
            return res;
        }


        public bool Guardar(int idUsuFK,int idProductoFK,DateTime fecha)
        {
            bool res = false;
            try
            {
                Ventas ventas = new Ventas();
                ventas.idUsuario = idUsuFK;
                ventas.idProducto = idProductoFK;
                ventas.fecha = fecha;
                entidad.Ventas.Add(ventas);
                entidad.SaveChanges();
                res = true;
            }
            catch (Exception e)
            {
                res = false;
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