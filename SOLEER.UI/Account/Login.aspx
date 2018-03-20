<%@ Page Title="Iniciar Sesión" Language="C#" MasterPageFile="~/MasterLogin.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SOLEER.UI.Account.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="panel_alert" runat="server" CssClass="alert alert-danger" Visible="false">
        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
        <strong><i class="fa fa-exclamation-triangle"></i></strong>
        <asp:Label ID="lbError" runat="server" Text=""></asp:Label>
    </asp:Panel>
    <%--<div class="login-wrap">
        <div class="form-group">
            <label>USUARIO</label>
            <asp:TextBox runat="server" ID="txUsuario" Font-Size="Larger" Height="30px" name="login_username" CssClass="form-control lowercase" autofocus="true" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txUsuario" CssClass="field-validation-error" ErrorMessage="Ingresa tu usuario." />
        </div>
        <div class="form-group">
            <label>CONTRASEÑA </label>
            <asp:TextBox runat="server" ID="txPassword" TextMode="Password" CssClass="form-control" Height="30px" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txPassword" CssClass="field-validation-error" ErrorMessage="Ingresa tu contraseña." />
        </div>
        <div class="form-group">
            <asp:Button ID="Button1" runat="server" Text="Iniciar sesión" CssClass="btn  btn-login btn-block " OnClick="btLogin_Click" />
        </div>
    </div>
    <div class="row"></div>
    <div class="text-center">
        <div class="credits">               
            <a href="http://www.elreal.com.ni/">© Aceitera El Real | Nicaragua <br /> Somos REALmente innovadores</a>
        </div>
    </div>
    <div class="row"></div>--%>

    <div class="login-wrap">
        <div class="input-group">
            <asp:TextBox class="form-control lowercase" placeholder="Usuario" ID="txUsuario" runat="server" ControlToValidate="txt_Usuario"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txUsuario" CssClass="field-validation-error" ErrorMessage="Ingresa tu usuario." />
        </div>
        <div class="input-group">
            <asp:TextBox class="form-control" placeholder="Contraseña" ID="txPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txPassword" CssClass="field-validation-error" ErrorMessage="Ingresa tu contraseña." />
        </div>
        <asp:Button ID="Button1" runat="server" Text="Iniciar sesión" CssClass="btn  btn-login btn-block " OnClick="btLogin_Click" />
        <%--<asp:Button ID="btnLogin" runat="server" class="btn btn-login btn-lg btn-block" Text="Ingresar" OnClick="btLogin_Click"></asp:Button>--%>
    </div>

    <div class="row"></div>

    <div class="text-center">
        <div class="credits">
            <a href="http://www.elreal.com.ni/">© Aceitera El Real | Nicaragua <br /> Somos REALmente innovadores</a>
        </div>
    </div>
</asp:Content>
