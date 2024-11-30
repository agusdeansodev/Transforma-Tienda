<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TiendaGrupo15Progra3.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="d-flex align-items-center justify-content-center vh-100">
        <div class="text-center">
            <h1 class="display-1 fw-bold">404</h1>
            <p class="fs-3"> <span class="text-danger">Opps!</span> Error.</p>
            <p class="lead">               
                Hemos recibido el error, lo solucionaremos lo antes posible.
            </p>
            <div class="form-group">
                    <label for="ErrorAsuntoText" class="form-label">Aca podes contarnos mas del error:</label>
                    <asp:TextBox ID="txtAsuntoError" CssClass="form-control" placeholder="ErrorMensaje" runat="server"></asp:TextBox>
            </div>

            <a href="Default.aspx" class="btn btn-primary">Volver a Inicio</a>
</asp:Content>

