using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaRestaurant.Models.Clases
{
    public class OperacionesProductos
    {
        private RestaurantEntities1 entidad;

        public OperacionesProductos()
        {
            entidad = new RestaurantEntities1();
        }

        public string Guardar(string nom, int price, int stock1)
        {
            string res = "false";
            try
            {
                Productos prod = new Productos(nom,price,stock1);
                entidad.Productos.Add(prod);
                entidad.SaveChanges();
                res = "true";
            }
            catch (Exception e)
            {
                res = e.Message;
            }
            return res;
        }


        public List<Productos> TraerTodo()
        {
            List<Productos> listaProductos = new List<Productos>();
            foreach (Productos prod in entidad.Productos)
            {
                listaProductos.Add(prod);
            }
            return listaProductos;
        }

        public Productos TraerPorId(int id)
        {
            Productos res=new Productos();
            foreach (Productos prod in entidad.Productos)
            {
                if (prod.idProducto==id)
                {
                    res = prod;
                }
            }
            return res;
        }
    }
}