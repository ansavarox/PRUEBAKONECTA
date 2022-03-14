using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;


namespace PRUEBAKONECTA.Logic.BL
{

    public class clsProducto
    {
        SqlConnection _SqlConnection = null;
        SqlCommand _SqlCommand = null;
        SqlDataAdapter _SqlDataAdapter = null;
        SqlParameter _SqlParameter = null;
        string stConexion = string.Empty;

        public clsProducto()
        {
            clsConexion obclsConexion = new clsConexion();
            stConexion = obclsConexion.getConexion();
        }
        /// <summary>
        /// CONSULTA LOS PRODUCTOS
        /// </summary>
        /// <returns>REGISTROS DE LA TABLA PRODUCTOS </returns>
        public DataSet getConsultarProductos()
        {
            try
            {
                DataSet dsConsulta = new DataSet();

                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spConsultarProductos", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;

                _SqlCommand.ExecuteNonQuery();

                _SqlDataAdapter = new SqlDataAdapter(_SqlCommand);
                _SqlDataAdapter.Fill(dsConsulta);

                return dsConsulta;
            }
            catch (Exception ex) { throw ex; }
            finally { _SqlConnection.Close(); }

        }


        public string setAdministrarProductos(Models.clsProducto obclsProducto, int opcion)
        {
            try
            {

                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spAdministrarProductos", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;
                _SqlCommand.Parameters.Add(new SqlParameter("@nID_Producto", obclsProducto.inIdProducto));
                _SqlCommand.Parameters.Add(new SqlParameter("@cNombre_Producto", obclsProducto.stNombreProducto));
                _SqlCommand.Parameters.Add(new SqlParameter("@cRerefencia_Producto", obclsProducto.stReferenciaProducto));
                _SqlCommand.Parameters.Add(new SqlParameter("@cPrecio_Producto", obclsProducto.inPrecioProducto));
                _SqlCommand.Parameters.Add(new SqlParameter("@cPeso_Producto", obclsProducto.inPesoProducto));
                _SqlCommand.Parameters.Add(new SqlParameter("@cCategoria_Producto", obclsProducto.stCategoriaProducto));
                _SqlCommand.Parameters.Add(new SqlParameter("@cStock_Producto", obclsProducto.stStockProducto));
                _SqlCommand.Parameters.Add(new SqlParameter("@nOpcion", opcion));



                _SqlParameter = new SqlParameter();
                _SqlParameter.ParameterName = "@cMensaje";
                _SqlParameter.Direction = ParameterDirection.Output;
                _SqlParameter.SqlDbType = SqlDbType.VarChar;
                _SqlParameter.Size = 50;

                _SqlCommand.Parameters.Add(_SqlParameter);
                _SqlCommand.ExecuteNonQuery();

                return _SqlParameter.Value.ToString();


            }
            catch (Exception ex) { throw ex; }
            finally { _SqlConnection.Close(); }

        }

    }
}
