<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditarArticulo.aspx.cs" Inherits="TiendaGrupo15Progra3.EditarArticulo" %>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <style>
            .bg-custom {
            background-image: url('images/fondoAmarillo.png');
            background-size: cover;
            background-position: center center;
            background-repeat: no-repeat;
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            z-index: -1;
        }

        .main-content {
            margin-top: 70px; 
        }

        .form-container {
            background-color: #fff; 
            padding: 20px;
            border-radius: 8px; 
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); 
            max-width: 600px; 
            margin: 0 auto; 
        }

        .row {
            display: flex;
            flex-direction: row;
            gap: 15px; 
            margin-bottom: 15px; 
        }

        .col {
            flex: 1;
        }

        .form-label {
            display: block;
            margin-bottom: 5px;
        }

        .form-control {
            width: 100%;
            padding: 8px;
            box-sizing: border-box;
            border: 1px solid #ccc;
            border-radius: 4px;
        }
        .padding-botom {
            padding-bottom: 100px;
        }

    .carousel-control-prev-icon, .carousel-control-next-icon 
        {
            background-color: black;  
        }
   </style>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-content padding-botom">
        <div class="center-container">
            <div class="form-container">
                <h1 class="header-custom">Modificar Artículo</h1>

                <div class="row">
                <div class="col">
                    <label for="CodigoArticuloText" class="form-label">Código Artículo:</label>
                    <asp:TextBox ID="CodigoArticuloTxt" CssClass="form-control" placeholder="Código Artículo" runat="server"></asp:TextBox>
                </div>
                <div class="col">
                    <label for="nombreArticuloTxt" class="form-label">Nombre Artículo:</label>
                    <asp:TextBox ID="nombreArtTxt" CssClass="form-control" placeholder="Nombre Artículo" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col">
                    <label for="Descripcion" class="form-label">Descripción:</label>
                    <asp:TextBox ID="DescripcionTxt" CssClass="form-control" placeholder="Descripción" runat="server"></asp:TextBox>
                </div>
                <div class="col">
                    <label for="MarcaText" class="form-label">Marca:</label>
                    <asp:TextBox ID="TxtMarca" CssClass="form-control" placeholder="Marca Nuevo Artículo" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col">
                    <label for="CategoriaTxt" class="form-label">Categoría:</label>
                    <asp:TextBox ID="TxtCategoria" CssClass="form-control" placeholder="Categoría" runat="server"></asp:TextBox>
                </div>
                <div class="col">
                    <label for="PrecioTxt" class="form-label">Precio:</label>
                    <asp:TextBox ID="PrecioTxt" type="text" pattern="^\d+([,\.]\d{1,2})?$" title="El precio debe tener un formato válido, por ejemplo, 1234,56" CssClass="form-control" placeholder="Precio" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col">
                    <label for="StockTxt" class="form-label">Stock:</label>
                    <asp:TextBox ID="txtStock" CssClass="form-control" placeholder="Stock" runat="server" />
                    <asp:RegularExpressionValidator 
                        ID="regexValidator" 
                        runat="server" 
                        ControlToValidate="txtStock"
                        ErrorMessage="El número debe tener un formato válido de números enteros." 
                        ValidationExpression="^\d+$" 
                        ForeColor="Red">
                    </asp:RegularExpressionValidator>
                </div>
            </div>


                <!-- Contenedor de Imágenes -->
                <div class="col-md-6">
                    <div class="mb-3">
                        <asp:Label ID="LblDropdawn" runat="server" Text="Seleccione la imagen que desea modificar:"></asp:Label>
                        <asp:DropDownList ID="ddlImagenes" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlImagenes_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <asp:Label ID="lblNuevaImagen" runat="server" Text="Ingrese la nueva Url de la imagen a modificar:"></asp:Label>
                    <asp:TextBox ID="txtModificarImagenUrl" runat="server" CssClass="form-control mb-3"/>
                    <div id="carouselExample" class="carousel slide" data-bs-ride="carousel">
                        <div class="carousel-inner">
                            <div class="carousel-item active">
                                <asp:Image ID="imgDefault" runat="server" CssClass="d-block w-100" ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png" />
                            </div>
                        </div>                       
                    </div>
                    <asp:Button ID="btnModificarImagen" runat="server" CssClass="btn btn-warning mt-2" Text="Modificar Imagen" OnClick="btnModificarImagen_Click" />
                    <asp:Label ID="lblMessage" runat="server" CssClass="mt-2"></asp:Label>
                </div>

                <div class="row">
                    <div class="form-group">
                        <asp:Button type="submit" ID="Button1" CssClass="btn btn-primary" runat="server" Text="Guardar Cambios" OnClick="btnGuardarCambios_Click" />
                    </div>
                    <h4><asp:Label ID="Label1" runat="server" CssClass="message"></asp:Label></h4>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

           
      


    
