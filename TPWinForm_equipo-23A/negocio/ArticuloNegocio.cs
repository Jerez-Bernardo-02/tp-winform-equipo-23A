using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using System.Data.SqlClient;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> Listar()
        {
            List<Articulo>lista = new List<Articulo>();
           
            SqlConnection coneccion = new SqlConnection("Server = .\\SQLEXPRESS; Initial Catalog = CATALOGO_P3_DB; Integrated Security = true");
            
            SqlCommand comando = new SqlCommand();
            comando.Connection = coneccion;
            comando.CommandText = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria FROM ARTICULOS A LEFT JOIN MARCAS M ON M.Id = A.IdMarca LEFT JOIN CATEGORIAS C ON C.Id = A.IdCategoria;";


            SqlDataReader lector;
            coneccion.Open();
            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Articulo articulo = new Articulo();
                articulo.Id = (int)lector["Id"];
                articulo.Codigo = (string)lector["Codigo"];
                articulo.Nombre = (string)lector["Nombre"];
                articulo.Descripcion = (string)lector["Descripcion"];
                articulo.Marca = new Marca();
                articulo.Marca.Descripcion = (string)lector["Marca"];
                articulo.Categoria = new Categoria();
                if (!(lector["Categoria"] is DBNull))
                    articulo.Categoria.Descripcion = (string)lector["Categoria"];

                lista.Add(articulo);
            }


            coneccion.Close();

            return lista;
        }
    }
}
