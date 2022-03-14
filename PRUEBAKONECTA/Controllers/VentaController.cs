using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRUEBAKONECTA.Controllers
{
    public class VentaController
    {


        public string setVentas(Logic.Models.clsVenta obclsVentaModels, int inOpcion)
        {
            try
            {
                Logic.BL.clsVenta obclsVenta = new Logic.BL.clsVenta();
                return obclsVenta.setVentas(obclsVentaModels, inOpcion);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}