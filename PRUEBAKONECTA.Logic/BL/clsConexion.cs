using System.Configuration;

namespace PRUEBAKONECTA.Logic.BL
{
    public class clsConexion
    {
        /// <summary>
        /// OBTENGO LA CADENA DE CONEXION
        /// </summary>
        /// <returns> CADENA DE CONEXION</returns>
        public string getConexion() 
        {
            return ConfigurationManager.ConnectionStrings["Cnx"].ToString();
        }
    }
}
