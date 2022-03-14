using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRUEBAKONECTA.Views.Productos
{
    public partial class Ventas : System.Web.UI.Page
    {
        void getProductos()
        {
            Controllers.ProductosController obProductosController = new Controllers.ProductosController();
            DataSet dsConsulta = obProductosController.getConsultarpProductos();

            if (dsConsulta.Tables[0].Rows.Count > 0)
            {
                gvwDatos.DataSource = dsConsulta;
                gvwDatos.DataBind();
            }
            else
            {
                gvwDatos.DataSource = null;
            }
        }
            protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    getProductos();
                    Controllers.ProductosController obProductosController = new Controllers.ProductosController();
                    DataSet dsConsulta = obProductosController.getConsultarpProductos();

                    if (dsConsulta.Tables[0].Rows.Count > 0)
                    {
                        cbProducto.DataSource = dsConsulta;
                        cbProducto.DataTextField = "NOMBRE_PRODUCTO";
                        cbProducto.DataValueField = "ID_PRODUCTO";
                        cbProducto.DataBind();
                        cbProducto.Items.Add(new ListItem("Seleccione el producto", "-1"));
                        cbProducto.Items.FindByValue("-1").Selected = true;
                    }
                    else
                    {
                        cbProducto.DataSource = null;
                    }
                }
                catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> alert('" + ex.Message + "!') </script>"); }
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                string stMensaje = string.Empty;
                if (!string.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));

                Logic.Models.clsVenta obclsVenta = new Logic.Models.clsVenta
                {
                    inIdProducto = Convert.ToInt32(cbProducto.SelectedValue),
                    inCantidadProducto = Convert.ToInt32(txtCantidadProducto.Text)
                   

                };

                Controllers.VentaController obVentaController = new Controllers.VentaController();

                if (string.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> alert('" + obVentaController.setVentas(obclsVenta, Convert.ToInt32(lblOpcion.Text)) + "!') </script>");
                limpiarControles();
                getProductos();
                //ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> alert('Producto vendido') </script>");
                //lblOpcion.Text = String.Empty;

                // getProductos();

                //ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> alert('" + obVentaController.setVentas(obclsVenta, Convert.ToInt32(lblOpcion.Text)) + "!') </script>");




            }
            else 
            {

            }
        }
        /// <summary>
        /// Metodo para validacion de campos vacios y valores que no se deben ingresar a la base de datos
        /// </summary>
        /// <returns>valor en boolean</returns>
        protected bool Validar()
        {
            if (cbProducto.SelectedValue.Equals("-1"))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> alert('Debe seleccionar al menos un producto') </script>");
                return false;
            }
            if (txtCantidadProducto.Text.Equals(string.Empty))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> alert('Debe ingresar la cantidad a llevar') </script>");

                return false;
            }
            else if (Convert.ToInt32(txtCantidadProducto.Text) <= 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> alert('La cantidad a llevar debe ser mayor a cero') </script>");
                return false;
            }
            return true;
        }
        protected void limpiarControles()
        {
            txtCantidadProducto.Text = String.Empty;
            Page_Load(null, null);
        }
    }
}