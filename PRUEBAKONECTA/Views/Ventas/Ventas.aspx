<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template/Template.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="PRUEBAKONECTA.Views.Productos.Ventas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenedor" runat="server">
    <div class="mx-auto mt-5" style="padding-left: 50px">

        <div class="form-group">
            <div class="col-md-12">
                <asp:Label runat="server" ID="Label1" Text="Ventas"></asp:Label>
                <asp:Label runat="server" ID="lblOpcion" Visible="false"></asp:Label>

            </div>
        </div>

        <div class="form-group">
            <div class="form-row">
                <div class="col-md-4">
                    <asp:Label runat="server" ID="lblProducto" Text="Producto:"></asp:Label>
                    <asp:DropDownList runat="server" ID="cbProducto" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-md-4">
                    <asp:Label runat="server" ID="lblCantidadProducto" Text="Cantidad a comprar:"></asp:Label>
                    <asp:TextBox runat="server" ID="txtCantidadProducto" CssClass="form-control" TextMode="Number" placeholder="Ingrese la cantidad a comprar"></asp:TextBox>
                </div>
            </div>
        </div>
        <br />
        <div class="form-group">
            <div class="col-md-12">
                <asp:Button runat="server" ID="btnGuardar" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" CssClass="btn btn-primary" PostBackUrl="~/Views/Index/Index.aspx" />
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-12">
                <asp:Label runat="server" ID="lblSubtitulo" Text="Resultado"></asp:Label>
            </div>
        </div>

        <div class="form-group">
            <div class="form-row">
                <div class="col-md-12" style="overflow: auto">
                    <asp:GridView runat="server" ID="gvwDatos" Width="100%"
                        AutoGenerateColumns="False"
                        EmptyDataText="No hay registros"
                        BackColor="Red"
                        BorderColor="#999999"
                        BorderStyle="None"
                        BorderWidth="1px"
                        CellPadding="3"
                        GridLines="Vertical"
                        >
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <Columns>
                            <asp:TemplateField HeaderText="ID Producto">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblIdProducto" Text='<%# Bind("ID_PRODUCTO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- REPRESENTACION DE DATOS EN CELDAS --%>

                            <%-- <asp:BoundField HeaderText="Id Producto" DataField="ID_PRODUCTO" />--%>
                            <asp:BoundField HeaderText="Nombre Producto" DataField="NOMBRE_PRODUCTO" />
                            <asp:BoundField HeaderText="Referencia Producto" DataField="REFERENCIA_PRODUCTO" />
                            <asp:BoundField HeaderText="Precio Producto" DataField="PRECIO_PRODUCTO" />
                            <asp:BoundField HeaderText="Peso Producto" DataField="PESO_PRODUCTO" />
                            <asp:BoundField HeaderText="Categoria Producto" DataField="CATEGORIA_PRODUCTO" />
                            <asp:BoundField HeaderText="Stock Producto" DataField="STOCK_PRODUCTO" />
                            <asp:BoundField HeaderText="Fecha creacion producto" DataField="FECHA_CREACION_PRODUCTO" />

                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#000065" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
