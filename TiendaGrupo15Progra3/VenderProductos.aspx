<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="VenderProductos.aspx.cs" Inherits="TiendaGrupo15Progra3.VenderProductos" %>
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
            margin-top: 70px; 
        }
        .btn-card {
            border: none;
            box-shadow: 0 4px 8px rgba(0,0,0,0.1);
            transition: transform 0.2s;
        }
        
        .btn-card:hover {
            transform: scale(1.05);
            box-shadow: 0 8px 16px rgba(0,0,0,0.2);
        }

        .btn-card img {
            width: 100%;
            height: auto;
            object-fit: cover;
            border-radius: 0.25rem;
        }

        .card-container {
            margin-top: 100px; 
        }

        .card {
            margin: 10px; 
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-center flex-wrap card-container">
        <!-- Card 1 -->
        <div class="card text-center" style="width: 18rem;">
            <div class="card-body">
                <asp:ImageButton ID="IMGagregarProducto" runat="server" ImageUrl="~/images/AgregarArticulo.png" CssClass="btn btn-card img-fluid" alt="Agregar Articulo" OnClick="IMGagregarProducto_Click"/>
                <h5 class="card-title mt-3">Agregar articulo</h5>
                <p class="card-text">Aqui puedes agregar tus nuevos productos</p>
            </div>
        </div>

        <!-- Card 2 -->
        <div class="card text-center" style="width: 18rem;">
            <div class="card-body">
                <asp:ImageButton ID="IMGactualizarArticulo" runat="server" ImageUrl="~/images/actualizarArticulo.png" CssClass="btn btn-card img-fluid" alt="Actualizar Articulo" OnClick="IMGactualizarArticulo_Click"/>
                <h5 class="card-title mt-3">Actualizar Articulo</h5>
                <p class="card-text">Aqui podras actualizar las caracteristicas de tu producto, agregar nuevas imagenes y mucho mas!</p>
            </div>
        </div>

        <!-- Card 3 -->
        <div class="card text-center" style="width: 18rem;">
            <div class="card-body">
                <asp:ImageButton ID="IMGeliminarArticulo" runat="server" ImageUrl="~/images/eliminarArticulo.png" CssClass="btn btn-card img-fluid" alt="Eliminar Articulo" OnClick="IMGeliminarArticulo_Click"/>
                <h5 class="card-title mt-3">Eliminar Articulo</h5>
                <p class="card-text">Para aquellos productos que no quieras seguir teniendo en tu inventario.</p>
            </div>
        </div>
    </div>
</asp:Content>

