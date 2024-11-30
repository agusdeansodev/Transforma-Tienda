<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AgregarNuevoArticulo.aspx.cs" Inherits="TiendaGrupo15Progra3.AgregarNuevoArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            margin-top: 70px; /* Ajusta este valor según la altura de tu navbar */
        }

        .form-container {
            background-color: #fff; /* Fondo blanco para el formulario */
            padding: 20px;
            border-radius: 8px; /* Bordes redondeados */
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); /* Sombra ligera */
            max-width: 600px; /* Ancho máximo del formulario */
            margin: 0 auto; /* Centra horizontalmente */
        }

        .row {
            display: flex;
            flex-direction: row;
            gap: 15px; /* Espacio entre columnas */
            margin-bottom: 15px; /* Espacio entre filas */
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
        .padding-botom{
    padding-bottom: 100px;
}
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-content padding-botom">
        <div class="center-container">
            <div class="form-container">
                <h2><%=usuarioAgregarProducto.nombre %> <%=usuarioAgregarProducto.apellido %></h2>
                <h1 class="header-custom">Nuevo Artículo</h1>

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
                        <asp:TextBox ID="PrecioTxt" TextMode="Number" CssClass="form-control" placeholder="Precio" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col">
                        <label for="StockTxt" class="form-label">Stock:</label>
                        <asp:TextBox ID="txtStock" TextMode="Number" CssClass="form-control" placeholder="Stock" runat="server"></asp:TextBox>
                    </div>
                    <div class="col">
                        <label for="ImagenText" class="form-label">Agregar Imagen:</label>
                        <asp:TextBox ID="TxtAgregarImg" CssClass="form-control" placeholder="Agregar Img" runat="server"></asp:TextBox>
                        <asp:Label ID="LabelCantidadImagenesVender" runat="server" Text="Cantidad Imagenes"><%=listaImagenesGlobal.Count() %></asp:Label>
                        <asp:Button  ID="btnAgregarImagenUrl" CssClass="btn btn-secondary" runat="server" Text="Agregar Url de Imagen" Onclick="AgregarImagenUrl_Click" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Button type="submit" ID="AgregarProductoNuevo" CssClass="btn btn-primary" runat="server" Text="Agregar Producto" OnClick="AgregarProductoNuevo_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>


