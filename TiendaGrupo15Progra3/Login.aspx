<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TiendaGrupo15Progra3.WebForm2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
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

        .center-container {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh; 
            flex-direction: column;
        }

        
        .form-container {
            background-color: rgba(255, 255, 255, 0.9); 
            padding: 40px;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            width: 100%;
            max-width: 400px; 
            text-align: center;
        }

      
        input[type="text"], input[type="password"] {
            width: 100%;
            padding: 15px;
            margin-top: 10px;
            margin-bottom: 20px;
            font-size: 1rem;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        
        .btn-custom {
            width: 100%;
            padding: 15px;
            font-size: 1.2rem;
            background-color: #007BFF;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s;
        }

       
        .btn-custom:hover {
            background-color: #0056b3;
        }

       
        .header-custom {
            color: #333;
            font-size: 2rem;
            margin-bottom: 30px;
        }

       
        .forgot-password, .register-link {
            color: #007BFF;
            text-decoration: none;
            font-size: 0.9rem;
            display: block;
            margin-top: 10px;
        }

        .forgot-password:hover, .register-link:hover {
            text-decoration: underline;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg-custom"></div>
    <div class="center-container">
        <div class="form-container">
            <h1 class="header-custom">Inicio de Sesión</h1>

            <asp:Label ID="LoginLabelUsuario" runat="server" Text="Ingrese Usuario:" AssociatedControlID="LoginTextUsuario"></asp:Label>
            <asp:TextBox id="LoginTextUsuario" runat="server" placeholder="XXXUsuarioXXX" CssClass="form-control"></asp:TextBox>

            <asp:Label ID="LoginLabelContrasenia" runat="server" Text="Ingrese Contraseña:" AssociatedControlID="LoginTextContrasenia"></asp:Label>
            <asp:TextBox id="LoginTextContrasenia" runat="server" placeholder="XXX*******XXX" CssClass="form-control" TextMode="Password"></asp:TextBox>

            <!-- Botón para iniciar sesión -->
            <asp:Button ID="LoginButton" runat="server" Text="Iniciar sesión" OnClick="LoginButton_Click" CssClass="btn btn-custom" />

            <!-- Enlace para recuperar contraseña -->
            <a href="RestablecerContrasenia.aspx" class="forgot-password">¿Olvidaste tu contraseña?</a>

            <!-- Enlace para registrarse -->
            <a href="RegistrarseLogin.aspx" class="register-link">¿No tenes cuenta? Regístrate aquí</a>
        </div>
    </div>
</asp:Content>
