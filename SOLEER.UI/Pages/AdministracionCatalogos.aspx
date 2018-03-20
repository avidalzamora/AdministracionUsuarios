<%@ Page Title="Catalogos" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="AdministracionCatalogos.aspx.cs" Inherits="SOLEER.UI.Pages.AdministracionCatalogos" %>

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
                        <div class="col-md-6">
                            <h4 class="modal-title col-sm-3"><span class="obligatorio">*</span>Catalogos</h4>
                            <div class="col-sm-7">
                                <dx:ASPxComboBox ID="cbCatalogos" CssClass="form-control" OnSelectedIndexChanged="cbCatalogos_SelectedIndexChanged" Theme="MetropolisBlue" AutoPostBack="true" runat="server"></dx:ASPxComboBox>
                            </div>
                        </div>
                        <div class="text-right panel-body col-sm-6">
                            <dx:ASPxButton ID="btAdd" runat="server" Text="" ToolTip="AGREGAR NUEVO" UseSubmitBehavior="false" CssClass="btn btn-success" OnClick="btAdd_Click">
                                <Image Url="../Content/img/plus.png" Width="20px"></Image>
                            </dx:ASPxButton>
                            <dx:ASPxButton ID="btEdit" runat="server" Text="" ToolTip="EDITAR CATALOGO" UseSubmitBehavior="false" CssClass="btn btn-success" OnClick="btEdit_Click">
                                <Image Url="../Content/img/edit.png" Width="20px"></Image>
                                <ClientSideEvents Click="function(s, e){ window.setTimeout(function(){s.SetEnabled(false);},1); cpLoadingShow.PerformCallback(); lpShowLock.Show(); }" />
                            </dx:ASPxButton>
                            <dx:ASPxButton ID="btActivaDesac" runat="server" Text="" ToolTip="ACTIVAR/DESACTIVAR CATALOGO" UseSubmitBehavior="false" CssClass="btn btn-success" OnClick="btActivaDesac_Click">
                                <Image Url="../Content/img/check-white.png" Width="20px"></Image>
                            </dx:ASPxButton>
                        </div>
                        <dx:ASPxGridView ID="gvDetalles" ClientInstanceName="gvDetalles" EnableCallBacks="false" OnSelectionChanged="gvDetalles_SelectionChanged" Styles-Header-Wrap="true" KeyFieldName="IDREG" SettingsBehavior-AllowSort="false" runat="server" ClientIDMode="AutoID" Width="100%" Settings-HorizontalScrollBarMode="Auto" Settings-VerticalScrollBarMode="Auto" AutoGenerateColumns="False" CssClass="gv_Admin" EnableTheming="True" Theme="MetropolisBlue">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="IDREG" Visible="false" ShowInCustomizationForm="True" VisibleIndex="0"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="CODTBL" Visible="false" ShowInCustomizationForm="True" VisibleIndex="1"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="NOMBRE" Visible="false" ShowInCustomizationForm="True" VisibleIndex="2"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="IDCAT" Caption="ID CATALOGO" Width="8%" ShowInCustomizationForm="True" VisibleIndex="3"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="CONCEPTO" Width="25%" ShowInCustomizationForm="True" VisibleIndex="4"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="DETALLE" Width="25%" ShowInCustomizationForm="True" VisibleIndex="5"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="DETALLE2" Width="25%" ShowInCustomizationForm="True" VisibleIndex="5"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="GRUPO" Width="7%" ShowInCustomizationForm="True" VisibleIndex="5"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="ESTADO" Width="10%" VisibleIndex="6">
                                    <PropertiesComboBox TextField="CONCEPTO" ValueField="IDCAT" EnableSynchronization="false" IncrementalFilteringMode="StartsWith">
                                        <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
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
            <asp:HiddenField ID="txIdReg" runat="server" />
            <asp:HiddenField ID="txEstado" runat="server" />
            <asp:HiddenField ID="hdConfirm" runat="server" />

            <asp:Panel ID="pnRegistro" runat="server" DefaultButton="btGuardar" Visible="false">
                <div class="modal fade in" style="display: block; padding-right: 17px;">
                    <div class="modal-dialog" data-modal-index="0">
                        <div class="modal-content">
                            <div class="modal-header">
                                <dx:ASPxButton ID="ASPxButton6" CssClass="close" OnClick="btCancelarGuarda_Click" runat="server" Text="&times;"></dx:ASPxButton>
                                <h4 class="modal-title">Registro de Catalogos</h4>
                            </div>
                            <div class="modal-body">
                                <div class="box-body">
                                    <div class="col-sm-6">
                                        <label><span class="obligatorio">*</span>Catalogo:</label>
                                        <dx:ASPxComboBox ID="cbCatalogosR" CssClass="form-control" Theme="MetropolisBlue" OnSelectedIndexChanged="cbCatalogosR_SelectedIndexChanged" AutoPostBack="true" runat="server"></dx:ASPxComboBox>
                                    </div>
                                    <div class="col-sm-6">
                                        <label><span class="obligatorio">*</span>Nombre Catalogo:</label>
                                        <dx:ASPxTextBox ID="txNombreCat" ClientSideEvents-KeyPress="function(s,e) { ValidaTexto(s, e); }" CssClass="form-control" Theme="MetropolisBlue" runat="server"></dx:ASPxTextBox>
                                    </div>
                                    <div class="col-sm-6">
                                        <label><span class="obligatorio">*</span>ID Catalogo:</label>
                                        <dx:ASPxTextBox ID="txIdCat" Enabled="false" CssClass="form-control" Theme="MetropolisBlue" runat="server"></dx:ASPxTextBox>
                                    </div>
                                    <div class="col-sm-6">
                                        <label><span class="obligatorio">*</span>Concepto:</label>
                                        <dx:ASPxTextBox ID="txConcepto" ClientSideEvents-KeyPress="function(s,e) { ValidaTexto(s, e); }" CssClass="form-control" Theme="MetropolisBlue" runat="server"></dx:ASPxTextBox>
                                    </div>
                                    <div class="col-sm-6">
                                        <label>Detalle:</label>
                                        <dx:ASPxTextBox ID="txDetalle" ClientSideEvents-KeyPress="function(s,e) { ValidaTexto(s, e); }" CssClass="form-control" Theme="MetropolisBlue" runat="server"></dx:ASPxTextBox>
                                    </div>
                                    <div class="col-sm-6">
                                        <label><span class="obligatorio">*</span>Detalle 2:</label>
                                        <dx:ASPxTextBox ID="txDetalle2" ClientSideEvents-KeyPress="function(s,e) { ValidaTexto(s, e); }" CssClass="form-control" Theme="MetropolisBlue" runat="server"></dx:ASPxTextBox>
                                    </div>
                                    <div class="col-sm-6">
                                        <label><span class="obligatorio">*</span>Grupo:</label>
                                        <dx:ASPxTextBox ID="txGrupo" Enabled="false" ClientSideEvents-KeyPress="function(s,e) { ValidaTexto(s, e); }" CssClass="form-control" Theme="MetropolisBlue" runat="server"></dx:ASPxTextBox>
                                    </div>
                                    <div class="col-sm-6">
                                        <label><span class="obligatorio">*</span>Estado:</label>
                                        <dx:ASPxComboBox ID="cbEstado" AutoPostBack="false" CssClass="form-control" Theme="MetropolisBlue" runat="server"></dx:ASPxComboBox>
                                    </div>
                                    <div class="col-sm-12">
                                        <asp:Panel ID="pnGrupo" runat="server" Visible="false">
                                            <div class="row"><br /></div>
                                            <legend class="col-sm-12">
                                                <dx:ASPxCheckBox ID="ckTienePadre" runat="server" ClientInstanceName="checkBox" Text="¿Pertenece a un grupo?" AutoPostBack="true" OnCheckedChanged="ckTienePadre_CheckedChanged" Checked="false" Theme="MetropolisBlue"></dx:ASPxCheckBox>
                                            </legend>
                                            <div class="col-sm-6">
                                                <label><asp:Label ID="lbCatalogo" runat="server" Visible="false" Text="Catalogo:"></asp:Label></label>
                                                <dx:ASPxComboBox ID="cbCatalogosG" CssClass="form-control" Visible="false" Theme="MetropolisBlue" OnSelectedIndexChanged="cbCatalogosG_SelectedIndexChanged" AutoPostBack="true" runat="server"></dx:ASPxComboBox>
                                            </div>
                                            <div class="col-sm-6">
                                                <label><asp:Label ID="lbGrupo" runat="server" Visible="false" Text="Grupo:"></asp:Label></label>
                                                <dx:ASPxComboBox ID="cbGrupo" CssClass="form-control" Visible="false" Theme="MetropolisBlue" OnSelectedIndexChanged="cbGrupo_SelectedIndexChanged" AutoPostBack="true" runat="server"></dx:ASPxComboBox>
                                            </div>
                                        </asp:Panel>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <dx:ASPxButton ID="btCancelarGuarda" CssClass="btn btn-default" OnClick="btCancelarGuarda_Click" runat="server" Text="Cancelar"></dx:ASPxButton>
                                <dx:ASPxButton ID="btGuardar" CssClass="btn btn-primary" OnClick="btGuardar_Click" runat="server" Text="Guardar">
                                    <ClientSideEvents Click="function(s, e){ window.setTimeout(function(){s.SetEnabled(false);},1); cpLoadingShow.PerformCallback(); lpShowLock.Show(); }" />
                                </dx:ASPxButton>
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
                                <h4 class="modal-title">
                                    <asp:Label ID="lbTitleConfirm" CssClass="lbTitleMessage" runat="server" Text=""></asp:Label></h4>
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
                                <h4 class="modal-title">
                                    <asp:Label ID="lbTitleMessage" CssClass="lbTitleMessage" runat="server" Text=""></asp:Label></h4>
                            </div>
                            <div class="modal-body">
                                <div class="box-body">
                                    <p>
                                        <asp:Label ID="lbMessage" runat="server" Text=""></asp:Label></p>
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
