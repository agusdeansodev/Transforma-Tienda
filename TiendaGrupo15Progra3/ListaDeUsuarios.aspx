<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListaDeUsuarios.aspx.cs" Inherits="TiendaGrupo15Progra3.ListaDeUsuarios"  EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" >

    <!-- Bootstrap CSS -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet">
<!-- jQuery -->
<script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
<!-- Bootstrap JS -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>

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
    background-color: lightslategrey;
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
    .paraTabla{
    color:whitesmoke;
    background-color:#1a1a1a;
    border-color:black;
}

    .btn-checkout:hover {
        background-color: #ffcc00;
    }
        .main-content { 
                margin-top: 100px; /* Ajusta este valor según la altura de tu navbar */

}
        .padding-botom{
    padding-bottom: 100px;
}
        
        </style>
 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg-custom"></div>
    <div class="main-content padding-botom">
      

        <div class="container">  
            <h2>Lista de usuarios del Market Place con acceso</h2>
            <table class="cart-table">
                <thead class="paraTabla">
                    <tr>
                        <th>Nombre</th>
                        <th>Apellido</th>
                        <th>Nombre de usuario</th>
                        <th>Correo</th>
                        <th>Teléfono</th>
                        <th>Rol</th>
                        <th>Fecha de registro</th>
                        <th>Acciones</th> <!-- Nueva columna -->
                    </tr>
                </thead>
                <tbody class="paraTabla">
                    <asp:Repeater ID="RepeaterUsuarios" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("nombre") %></td>
                                <td><%# Eval("apellido") %></td>
                                <td><%# Eval("nombreUsuario") %></td>
                                <td><%# Eval("correo") %></td>
                                <td><%# Eval("telefono") %></td>
                                <td>
                                 <%# Eval("rol").ToString() == "1" ? "Administrador" : (Eval("rol").ToString() == "2" ? "Usuario" : "Dueño") %>
                                </td>
                                <td><%# Eval("fechaRegistro") %></td>
                                
                                   <td>
    <!-- Botón Modificar -->
    <asp:Button ID="btnAbrirModalModificar" runat="server" Text="Modificar Rol" CssClass="btn-update" target="_blank" CommandName="Modificar" CommandArgument='<%# Eval("idUsuario") %>' OnClick="btnAbrirModalModificar_Click" />
    <!-- Botón Eliminar -->
    <asp:Button ID="btnEliminarUsuario" runat="server" Text="Eliminar" CssClass="btn-remove" CommandArgument='<%# Eval("idUsuario") %>' OnClick="btnEliminarUsuario_Click" />
</td>

                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
        <div class="main-content padding-botom">
      

        <div class="container">  
            <h2>Lista de usuarios del Market Place con acceso restringido</h2>
            <table class="cart-table">
                <thead class="paraTabla">
                    <tr>
                        <th>Nombre</th>
                        <th>Apellido</th>
                        <th>Nombre de usuario</th>
                        <th>Correo</th>
                        <th>Teléfono</th>
                        <th>Rol</th>
                        <th>Fecha de registro</th>
                        <th>Acciones</th> <!-- Nueva columna -->
                    </tr>
                </thead>
                <tbody class="paraTabla">
                    <asp:Repeater ID="RepeaterUsuariosBaja" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("nombre") %></td>
                                <td><%# Eval("apellido") %></td>
                                <td><%# Eval("nombreUsuario") %></td>
                                <td><%# Eval("correo") %></td>
                                <td><%# Eval("telefono") %></td>
                                <td>
                                 <%# Eval("rol").ToString() == "1" ? "Administrador" : (Eval("rol").ToString() == "2" ? "Usuario" : "Dueño") %>
                                </td>
                                <td><%# Eval("fechaRegistro") %></td>
                                
                                   <td>
    <!-- Botón Modificar -->
    <asp:Button ID="btnDarAltaUsuario" runat="server" Text="Permitir Acceso" CssClass="btn-update" target="_blank" CommandName="Modificar" CommandArgument='<%# Eval("idUsuario") %>' OnClick="btnDarAltaUsuario_Click" />
    
</td>

                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>

    <!-- Modal para modificar usuario -->
    <div class="container">
        <div class="modal fade" id="ModalUsuarios" role="dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4>Modal</h4>

                </div>
                <div class="modal-body">



                </div>
                <div class="modal-footer">

                </div>

            </div>

        </div>

    </div>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
