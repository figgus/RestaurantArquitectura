using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaRestaurant.Models.Clases
{
    public class GridTables
    {
        public int idProducto { get; set; }
        public string nombreProducto { get; set; }
        public Nullable<int> precio { get; set; }
        public Nullable<int> stock { get; set; }
        public product producto { get; set; }
        public user usuario { get; set; }
        public noticia noti { get; set; }



        //public Productos producto { get; set; }
        //public Usuarios users { get; set; }



        public class product
        {
            public int idProducto { get; set; }
            public string nombreProducto { get; set; }
            public Nullable<int> precio { get; set; }
            public Nullable<int> stock { get; set; }
        }


        public class user
        {
            public int idUsuario { get; set; }
            public string nombreUsuario { get; set; }
            public string password { get; set; }
            public string pnombre { get; set; }
            public string snombre { get; set; }
            public string apat { get; set; }
            public string amat { get; set; }
            public System.DateTime fechaRegistro { get; set; }
            public int tipoUsuario { get; set; }
            public string email { get; set; }
        }

        public class noticia
        {
            public noticia()
            {
            }

            public int idNoticia { get; set; }
            public Nullable<System.DateTime> FechaNoticia { get; set; }
            public string textoNoticia { get; set; }
            public int idAutor { get; set; }
        }

            
    }
}