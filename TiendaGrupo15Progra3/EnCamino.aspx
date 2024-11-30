<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"  EnableEventValidation="false" CodeBehind="EnCamino.aspx.cs" Inherits="TiendaGrupo15Progra3.EnCamino" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style>
    .cart-table {
        width: 100%;
        margin-top: 20px;
        border-collapse: collapse;
    }

    .cart-table th, .cart-table td {
        padding: 15px;
        text-align: center;
        border: 1px solid #ddd;
    }

    .cart-table th {
        background-color:lightslategrey;
    }

    .cart-total {
        font-size: 1.5rem;
        margin-top: 20px;
        text-align: right;
    }

    .btn-update, .btn-remove {
        background-color: black;
        color: yellow;
        border: none;
        padding: 8px 16px;
        cursor: pointer;
        border-radius: 5px;
    }

    .btn-update:hover, .btn-remove:hover {
        background-color: darkgray;
    }

    .btn-checkout {
        background-color: #ffd700;
        color: black;
        font-size: 1.5rem;
        padding: 15px 30px;
        border: none;
        cursor: pointer;
        border-radius: 5px;
    }

    .btn-checkout:hover {
        background-color: #ffcc00;
    }
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
                margin-top: 100px; /* Ajusta este valor según la altura de tu navbar */

}
                .paraTabla{
                color:whitesmoke;
                background-color:#1a1a1a;
                border-color:black;
                }
            .padding-botom{
                padding-bottom: 100px;
            }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg-custom"></div>
    <div class="main-content">
    
    <div class="container">
    <h2>Tus productos en proceso de venta</h2>
    <table class="cart-table">
        <thead class="paraTabla">
            <tr>
                <th>Producto</th>
                <th>Categoria</th>                
                <th>Marca</th>
                <th>Precio</th>
                <th>Cantidad Encargada</th>
                <th>Mail Comprador</th>
                <th>Telefono Comprador</th>
                <th>Stock Restante</th>
                <th>Monto Total</th> 
                <th>Marcar como entregado</th>
                <th>Entregado</th>

            </tr>
        </thead>
        <tbody class="paraTabla">
            <!-- Repeater para mostrar productos en el carrito -->
            <asp:Repeater ID="RepeaterEnProcesoVendidos" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("producto") %></td>
                        <td><%# Eval("categoria") %></td>
                        <td><%# Eval("marca") %></td>
                        <td>$<%# Eval("precio") %></td>
                        <td><%# Eval("cantidad") %></td>
                        <td><%# Eval("correo") %></td>
                        <td><%# Eval("telefono") %></td>
                        <td><%# Eval("Stock") %></td>
                        <td>$<%# Eval("Total") %></td>   
                          <td>    
                           <asp:Button ID="BTNEnProcesoVendidos" runat="server" Text="Entregar" CommandArgument='<%# Eval("idVenta") %>' OnClick="BTNEnProcesoVendidosEliminar_Click"/>
                            </td>
                        <td><%# (Convert.ToBoolean(Eval("EnCamino")) == true  ? "SI" : "NO") %> </td> 
                                               
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</div>

    
<div class="container padding-botom">
 <h2>Tus productos en proceso de compra</h2>
<table class="cart-table">
    <thead class="paraTabla">
        <tr>
            <th>Producto</th>
            <th>Categoria</th>                
            <th>Marca</th>
            <th>Precio</th>
            <th>Cantidad Comprada</th>
            <th>Mail Vendedor</th>
            <th>Telefono Vendedor</th>
            <th>Stock Restante</th>
            <th>Monto Total</th>     
            <th>Marcar como recibido</th> 
            <th>Recibido</th> 

        </tr>
    </thead>
    <tbody class="paraTabla">
        <!-- Repeater para mostrar productos en el carrito -->
        <asp:Repeater ID="RepeaterEnProcesoComprados" runat="server">
            <ItemTemplate>
                <tr>
                    <td><%# Eval("producto") %></td>
                    <td><%# Eval("categoria") %></td>
                    <td><%# Eval("marca") %></td>
                    <td>$<%# Eval("precio") %></td>
                    <td><%# Eval("cantidad") %></td>
                    <td><%# Eval("correo") %></td>
                    <td><%# Eval("telefono") %></td>
                    <td><%# Eval("Stock") %></td>
                    <td>$<%# Eval("Total") %></td>                       
                    <td>    
                    <asp:Button ID="BTNEnProcesoComprados" runat="server" Text="Recibir" CommandArgument='<%# Eval("idVenta") %>' OnClick="BTNEnProcesoComprados_Click" />
                    </td>
                     <td><%# (Convert.ToBoolean(Eval("EnCamino")) == true  ? "SI" : "NO") %> </td>                   
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </tbody>
</table>

    </div>
        </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
