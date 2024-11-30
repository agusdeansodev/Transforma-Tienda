<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="TiendaGrupo15Progra3.DetalleProducto" EnableEventValidation="true" %>
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
            margin-top: 200px; 
            display: flex;
            justify-content: space-between;
            align-items: flex-start; 
            padding: 20px;
            min-height: calc(100vh - 120px); 
        }

        .carousel-container {
            width: 40%; /* 40% de la pantalla */
             margin: 0 auto;
        }

        .product-details-container {
            width: 40%; /* 30% de la pantalla */
            padding-left: 10px; /* Espacio entre el carrusel y los datos */
            border-left: 4px solid #ccc; /* Línea separadora */
        }

    
        .login-button {
            position: fixed;
            top: 80px; 
            right: 20px;
            cursor: pointer;
        }

        .login-button:hover {
            background-color: #e6b800; 
        }

        .carousel-control-prev-icon, .carousel-control-next-icon {
            background-color: black; 
        }

    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <% if(Rol == 0) { %>
    <div class="login-button">
        <asp:Button ID="BtnLoguearseDesdeDetalleProducto" runat="server" class="btn btn-warning btn-lg" Text="No está logueado, loguese aquí" OnClick="BtnLoguearseDesdeDetalleProducto_Click" />
    </div>
    <% } %>

    <div class="main-content">
        <!-- Carousel  -->
        <div class="carousel-container">
            <h2><%= articuloDetalle.Nombre %></h2>
            <div id="carousel<%= articuloDetalle.Id %>" class="carousel slide mb-3">
                <div class="carousel-inner">
                    <% for (int i = 0; i < articuloDetalle.Imagenes.Count; i++) { %>
                    <div class="carousel-item <%= i == 0 ? "active" : "" %>">
                        <img src="<%= articuloDetalle.Imagenes[i] %>" class="d-block w-100" alt="imagen" style="height: 250px; object-fit: contain; object-position: center;">
                    </div>
                    <% } %>
                </div>
                <!-- Controles de Carousel-->
                <button class="carousel-control-prev" type="button" data-bs-target="#carousel<%= articuloDetalle.Id %>" data-bs-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Anterior</span>
                </button>
                <button class="carousel-control-next" type="button" data-bs-target="#carousel<%= articuloDetalle.Id %>" data-bs-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Siguiente</span>
                </button>
            </div>
        </div>
       

        <div class="product-details-container">
            <h2>Descripciones adicionales:</h2>
            <ul>
                <li><h6><%= articuloDetalle.Descripcion %></h6></li>
                <li><h6>Marca: <%= articuloDetalle.Marca.ToString() %></h6></li>
                <li><h6>Categoria: <%= articuloDetalle.Categoria %></h6></li>
                <li><h6>Cantidad en Stock: <%= articuloDetalle.Stock %></h6></li>
                <li><h3>Precio:$<%= Math.Round(articuloDetalle.Precio, 2) %></h3></li>
            </ul>


            <% if (Rol == 1) { %>
            <div>
                <asp:Button ID="BtnEliminarProdAdmin" runat="server" class="btn btn-danger" Text="Eliminar Producto" OnClick="BtnEliminarProdAdmin_Click" />
            </div>
            <% } %>

            <% if (Rol != 0) { %>
            <div>
                <asp:DropDownList ID="DropDownListAgregarCarrito" runat="server"></asp:DropDownList>
                <asp:Button ID="BtnAgregarAlCarrito" runat="server" class="btn btn-success" Text="Agregar Producto al Carrito" OnClick="BtnAgregarAlCarrito_Click" />
            </div>
            <% } %>
        </div>
    </div>
</asp:Content>





