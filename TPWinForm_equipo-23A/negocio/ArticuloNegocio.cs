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
           
            SqlConnection coneccion = new SqlConnection("Server=.\\SQLEXPRESS; Initial Catalog=CATALOGO_P3_DB;Integrated Security=true");
            
            SqlCommand comando = new SqlCommand();
            comando.Connection = coneccion;
            comando.CommandText = "select A.id,codigo,nombre,A.descripcion,M.Descripcion as Marca,C.Descripcion as Categoria from ARTICULOS A, MARCAS M, CATEGORIAS C where M.Id = A.IdMarca and C.Id = A.IdCategoria";


            SqlDataReader lector;
            coneccion.Open();
            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Articulo articulo = new Articulo();
                articulo.Id = (int) lector["Id"];
                articulo.Codigo = (string) lector["Codigo"];
                articulo.Nombre = (string)lector["Nombre"];
                articulo.Descripcion = (string)lector["Descripcion"];
                articulo.Marca = new Marca();
                articulo.Marca.Descripcion = (string)lector["Marca"];
                articulo.Categoria = new Categoria();
                articulo.Categoria.Descripcion = (string)lector["Categoria"];

                lista.Add(articulo);
            }

            coneccion.Close();

            return lista;
        }
    }
}
