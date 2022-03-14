using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace PRUEBAKONECTA.Controllers
{
    public class ProductosController
    {
        public DataSet getConsultarpProductos()
        {
            try
            {
                Logic.BL.clsProducto obclsProducto = new Logic.BL.clsProducto();
                return obclsProducto.getConsultarProductos();
            }
            catch (Exception ex) { throw ex; }
        }


        public string SetAdministrarProductosController(Logic.Models.clsProducto obclsProductoModels, int inOpcion)
        {
            try
            {
                Logic.BL.clsProducto obclsProducto = new Logic.BL.clsProducto();
                return obclsProducto.setAdministrarProductos(obclsProductoModels, inOpcion);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }


  


    }


}