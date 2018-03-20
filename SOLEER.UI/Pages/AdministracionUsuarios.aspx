<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="AdministracionUsuarios.aspx.cs" Inherits="SOLEER.UI.Pages.AdministracionUsuarios" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <script type="text/javascript">
                function ValidaTexto(s, evt) {
                    key = evt.keyCode || evt.htmlEvent.which || evt.which;
                    tecla = String.fromCharCode(key).toString();
                    letras = " áéíóúabcdefghijklmnñopqrstuvwxyzÁÉÍÓÚABCDEFGHIJKLMNÑOPQRSTUVWXYZ@";//Se define todo el abecedario que se quiere que se muestre.
                    especiales = [8, 9, 6]; //Es la validación del KeyCodes, que teclas recibe el campo de texto.

                    tecla_especial = false
                    for (var i in especiales) {
                        if (key == especiales[i]) {
                            tecla_especial = true;
                            break;
                        }
                    }
                    if (letras.indexOf(tecla) == -1 && !tecla_especial) {
                        ASPx.Evt.PreventEventAndBubble(evt.htmlEvent);
                        ASPx.Evt.PreventEventAndBubble(evt);
                    }
                }

                function ValidaTextoNumeros(s, evt) {
                    key = evt.keyCode || evt.htmlEvent.which || evt.which;
                    tecla = String.fromCharCode(key).toString();
                    letras = " áéíóúabcdefghijklmnñopqrstuvwxyzÁÉÍÓÚABCDEFGHIJKLMNÑOPQRSTUVWXYZ1234567890,.:;?¿-)/(#$%_";//Se define todo el abecedario que se quiere que se muestre.
                    especiales = [8, 9, 6]; //Es la validación del KeyCodes, que teclas recibe el campo de texto.

                    tecla_especial = false
                    for (var i in especiales) {
                        if (key == especiales[i]) {
                            tecla_especial = true;
                            break;
                        }
                    }
                    if (letras.indexOf(tecla) == -1 && !tecla_especial) {
                        ASPx.Evt.PreventEventAndBubble(evt.htmlEvent);
                        ASPx.Evt.PreventEventAndBubble(evt);
                    }
                }

                function ValidaNumeroPunto(s, evt) {
                    key = evt.keyCode || evt.htmlEvent.which || evt.which;
                    tecla = String.fromCharCode(key).toString();
                    letras = "1234567890.,";//Se define todo el abecedario que se quiere que se muestre.
                    especiales = [8, 9, 6]; //Es la validación del KeyCodes, que teclas recibe el campo de texto.

                    tecla_especial = false
                    for (var i in especiales) {
                        if (key == especiales[i]) {
                            tecla_especial = true;
                            break;
                        }
                    }
                    if (letras.indexOf(tecla) == -1 && !tecla_especial) {
                        ASPx.Evt.PreventEventAndBubble(evt.htmlEvent);
                        ASPx.Evt.PreventEventAndBubble(evt);
                    }
                }

                function ValidaNumeros(s, evt) {
                    key = evt.keyCode || evt.htmlEvent.which || evt.which;
                    tecla = String.fromCharCode(key).toString();
                    letras = "1234567890";//Se define todo el abecedario que se quiere que se muestre.
                    especiales = [8, 9, 6]; //Es la validación del KeyCodes, que teclas recibe el campo de texto.

                    tecla_especial = false
                    for (var i in especiales) {
                        if (key == especiales[i]) {
                            tecla_especial = true;
                            break;
                        }
                    }
                    if (letras.indexOf(tecla) == -1 && !tecla_especial) {
                        ASPx.Evt.PreventEventAndBubble(evt.htmlEvent);
                        ASPx.Evt.PreventEventAndBubble(evt);
                    }
                }
        
            </script>
            <div class="content">
                <div class="row">
                    <div class="col-md-12 col-sm-12">
                        <div class="col-md-4">
                            <h4 class="modal-title">Usuarios</h4>
                        </div>
                        <div class="text-right panel-body col-sm-8">
                            <dx:ASPxButton ID="btUserConect" runat="server" Text="" ToolTip="USUARIOS CONECTADOS" UseSubmitBehavior="false" CssClass="btn btn-success" OnClick="btUserConect_Click">
                                <Image Url="../Content/img/enlazar.png" Width="20px"></Image>
                                <ClientSideEvents Click="function(s, e){ window.setTimeout(function(){s.SetEnabled(false);},1); cpLoadingShow.PerformCallback(); lpShowLock.Show(); }" />
                            </dx:ASPxButton>
                            <dx:ASPxButton ID="btAddUsuario" runat="server" Text="" ToolTip="AGREGAR NUEVO" UseSubmitBehavior="false" CssClass="btn btn-success" OnClick="btAddUsuario_Click">
                                <Image Url="../Content/img/plus.png" Width="20px"></Image>
                            </dx:ASPxButton>
                            <dx:ASPxButton ID="btEditUsuario" runat="server" Text="" ToolTip="EDITAR USUARIO" UseSubmitBehavior="false" CssClass="btn btn-success" OnClick="btEditUsuario_Click">
                                <Image Url="../Content/img/edit.png" Width="20px"></Image>
                                <ClientSideEvents Click="function(s, e){ window.setTimeout(function(){s.SetEnabled(false);},1); cpLoadingShow.PerformCallback(); lpShowLock.Show(); }" />
                            </dx:ASPxButton>
                            <dx:ASPxButton ID="btActivaDesac" runat="server" Text="" ToolTip="ACTIVAR/DESACTIVAR USUARIO" UseSubmitBehavior="false" CssClass="btn btn-success" OnClick="btActivaDesac_Click">
                                <Image Url="../Content/img/check-white.png" Width="20px"></Image>
                            </dx:ASPxButton>
                            <dx:ASPxButton ID="btEditPermisos" runat="server" Text="" ToolTip="EDITAR PERMISOS" UseSubmitBehavior="false" CssClass="btn btn-success" OnClick="btEditPermisos_Click">
                                <Image Url="../Content/img/LockPermisos.png" Width="20px"></Image>
                            </dx:ASPxButton>
                        </div>
                        <dx:ASPxGridView ID="gvUsuarios" ClientInstanceName="gvUsuarios" EnableCallBacks="false" OnSelectionChanged="gvUsuarios_SelectionChanged" Styles-Header-Wrap="true" KeyFieldName="IDUSUARIO" SettingsBehavior-AllowSort="false" runat="server" ClientIDMode="AutoID" Width="100%" Settings-HorizontalScrollBarMode="Auto" Settings-VerticalScrollBarMode="Auto" AutoGenerateColumns="False" CssClass="gv_Admin" EnableTheming="True" Theme="MetropolisBlue">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="IDUSUARIO" Caption="ID" Width="5%" ShowInCustomizationForm="True" VisibleIndex="0"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="USUARIO" Width="7%" Caption="USUARIO" ShowInCustomizationForm="True" VisibleIndex="1"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="NOMBRE" Caption="Nombres y Apellidos" Width="20%" ShowInCustomizationForm="True" VisibleIndex="2"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="AREA" Width="15%" ShowInCustomizationForm="True" VisibleIndex="3"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="OFICINA" Width="15%" ShowInCustomizationForm="True" VisibleIndex="4"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="CORREO" Width="14%" ShowInCustomizationForm="True" VisibleIndex="5"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="ESTADO" Width="6%" VisibleIndex="6">
                                    <PropertiesComboBox TextField="CONCEPTO" ValueField="IDCAT" EnableSynchronization="false" IncrementalFilteringMode="StartsWith">
                                        <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataTextColumn FieldName="OBSERVACION" Width="18%" ShowInCustomizationForm="True" VisibleIndex="7"></dx:GridViewDataTextColumn>
                            </Columns>
                            <SettingsBehavior ColumnResizeMode="Control" AllowSort="true" AllowSelectSingleRowOnly="true" AllowFocusedRow="True" AllowSelectByRowClick="true" ProcessSelectionChangedOnServer="true" />
                            <SettingsPager PageSize="25">
                                <AllButton Text="All"></AllButton>
                            </SettingsPager>
                            <Settings ShowFilterRow="true" ShowHorizontalScrollBar="True" />
                        </dx:ASPxGridView>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="txEstado" runat="server" />
            <asp:Panel ID="pnPermisos" runat="server" Visible="false">
                <div class="modal fade in" style="display: block; padding-right: 17px;">
                    <div class="modal-dialog" data-modal-index="0">
                        <div class="modal-content">
                            <div class="modal-header">
                                <dx:ASPxButton ID="ASPxButton7" CssClass="close" OnClick="btCancelPermisos_Click" runat="server" Text="&times;"></dx:ASPxButton>
                                <h4 class="modal-title">Asignar Permisos</h4>
                            </div>
                            <div class="modal-body">
                                <div class="box-body">
                                    <div class="col-sm-12">
                                        <label class="col-sm-3"><span class="obligatorio">*</span>Modulo:</label>
                                        <div class="col-sm-7">
                                            <dx:ASPxComboBox ID="cbModulos" CssClass="form-control" OnSelectedIndexChanged="cbModulos_SelectedIndexChanged" Theme="MetropolisBlue" AutoPostBack="true" runat="server"></dx:ASPxComboBox>
                                        </div>
                                    </div>
                                    <div class="row col-sm-12"><br /></div>
                                    <div class="col-sm-5">
                                        <label>TODOS LOS PERMISOS</label>
                                        <div class="col-sm-12">
                                            <dx:ASPxListBox ID="ListAllPermisos" runat="server" AutoPostBack="false" Theme="MetropolisBlue" Width="100%" Height="300px"></dx:ASPxListBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <dx:ASPxButton ID="btMoveOne" runat="server" AutoPostBack="true" Width="18px" UseSubmitBehavior="false" Text="" CssClass="btn btn-success" OnClick="btMoveOne_Click">
                                            <Image Url="../Content/img/MoveOneRight.png" Width="18px"></Image>
                                        </dx:ASPxButton>
                                        <dx:ASPxButton ID="btMoveAll" runat="server" AutoPostBack="true" UseSubmitBehavior="false" Text="" CssClass="btn btn-success" OnClick="btMoveAll_Click">
                                            <Image Url="../Content/img/MoveAllRight.png" Width="18px"></Image>
                                        </dx:ASPxButton>
                                        <dx:ASPxButton ID="btRemoveOne" runat="server" AutoPostBack="true" UseSubmitBehavior="false" Text="" CssClass="btn btn-success" OnClick="btRemoveOne_Click">
                                            <Image Url="../Content/img/MoveOneleft.png" Width="18px"></Image>
                                        </dx:ASPxButton>
                                        <dx:ASPxButton ID="btRemoveAll" runat="server" AutoPostBack="true" UseSubmitBehavior="false" Text="" CssClass="btn btn-success" OnClick="btRemoveAll_Click">
                                            <Image Url="../Content/img/MoveAllleft.png" Width="18px"></Image>
                                        </dx:ASPxButton>
                                    </div>
                                    <div class="col-sm-5">
                                        <label>PERMISOS ASIGNADOS</label>
                                        <div class="col-sm-12">
                                            <dx:ASPxListBox ID="ListPermisosAsig" runat="server" AutoPostBack="false" Theme="MetropolisBlue" Width="100%" Height="300px"></dx:ASPxListBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <dx:ASPxButton ID="btCancelPermisos" CssClass="btn btn-default" OnClick="btCancelPermisos_Click" runat="server" Text="Cerrar"></dx:ASPxButton>
                                <dx:ASPxButton ID="btAceptarPermisos" CssClass="btn btn-primary" OnClick="btAceptarPermisos_Click" runat="server" Text="Guardar">
                                    <ClientSideEvents Click="function(s, e){ window.setTimeout(function(){s.SetEnabled(false);},1); cpLoadingShow.PerformCallback(); lpShowLock.Show(); }" />
                                </dx:ASPxButton>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>

            <asp:Panel ID="pnRegistro" runat="server" DefaultButton="btGuardar" Visible="false">
                <div class="modal fade in" style="display: block; padding-right: 17px;">
                    <div class="modal-dialog" data-modal-index="0">
                        <div class="modal-content">
                            <div class="modal-header">
                                <dx:ASPxButton ID="ASPxButton6" CssClass="close" OnClick="btCancelarGuarda_Click" runat="server" Text="&times;"></dx:ASPxButton>
                                <h4 class="modal-title">Registro de Usuario</h4>
                            </div>
                            <div class="modal-body">
                                <div class="box-body">
                                    <asp:Panel ID="pnBuscarEmp" runat="server" Visible="false">
                                        <div class="col-sm-12">
                                            <label class="control-label"><span class="obligatorio">*</span>Numero Empleado:</label>
                                            <dx:ASPxTextBox ID="txIdEmpBuscar" ClientSideEvents-KeyPress="function(s,e) { ValidaNumeros(s,e); }" CssClass="form-control" Theme="MetropolisBlue" runat="server"></dx:ASPxTextBox>
                                        </div>
                                        <div class="col-sm-12">
                                            <asp:HiddenField ID="txNuevo" runat="server" />
                                            <label class="control-label">Nombre Empleado:</label>
                                            <dx:ASPxTextBox ID="txNomBuscar" ClientSideEvents-KeyPress="function(s,e) { ValidaTexto(s,e); }" CssClass="form-control" Theme="MetropolisBlue" runat="server"></dx:ASPxTextBox>
                                        </div>
                                        <div class="row"></div>
                                        <div class="text-right panel-body">
                                            <dx:ASPxButton ID="btBuscarEmp" CssClass="btn btn-primary" OnClick="btBuscarEmp_Click" runat="server" Text="Buscar">
                                                <ClientSideEvents Click="function(s, e){ window.setTimeout(function(){s.SetEnabled(false);},1); cpLoadingShow.PerformCallback(); lpShowLock.Show(); }" />
                                            </dx:ASPxButton>
                                        </div>
                                         <div class="col-sm-12">
                                            <dx:ASPxGridView ID="gvResBusqueda" ClientInstanceName="gvResBusqueda" EnableCallBacks="false" Styles-Header-Wrap="true" KeyFieldName="IDUSUARIO" SettingsBehavior-AllowSort="false" runat="server" ClientIDMode="AutoID" Width="100%" Settings-HorizontalScrollBarMode="Auto" Settings-VerticalScrollBarMode="Auto" AutoGenerateColumns="False" CssClass="gv_Modal" EnableTheming="True" Theme="MetropolisBlue">
                                                <Columns>
                                                    <dx:GridViewDataTextColumn FieldName="IDUSUARIO" Caption="ID" Width="15%" ShowInCustomizationForm="True" VisibleIndex="0"></dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="USUARIO" Caption="Usuario" Width="25%" ShowInCustomizationForm="True" VisibleIndex="1"></dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="NOMBRE" Caption="Nombres y Apellidos" Width="60%" ShowInCustomizationForm="True" VisibleIndex="2"></dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="NIDENTIFICACION" Visible="false" ShowInCustomizationForm="True" VisibleIndex="2"></dx:GridViewDataTextColumn>
                                                </Columns>
                                                <SettingsBehavior ColumnResizeMode="Control" AllowSort="true" AllowSelectSingleRowOnly="true" AllowFocusedRow="True" AllowSelectByRowClick="true" ProcessSelectionChangedOnServer="true" />
                                                <SettingsPager PageSize="25">
                                                    <AllButton Text="All"></AllButton>
                                                </SettingsPager>
                                                <Settings ShowFilterRow="true" ShowHorizontalScrollBar="True" />
                                            </dx:ASPxGridView>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnDatosGen" runat="server" Visible="false">
                                        <div class="col-sm-12">
                                            <label>ID Usuario:</label>
                                            <dx:ASPxTextBox ID="txCodUsuario" Enabled="false" CssClass="form-control" Theme="MetropolisBlue" runat="server"></dx:ASPxTextBox>
                                        </div>
                                        <div class="col-sm-12">
                                            <label><span class="obligatorio">*</span>Primer Nombre:</label>
                                            <dx:ASPxTextBox ID="txNombre" Enabled="false" ClientSideEvents-KeyPress="function(s,e) { ValidaTexto(s,e); }" CssClass="form-control" Theme="MetropolisBlue" runat="server"></dx:ASPxTextBox>
                                        </div>
                                        <div class="col-sm-6">
                                            <label>Identificación:</label>
                                            <dx:ASPxTextBox ID="txIdentificacion" Enabled="false" ClientSideEvents-KeyPress="function(s,e) { ValidaTextoNumeros(s, e); }" CssClass="form-control" Theme="MetropolisBlue" runat="server"></dx:ASPxTextBox>
                                        </div>
                                        <div class="col-sm-6">
                                            <label><span class="obligatorio">*</span>Area:</label>
                                            <dx:ASPxComboBox ID="cbArea" CssClass="form-control" Theme="MetropolisBlue" OnSelectedIndexChanged="cbArea_SelectedIndexChanged" AutoPostBack="true" runat="server"></dx:ASPxComboBox>
                                        </div>
                                        <div class="col-sm-6">
                                            <label><span class="obligatorio">*</span>Oficina</label>
                                            <dx:ASPxComboBox ID="cbOficina" CssClass="form-control" Theme="MetropolisBlue" AutoPostBack="false" runat="server"></dx:ASPxComboBox>
                                        </div>
                                        <div class="col-sm-6">
                                            <label><span class="obligatorio">*</span>Correo:</label>
                                                <dx:ASPxTextBox ID="txEmail" CssClass="form-control" ClientSideEvents-KeyPress="function(s,e) { ValidaTextoNumeros(s, e); }"  Theme="MetropolisBlue" runat="server"></dx:ASPxTextBox>
                                            <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" Display="Dynamic" ForeColor="Red" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txEmail" ErrorMessage="Formato de correo invalido"></asp:RegularExpressionValidator>
                                        </div>
                                        <div class="col-sm-6">
                                            <label><span class="obligatorio">*</span>Contraseña Correo:</label>
                                            <dx:ASPxTextBox ID="txPassEmail" CssClass="form-control" Theme="MetropolisBlue" runat="server"></dx:ASPxTextBox>
                                        </div>
                                        <div class="col-sm-6">
                                            <label><span class="obligatorio">*</span>Nombre Usuario:</label>
                                            <dx:ASPxTextBox ID="txUsuario" ClientSideEvents-KeyPress="function(s,e) { ValidaTexto(s, e); }" CssClass="form-control" Theme="MetropolisBlue" runat="server"></dx:ASPxTextBox>
                                        </div>
                                        <div class="col-sm-6">
                                            <label><span class="obligatorio">*</span>Contraseña:</label>
                                            <dx:ASPxTextBox ID="txPass1" CssClass="form-control" Password="true" Theme="MetropolisBlue" runat="server"></dx:ASPxTextBox>
                                        </div>
                                        <div class="col-sm-6">
                                            <label><span class="obligatorio">*</span>Repetir Contraseña:</label>
                                            <dx:ASPxTextBox ID="txPass2" CssClass="form-control" Password="true" Theme="MetropolisBlue" runat="server"></dx:ASPxTextBox>
                                        </div>
                                        <div class="col-sm-6">
                                            <label><span class="obligatorio">*</span>Estado:</label>
                                            <dx:ASPxComboBox ID="cbEstado" AutoPostBack="false" CssClass="form-control" Theme="MetropolisBlue" runat="server"></dx:ASPxComboBox>
                                        </div>
                                        <div class="col-sm-6">
                                            <label>Observaciones</label>
                                            <dx:ASPxMemo ID="txObserv" CssClass="form-control" Height="70px" runat="server"></dx:ASPxMemo>
                                        </div>
                                    </asp:Panel>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <dx:ASPxButton ID="btCancelarGuarda" CssClass="btn btn-default" OnClick="btCancelarGuarda_Click" runat="server" Text="Cancelar"></dx:ASPxButton>
                                <dx:ASPxButton ID="btAnterior" CssClass="btn btn-primary" OnClick="btAnterior_Click" runat="server" Visible="false" Text="Anterior"></dx:ASPxButton>
                                <dx:ASPxButton ID="btGuardar" CssClass="btn btn-primary" OnClick="btGuardar_Click" runat="server" Text="Aceptar">
                                    <ClientSideEvents Click="function(s, e){ window.setTimeout(function(){s.SetEnabled(false);},1); cpLoadingShow.PerformCallback(); lpShowLock.Show(); }" />
                                </dx:ASPxButton>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>

            <asp:Panel ID="pnActivaDesac" runat="server" DefaultButton="btGuardarActDes" Visible="false">
                <div class="modal fade in" style="display: block; padding-right: 17px;">
                    <div class="modal-dialog" data-modal-index="0">
                        <div class="modal-content">
                            <div class="modal-header">
                                <dx:ASPxButton ID="ASPxButton5" CssClass="close" OnClick="btCancelarActDes_Click" runat="server" Text="&times;"></dx:ASPxButton>
                                <h4 class="modal-title">Activar / Desactivar Usuario</h4>
                            </div>
                            <div class="modal-body">
                                <div class="box-body">
                                    <div class="col-sm-12">
                                        <label><span class="obligatorio">*</span>Observaciones</label>
                                        <dx:ASPxMemo ID="txObservActDes" CssClass="form-control" Height="70px" runat="server"></dx:ASPxMemo>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <dx:ASPxButton ID="btCancelarActDes" CssClass="btn btn-default" OnClick="btCancelarActDes_Click" runat="server" Text="Cancelar"></dx:ASPxButton>
                                <dx:ASPxButton ID="btGuardarActDes" CssClass="btn btn-primary" OnClick="btGuardarActDes_Click" runat="server" Text="Aceptar">
                                    <ClientSideEvents Click="function(s, e){ window.setTimeout(function(){s.SetEnabled(false);},1); cpLoadingShow.PerformCallback(); lpShowLock.Show(); }" />
                                </dx:ASPxButton>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>

            <asp:Panel ID="pnUsuarioConect" runat="server" Visible="false">
                <div class="modal fade in" style="display: block; padding-right: 17px;">
                    <div class="modal-dialog modal-dialog2" data-modal-index="0">
                        <div class="modal-content">
                            <div class="modal-header">
                                <dx:ASPxButton ID="btCloseUserConect" CssClass="close" OnClick="btCloseUserConect_Click" runat="server" Text="&times;"></dx:ASPxButton>
                                <h4 class="modal-title">Usuarios Conectados</h4>
                            </div>
                            <div class="modal-body">
                                <div class="box-body">
                                    <div class="col-sm-12">
                                        <div class="text-right panel-body col-sm-12">
                                            <asp:HiddenField ID="hdConfirm" runat="server" />
                                            <asp:HiddenField ID="hdUserRemove" runat="server" />
                                            <dx:ASPxButton ID="btEndbyUser" runat="server" Text="" ToolTip="CERRAR SESIÓN A USUARIO" UseSubmitBehavior="false" CssClass="btn btn-success" OnClick="btEndbyUser_Click">
                                                <Image Url="../Content/img/usuariodel.png" Width="20px"></Image>
                                            </dx:ASPxButton>
                                            <dx:ASPxButton ID="btEndAll" runat="server" Text="" ToolTip="CERRAR TODAS LAS SESIONES" UseSubmitBehavior="false" CssClass="btn btn-success" OnClick="btEndAll_Click">
                                                <Image Url="../Content/img/usuariogroupdel.png" Width="20px"></Image>
                                            </dx:ASPxButton>
                                        </div>
                                        <dx:ASPxGridView ID="gvUsuariosConectados" ClientInstanceName="gvResBusqueda" EnableCallBacks="false" Styles-Header-Wrap="true" KeyFieldName="IDTOKEN" SettingsBehavior-AllowSort="false" runat="server" ClientIDMode="AutoID" Width="100%" Settings-HorizontalScrollBarMode="Auto" Settings-VerticalScrollBarMode="Auto" AutoGenerateColumns="False" CssClass="gv_Modal" EnableTheming="True" Theme="MetropolisBlue">
                                            <Columns>
                                                <dx:GridViewDataTextColumn FieldName="IDTOKEN" Visible="false" ShowInCustomizationForm="True" VisibleIndex="0"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="USUARIO" Caption="Usuario" Width="15%" ShowInCustomizationForm="True" VisibleIndex="1"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="FECHACREACION" Caption="FECHA CREACION" Width="20%" ShowInCustomizationForm="True" VisibleIndex="2"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="FECHAACTUALIZA" Caption="ULTIMA OPERACIÓN" Width="20%" ShowInCustomizationForm="True" VisibleIndex="3"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="FECHAEXPIRA" Caption="FECHA EXPIRA" Width="20%" ShowInCustomizationForm="True" VisibleIndex="4"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="PPCREG" Caption="EQUIPO CONECTADO" Width="25%" ShowInCustomizationForm="True" VisibleIndex="5"></dx:GridViewDataTextColumn>
                                            </Columns>
                                            <SettingsBehavior ColumnResizeMode="Control" AllowSort="true" AllowSelectSingleRowOnly="true" AllowFocusedRow="True" AllowSelectByRowClick="true" ProcessSelectionChangedOnServer="true" />
                                            <SettingsPager PageSize="25">
                                                <AllButton Text="All"></AllButton>
                                            </SettingsPager>
                                            <Settings ShowFilterRow="true" ShowHorizontalScrollBar="True" />
                                        </dx:ASPxGridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>

            <asp:Panel ID="pnAlertConfirm" runat="server" DefaultButton="btCancelConfirm" Visible="false">
                <div class="modal fade in" style="display: block; padding-right: 17px;">
                    <div class="modal-dialog" data-modal-index="0">
                        <div class="modal-content">
                            <div class="modal-header">
                                <dx:ASPxButton ID="ASPxButton4" CssClass="close" OnClick="btCancelConfirm_Click" runat="server" Text="&times;"></dx:ASPxButton>
                                <h4 class="modal-title"><asp:Label ID="lbTitleConfirm" CssClass="lbTitleMessage" runat="server" Text=""></asp:Label></h4>
                            </div>
                            <div class="modal-body">
                                <div class="box-body">
                                    <asp:Label ID="lbMessageConfirm" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <dx:ASPxButton ID="btCancelConfirm" CssClass="btn btn-default" OnClick="btCancelConfirm_Click" runat="server" Text="Cancelar"></dx:ASPxButton>
                                <dx:ASPxButton ID="btAceptConfirm" CssClass="btn btn-primary" OnClick="btAceptConfirm_Click" runat="server" Text="Aceptar">
                                    <ClientSideEvents Click="function(s, e){ window.setTimeout(function(){s.SetEnabled(false);},1); cpLoadingShow.PerformCallback(); lpShowLock.Show(); }" />
                                </dx:ASPxButton>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>

            <asp:Panel ID="pnAlertBusqueda" runat="server" DefaultButton="ASPxButton2" Visible="false">
                <div class="modal modal-warning fade in" style="display: block; padding-right: 17px;">
                    <div class="modal-dialog" data-modal-index="0">
                        <div class="modal-content">
                            <div class="modal-header">
                                <dx:ASPxButton ID="ASPxButton3" CssClass="close" OnClick="btCloseMessage_OnClick" runat="server" Text="&times;"></dx:ASPxButton>
                                <h4 class="modal-title"><asp:Label ID="lbTitleMessage" CssClass="lbTitleMessage" runat="server" Text=""></asp:Label></h4>
                            </div>
                            <div class="modal-body">
                                <div class="box-body">
                                    <p><asp:Label ID="lbMessage" runat="server" Text=""></asp:Label></p>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <dx:ASPxButton ID="ASPxButton2" CssClass="btn btn-outline" OnClick="btCloseMessage_OnClick" runat="server" Text="Aceptar"></dx:ASPxButton>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>

            <dx:ASPxLoadingPanel ID="lpShowLock" ClientInstanceName="lpShowLock" Text="" Modal="True" runat="server"></dx:ASPxLoadingPanel>
            <dx:ASPxCallback ID="cpLoadingShow" runat="server" ClientInstanceName="cpLoadingShow" OnCallback="cpLoadingShow_Callback">
                <ClientSideEvents EndCallback="function(s, e) { lpShowLock.Hide(); }" />
            </dx:ASPxCallback>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
