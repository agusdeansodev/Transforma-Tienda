<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RegistrarseLogin.aspx.cs" Inherits="TiendaGrupo15Progra3.RegistrarseLogin" %>

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
        .bg-custom {
            background-color: darkorange;
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

        .center-container {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .form-container {
            text-align: center;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0,0,0,0.1);
            width: 100%;
            max-width: 600px;
        }

        .btn-custom {
            padding: 15px 30px;
            font-size: 1.2rem;
            background-color: black;
            color: yellow;
            border: none;
            border-radius: 5px;
            margin-left: 10px;
        }

        .form-custom .form-group {
            display: flex;
            align-items: center;
            gap: 10px;
        }

        .header-custom {
            color: black;
        }

        .row-custom {
            display: flex;
            align-items: center;
        }
        .main-content { 
                        margin-top: 60px;  

        }
        .padding-botom{
    padding-bottom: 100px;
}
        .paraForm{
            background-color: lightslategrey;
        }
        .colorBlancoDeLetra{
            color:whitesmoke;
        }
    </style>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg-custom"></div>
    <div class="main-content padding-botom">
    <div class="center-container">
        <div class="form-container paraForm">
           
            <h1 class="header-custom">Ingresa tus Datos</h1>
           
            <div class="form-group">
                <label for="nombreText" class="form-label">Nombre:</label>
                <asp:TextBox ID="nombreText" CssClass="form-control" placeholder="Nombre" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="apellidoText" class="form-label">Apellido:</label>
                <asp:TextBox ID="apellidoText" CssClass="form-control" placeholder="Apellido" runat="server"></asp:TextBox>
            </div>
             
            <div class="form-group">
                <label for="nombreUsuarioText" class="form-label">Nombre de Usuario:</label>
                <asp:TextBox ID="TextNombreUsuario" CssClass="form-control" placeholder="NombreUsuario" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="PaswordText" class="form-label">Clave:</label>
                <asp:TextBox ID="TxtClave" TextMode="Password" CssClass="form-control" placeholder="Password" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
    <label for="PaswordText" class="form-label">Repetir Clave:</label>
    <asp:TextBox ID="TxtRepetirClave" TextMode="Password" CssClass="form-control" placeholder="Password" runat="server"></asp:TextBox>
</div>
            <div class="form-group">
                <label for="Emailtxt" class="form-label">Email:</label>
                <asp:TextBox ID="EmailInput" textmode="Email" CssClass="form-control" placeholder="Email" runat="server"></asp:TextBox>
            </div>
            
            
         <div class="form-group">
            <label for="telefonoTxt" class="form-label">Telefono:</label>
            <asp:TextBox ID="TxtTelefono" CssClass="form-control" placeholder="Telefono" runat="server" TextMode="Number"></asp:TextBox>
        </div>
        <!-- Checkbox -->
        <div class="form-group">
            <div class="form-check">
                <asp:CheckBox ID="terminosCheckBox" CssClass="form-check-input" runat="server" />
                <label for="terminosCheckBox" class="form-check-label">Acepto los términos y condiciones</label>
            </div>
        </div>
        <!-- Actualizar o cancelar cambios btn -->
        <div class="form-group">
            <asp:Button type="submit" ID="Aceptar" CssClass="btn btn-custom" runat="server" Text="Aceptar" OnClick="AceptarButton_Click" />
            <asp:Button ID="btnCancelarCambios" CssClass="btn btn-custom" runat="server" Text="Cancelar" OnClick="CancelarClickButton_Click" />
        </div>
      </div>
    </div>
</div>
</asp:Content>

