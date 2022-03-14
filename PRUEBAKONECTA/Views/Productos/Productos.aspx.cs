using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace PRUEBAKONECTA.Views.Productos
{
    public partial class Productos : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                try
                {
                    txtIdProducto.Enabled = true;
                    getProductos();
                }
                catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> alert('" + ex.Message + "!') </script>"); }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    string stMensaje = string.Empty;
                    //if (string.IsNullOrEmpty(txtIdProducto.Text)) stMensaje += "Ingrese Id Producto";
                    if (!string.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));
                    if (string.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";
                    Logic.Models.clsProducto obclsProducto = new Logic.Models.clsProducto { };
                    if (lblOpcion.Text.Equals("1"))
                    {
                        obclsProducto = new Logic.Models.clsProducto
                        {
                            inIdProducto = null,
                            stNombreProducto = txtNombreProducto.Text,
                            stReferenciaProducto = txtReferenciaProducto.Text,
                            inPrecioProducto = Convert.ToInt32(txtPrecioProducto.Text),
                            inPesoProducto = Convert.ToInt32(txtPesoProducto.Text),
                            stCategoriaProducto = txtCategoriaProducto.Text,
                            stStockProducto = txtStockProducto.Text

                        };
                    }
                    else
                    {
                        obclsProducto = new Logic.Models.clsProducto
                        {
                            inIdProducto = Convert.ToInt32(txtIdProducto.Text),
                            stNombreProducto = txtNombreProducto.Text,
                            stReferenciaProducto = txtReferenciaProducto.Text,
                            inPrecioProducto = Convert.ToInt32(txtPrecioProducto.Text),
                            inPesoProducto = Convert.ToInt32(txtPesoProducto.Text),
                            stCategoriaProducto = txtCategoriaProducto.Text,
                            stStockProducto = txtStockProducto.Text

                        };
                    }
                    

                    Controllers.ProductosController obProductosController = new Controllers.ProductosController();

                    
                    limpiarControles();
                    ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> alert('" + obProductosController.SetAdministrarProductosController(obclsProducto, Convert.ToInt32(lblOpcion.Text)) + "!') </script>");
                    //obProductosController.SetAdministrarProductosController(obclsProducto, Convert.ToInt32(lblOpcion.Text));
                    //ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> alert('Se ingreso el producto satisfactoriamente') </script>");
                    
                    lblOpcion.Text = String.Empty;

                    getProductos();

                    // ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> alert('Error!', '" + ex.Message + "!', 'error') </script>");
                    //}
                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> alert('" + ex.Message + "!') </script>");


            }
        }

        protected void gvwDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int inIndice = Convert.ToInt32(e.CommandArgument);

                if (e.CommandName.Equals("Editar"))
                {
                    txtIdProducto.Enabled = false;
                    lblOpcion.Text = "2";
                    txtIdProducto.Text = ((Label)gvwDatos.Rows[inIndice].FindControl("lblIdProducto")).Text;
                    txtNombreProducto.Text = gvwDatos.Rows[inIndice].Cells[1].Text.Equals("&nbsp;") ? string.Empty : gvwDatos.Rows[inIndice].Cells[1].Text;
                    txtReferenciaProducto.Text = gvwDatos.Rows[inIndice].Cells[2].Text.Equals("&nbsp;") ? string.Empty : gvwDatos.Rows[inIndice].Cells[2].Text;
                    txtPrecioProducto.Text = gvwDatos.Rows[inIndice].Cells[3].Text.Equals("&nbsp;") ? string.Empty : gvwDatos.Rows[inIndice].Cells[3].Text;
                    txtPesoProducto.Text = gvwDatos.Rows[inIndice].Cells[4].Text.Equals("&nbsp;") ? string.Empty : gvwDatos.Rows[inIndice].Cells[4].Text;
                    txtCategoriaProducto.Text = gvwDatos.Rows[inIndice].Cells[5].Text.Equals("&nbsp;") ? string.Empty : gvwDatos.Rows[inIndice].Cells[5].Text;
                    txtStockProducto.Text = gvwDatos.Rows[inIndice].Cells[6].Text.Equals("&nbsp;") ? string.Empty : gvwDatos.Rows[inIndice].Cells[6].Text;



                    getProductos();


                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                    lblOpcion.Text = "3";

                    // if (!string.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));

                    Logic.Models.clsProducto obclsProducto = new Logic.Models.clsProducto
                    {

                        inIdProducto = Convert.ToInt32(((Label)gvwDatos.Rows[inIndice].FindControl("lblIdProducto")).Text),
                        stNombreProducto = string.Empty,
                        stReferenciaProducto = string.Empty,
                        inPesoProducto = 0,
                        inPrecioProducto = 0,
                        stCategoriaProducto = string.Empty,
                        stStockProducto = string.Empty


                    };

                    Controllers.ProductosController obProductosController = new Controllers.ProductosController();
                    ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> alert('" + obProductosController.SetAdministrarProductosController(obclsProducto, Convert.ToInt32(lblOpcion.Text)) + "!') </script>");
                    obProductosController.SetAdministrarProductosController(obclsProducto, Convert.ToInt32(lblOpcion.Text));
                    //ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> alert('Se elimino el producto seleccionado') </script>");
                    
                    lblOpcion.Text = String.Empty;
                    getProductos();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> alert('" + ex.Message + "!') </script>");
            }
        }

        protected bool Validar()
        {
            if (/*txtIdProducto.Text.Equals(string.Empty) ||*/ txtNombreProducto.Text.Equals(string.Empty) || txtReferenciaProducto.Text.Equals(string.Empty) || txtPrecioProducto.Text.Equals(string.Empty) || txtPesoProducto.Text.Equals(string.Empty) || txtCategoriaProducto.Text.Equals(string.Empty) || txtStockProducto.Text.Equals(string.Empty))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> alert('Debe ingresar todos los campos') </script>");
                return false;
            }
            //else if (Convert.ToInt32(txtIdProducto.Text) <= 0)
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> alert('El id del producto debe ser mayor a cero') </script>");
            //    return false;
            //}
            else if (Convert.ToInt32(txtPrecioProducto.Text) <= 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> alert('El precio del producto debe ser mayor a cero') </script>");
                return false;
            }
            else if (Convert.ToInt32(txtPesoProducto.Text) <= 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> alert('El peso del producto debe ser mayor a cero') </script>");
                return false;
            }
            else if (Convert.ToInt32(txtStockProducto.Text) <= 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> alert('El stock del producto debe ser mayor a cero') </script>");
                return false;
            }
            return true;
        }

        protected void limpiarControles()
        {
            txtIdProducto.Text = string.Empty;
            txtNombreProducto.Text = string.Empty;
            txtReferenciaProducto.Text = string.Empty;
            txtPrecioProducto.Text = string.Empty;
            txtPesoProducto.Text = string.Empty;
            txtCategoriaProducto.Text = string.Empty;
            txtStockProducto.Text = string.Empty;
            txtIdProducto.Enabled = true;
        }
    }
}


