
<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ActualizarContrasenia.aspx.cs" Inherits="TiendaGrupo15Progra3.ActualizarContrasenia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="d-flex justify-content-center align-items-center" style="min-height: 100vh;">
     <div class="card text-center" style="width: 300px;">
         <div class="card-header h5 text-white bg-primary">Actualizar Contraseña</div>
         <div class="card-body px-5">
             <p class="card-text py-2">
                 Ingrese la contrasenia de restablecimiento y una nueva contrasenia que sera su nueva contraseña
             </p>
             <div class=data-mdb-input-init "form-outline">
                 <asp:TextBox ID="TxtContraseniaPin" CssClass="form-control my-3" placeholder="Contraseña Pin" runat="server"></asp:TextBox>           
                 <label class="form-label" for="typePassword">Ingrese la contraseña enviada por mail</label>
             </div>
             <div class=data-mdb-input-init "form-outline">
                <asp:TextBox ID="TxtActualizarContrasenia" CssClass="form-control my-3" placeholder="Actualizar Contraseña" runat="server"></asp:TextBox>           
                <label class="form-label" for="typePassword" >Actualizar Contraseña</label>
            </div>
             <asp:Button ID="btnActualizarPasword" runat="server" Text="Actualizar contraseña" CssClass="btn btn-primary w-100" OnClick="btnActualizarPasword_Click" data-mdb-ripple="true" />
             <asp:Label ID="lblMessage" runat="server" CssClass="message"></asp:Label>
             <div class="d-flex justify-content-between mt-4">
                 <a href="Login.aspx">Iniciar Sesion</a>
                 <a href="RegistrarseLogin.aspx">Registrarse</a>
             </div>
         </div>
     </div>
 </div>
</asp:Content>

