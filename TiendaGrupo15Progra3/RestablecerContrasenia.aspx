<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RestablecerContrasenia.aspx.cs" Inherits="TiendaGrupo15Progra3.RestablecerContrasenia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="d-flex justify-content-center align-items-center" style="min-height: 100vh;">
        <div class="card text-center" style="width: 300px;">
            <div class="card-header h5 text-white bg-primary">Restablecer Contraseña</div>
            <div class="card-body px-5">
                <p class="card-text py-2">
                    Ingrese su email y le enviaremos a su casilla las instrucciones para resetear su contraseña.
                </p>
                <div class=data-mdb-input-init "form-outline">
                    <asp:TextBox ID="TxtEmail" type="email" CssClass="form-control my-3" placeholder="email" runat="server"></asp:TextBox>           
                    <label class="form-label" for="typeEmail">Ingrese su email</label>
                </div>
                <asp:Button ID="btnRestablecerPasword" runat="server" Text="Restablecer contraseña" CssClass="btn btn-primary w-100" OnClick="btnRestablecerPasword_Click" data-mdb-ripple="true" />
                <div class="d-flex justify-content-between mt-4">
                    <a href="Login.aspx">Iniciar Sesion</a>
                    <a href="RegistrarseLogin.aspx">Registrarse</a>
                </div>              
            </div>
        </div>
    </div>
</asp:Content>


