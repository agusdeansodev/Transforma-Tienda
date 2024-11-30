  <%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs"  Inherits="TiendaGrupo15Progra3.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>

        .button-container {
            position: fixed;
            top: 50%;
            right: 5%;
        }
        .button-container2 {
            position: fixed;
            top: 50%;
            left: 5%;
        }

        .btn-custom {
            padding: 30px 40px;
            font-size: 2.4rem;
            background-color: black;
            color: white;
            border: none;
            border-radius: 5px;
        }

        .btn-custom:hover {
            background-color: yellow;
            color: white;
        }

        .form-custom {
            background-color: rgba(255, 255, 255, 0.8); 
            padding: 20px;
            border-radius: 5px;
        }

        .header-custom {
            color: blue;
        }
        .main-content { 
            margin-top: 100px; 

        }
        .paraH2{
            font-size:4rem;
            font-weight:bolder;
            font-family: luminari,fantasy;
            color:black;
                     
        }
            

    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg-custom"></div>
    <div class="main-content container">
        
           
            <%if (UsuarioDefault.nombre.Length > 2 && UsuarioDefault.apellido.Length > 2 && Session["Usuario"] != null)
                {  %>

              <h2 class="paraH2">Bienvenido <%=char.ToUpper(UsuarioDefault.nombre[0]) + UsuarioDefault.nombre.Substring(1)%> <%=char.ToUpper(UsuarioDefault.apellido[0]) + UsuarioDefault.apellido.Substring(1)%>, miembro desde <%=UsuarioDefault.fechaRegistro %></h2>
             <% }
                 else
                 { %>   
        <h2>Complete su perfil.</h2>
        <%} %>
        </div>

    <div class="button-container">
        <asp:Button ID="btnVerProductos" runat="server" Text="Ver productos" OnClick="btnParticipa_Click" CssClass="btn btn-secondary btn-lg" />
    </div>
    
    <div>       
    <%if (RolDefault!=0){%>
                     <div class="button-container2">
                                <asp:Button ID="BtnCerrarSesion" runat="server" Text="Cerrar Sesión" CssClass="btn btn-secondary btn-lg bg-danger" OnClick="BtnCerrarSesion_Click" />
                      </div>
               <% } %>
          
    </div>
    
</asp:Content>










