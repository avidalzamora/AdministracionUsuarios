<%@ Page Title="Acceso Denegado" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="AccesoDenegado.aspx.cs" Inherits="SOLEER.UI.Pages.AccesoDenegado" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="imageblock switchable height-100 ">
        <%--bg--secondary--%>
        <div class="imageblock__content col-md-6 col-sm-4 pos-right">
            <div class="background-image-holder">
                <img alt="image" src="../Content/img/404.jpg" />
            </div>
        </div>
        <div class="container pos-vertical-center ">
            <div class="row">
                <div class="col-md-5 col-sm-7">
                    <h1>Acceso Denegado...</h1>
                    <p class="lead">
                        Dirijase a la página de inicio haciendo click en el siguiente enlace.
                    </p>
                    <a class="btn btn--sm btn--primary type--uppercase" href="Inicio.aspx" target="_self"><span class="btn__text">INICIO</span> </a>
                </div>
            </div>
            <!--end of row-->
        </div>
        <!--end of container-->
    </section>
</asp:Content>
