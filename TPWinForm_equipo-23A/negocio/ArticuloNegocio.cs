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
            List<Articulo> lista = new List<Articulo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "Server = .\\SQLEXPRESS; Initial Catalog = CATALOGO_P3_DB; Integrated Security = true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, I.ImagenUrl AS UrlImagen, A.Precio FROM ARTICULOS A, MARCAS M, CATEGORIAS C, IMAGENES I WHERE M.Id = A.IdMarca AND C.Id = A.IdCategoria AND I.IdArticulo = A.Id";
                comando.Connection = conexion;

                conexion.Open();
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
                    articulo.Categoria.Descripcion = (string)lector["Categoria"];

                    articulo.Imagen = new List<Imagen>();
                    Imagen imagen = new Imagen();
                    imagen.UrlImagen = (string)lector["UrlImagen"];
                    articulo.Imagen.Add(imagen);

                    articulo.Precio = (decimal)lector["Precio"];

                    lista.Add(articulo);
                }


                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
}
    }
}
