using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaRestaurant.Models.Clases
{
    public class OperacionesProductos
    {
        private RestaurantEntities2 entidad;

        public OperacionesProductos()
        {
            entidad = new RestaurantEntities2();
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

        public bool Modificar(int id, string nom, int price, int stock1)
        {
            bool res = false;
            try
            {
                Productos noti = entidad.Productos.FirstOrDefault(a => a.idProducto == id);
                noti.nombreProducto = nom;
                noti.precio = price;
                noti.stock = stock1;
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
                Productos prod;
                prod = entidad.Productos.FirstOrDefault(p => p.idProducto == id);
                entidad.Productos.Remove(prod);
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