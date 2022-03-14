using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace PRUEBAKONECTA.Logic.BL
{
    public class clsVenta
    {
        SqlConnection _SqlConnection = null;
        SqlCommand _SqlCommand = null;
        SqlDataAdapter _SqlDataAdapter = null;
        SqlParameter _SqlParameter = null;
        string stConexion = string.Empty;

        public clsVenta()
        {
            clsConexion obclsConexion = new clsConexion();
            stConexion = obclsConexion.getConexion();
        }


        public string setVentas(Models.clsVenta obclsVenta, int opcion)
        {
            try
            {


                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spVentas", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;
                _SqlCommand.Parameters.Add(new SqlParameter("@nID_Producto", obclsVenta.inIdProducto));
                _SqlCommand.Parameters.Add(new SqlParameter("@nValorVendido", obclsVenta.inCantidadProducto));
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
