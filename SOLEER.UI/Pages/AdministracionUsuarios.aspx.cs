using DevExpress.Web;
using SOLEER.Code;
using SOLEER.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SOLEER.UI.Pages
{
    public partial class AdministracionUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                InicializarGrid();
            }
            catch (NullReferenceException)
            {
                MessageShow("No se pudieron cargar los Usuarios", "Error de Conexion");
            }

            if (!Page.IsPostBack)
            {
                bool TienePermiso = false;
                try
                {
                    TienePermiso = SelectBD.ADM_PermisoUsuarioValidaFrm(Session["UsuarioSOLEER"].ToString(), "1"); //Administrar Usuario
                    if (Session["UsuarioSOLEER"] == null || TienePermiso == false)
                    { }
                    else
                    {
                        if (SelectBD.ADM_TokenVerificar(Session["UsuarioSOLEER"].ToString()))
                            MessageShow("La sesión actual ha expirado, Por favor vuelva a ingresar al sistema.", "PAGINA CADUCADA");
                        else
                        {
                            CargarUsuarios();
                            CargarCombos();
                        }
                    }
                }
                catch (Exception ex)
                {
                    string s = ex.ToString();
                    Response.Redirect("~/Account/Login.aspx");
                }
                if(!TienePermiso)
                    Response.Redirect("~/Pages/AccesoDenegado.aspx");
            }
        }
        
        private void CargarUsuarios()
        {
            try
            {
                var tblRes = SelectBD.ADM_UsuarioSelectAll();
                gvUsuarios.DataSource = tblRes;
                gvUsuarios.DataBind();
                Session.Add("TblAllUsrAdmSOLEER", tblRes);
            }
            catch (NullReferenceException)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        private void CargarUsuariosConnect()
        {
            try
            {
                var tblRes2 = SelectBD.ADM_UsuariosConectados();
                gvUsuariosConectados.DataSource = tblRes2;
                gvUsuariosConectados.DataBind();
                Session.Add("TblAllUsrConnectSOLEER", tblRes2);
            }
            catch (NullReferenceException)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        public void CargarCombos()
        {
            try
            {
                cbArea.DataSource = SelectBD.ADM_CatalogosSelectCodTbl("4");
                cbArea.ValueField = "IDCAT";
                cbArea.TextField = "CONCEPTO";
                cbArea.DataBind();

                cbEstado.DataSource = SelectBD.ADM_CatalogosSelectCodTbl("6");
                cbEstado.ValueField = "IDCAT";
                cbEstado.TextField = "CONCEPTO";
                cbEstado.DataBind();

                cbModulos.DataSource = SelectBD.ADM_CatalogosSelectCodTbl("7");
                cbModulos.ValueField = "IDCAT";
                cbModulos.TextField = "CONCEPTO";
                cbModulos.DataBind();
            }
            catch (NullReferenceException)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        private void InicializarGrid()
        {
            if (Session["EstadoAllSOLEER"] == null)
                Session["EstadoAllSOLEER"] = SelectBD.ADM_CatalogosSelectCodTbl("6");

            
            gvUsuarios.DataSource = Session["TblAllUsrAdmSOLEER"];
            gvResBusqueda.DataSource = Session["TblEmpFoundAdmSOLEER"];
            gvUsuariosConectados.DataSource = Session["TblAllUsrConnectSOLEER"];
            DevExpress.Web.GridViewDataComboBoxColumn gvcbEstadoIN = gvUsuarios.Columns["ESTADO"] as DevExpress.Web.GridViewDataComboBoxColumn;
            gvcbEstadoIN.PropertiesComboBox.DataSource = (List<cADM_CATALOGOS>)Session["EstadoAllSOLEER"];
            gvcbEstadoIN.PropertiesComboBox.ValueField = "IDCAT";
            gvcbEstadoIN.PropertiesComboBox.TextField = "CONCEPTO";
        }

        protected void cbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbArea.Value.ToString().Trim() != "")
            {
                CargarOficinas(cbArea.Value.ToString());
            }
        }

        private void CargarOficinas(string Organo)
        {
            cbOficina.DataSource = SelectBD.ADM_CatalogosSelectGrupo("5", Organo);
            cbOficina.ValueField = "IdCat";
            cbOficina.TextField = "Concepto";
            cbOficina.DataBind();
            cbOficina.Text = "";
        }

        protected void gvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (SelectBD.ADM_TokenVerificar(Session["UsuarioSOLEER"].ToString()))
                    MessageShow("La sesión actual ha expirado, Por favor vuelva a ingresar al sistema.", "PAGINA CADUCADA");
                else
                {
                    List<object> RowSelected = gvUsuarios.GetSelectedFieldValues(new string[] { "IDUSUARIO", "ESTADO" });
                    if (RowSelected.Count > 0)
                    {
                        foreach (object[] item in RowSelected)
                        {
                            txCodUsuario.Text = item[0].ToString();
                            cbEstado.Value = item[1].ToString();
                        }
                    }
                }
            }
            catch (NullReferenceException)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void btAddUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectBD.ADM_TokenVerificar(Session["UsuarioSOLEER"].ToString()))
                    MessageShow("La sesión actual ha expirado, Por favor vuelva a ingresar al sistema.", "PAGINA CADUCADA");
                else
                {
                    LimpiarControles();
                    txNuevo.Value = "1";
                    btGuardar.Text = "Continuar";
                    btAnterior.Visible = false;
                    pnRegistro.DefaultButton = "btBuscarEmp";
                    txUsuario.Enabled = true;
                    pnRegistro.Visible = true;
                    pnBuscarEmp.Visible = true;
                    pnDatosGen.Visible = false;
                }
            }
            catch (NullReferenceException)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void btBuscarEmp_Click(object sender, EventArgs e)
        {
            if (txIdEmpBuscar.Text.Trim() == "" && txNomBuscar.Text.Trim()== "")
                MessageShow("Es necesario que ingrese un criterio de busqueda, para continuar", "Advertencia");
            else
            {
                var tblRes = new List<cADM_USUARIOS>();
                tblRes = SelectBD.ADM_UsuarioBuscarEmp(txIdEmpBuscar.Text.Trim().ToUpper(), txNomBuscar.Text.Trim().ToUpper());

                if (tblRes.Count <= 0)
                    MessageShow("No se encontraron registros", "Mensaje");
                else
                {
                    Session.Add("TblEmpFoundAdmSOLEER", tblRes);
                    gvResBusqueda.DataSource = tblRes;
                    gvResBusqueda.DataBind();
                }
            }
        }

        protected void btEditUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                List<object> RowSelected = gvUsuarios.GetSelectedFieldValues(new string[] { "IDUSUARIO", "USUARIO" });
                if (RowSelected.Count > 0)
                {
                    foreach (object[] item in RowSelected)
                    {
                        var Usr = SelectBD.ADM_UsuarioSelectID(item[0].ToString()).FirstOrDefault();
                        txCodUsuario.Text = Usr.IDUSUARIO;
                        txNombre.Text = Usr.NOMBRE;
                        txIdentificacion.Text = Usr.NIDENTIFICACION;
                        cbArea.Value = Usr.CODAREA;
                        CargarOficinas(cbArea.Value.ToString());
                        cbOficina.Value = Usr.CODOFICINA;
                        txEmail.Text = Usr.CORREO;
                        txPassEmail.Text = Usr.PASSCORREO;
                        txUsuario.Text = Usr.USUARIO;
                        txPass1.Text = "";
                        txPass2.Text = "";
                        cbEstado.Value = Usr.ESTADO.ToString();
                        txObserv.Text = Usr.OBSERVACION;
                        txNuevo.Value = "0";
                        txUsuario.Enabled = false;

                        btAnterior.Visible = false;
                        pnRegistro.DefaultButton = "btGuardar";
                        btGuardar.Text = "Aceptar";
                        pnRegistro.Visible = true;
                        pnBuscarEmp.Visible = false;
                        pnDatosGen.Visible = true;
                    }
                }
                else
                    MessageShow("Seleccione un Usuario", "Advertencia");
            }
            catch (NullReferenceException)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void btGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (pnBuscarEmp.Visible == true && pnDatosGen.Visible == false)
                    CargarDatosUsuario();
                else
                    GuardarDatosUsuario();
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
            }
        }

        private void CargarDatosUsuario()
        {
            List<object> RowSelected = gvResBusqueda.GetSelectedFieldValues(new string[] { "IDUSUARIO", "USUARIO", "NOMBRE", "NIDENTIFICACION" });
            if (RowSelected.Count > 0)
            {
                foreach (object[] item in RowSelected)
                {
                    if (SelectBD.ADM_UsuarioVerificarID(item[0].ToString()))
                        MessageShow("El empleado seleccionado tiene un usuario valido en el sistema, seleccione otro usuario", "Alerta");
                    else
                    {
                        txCodUsuario.Value = item[0].ToString();
                        txNombre.Text = item[2].ToString().Trim();
                        string usuario = "";
                        if (item[1].ToString().Trim() != "")
                            usuario = item[1].ToString().Trim().ToLower();
                        else
                        {
                            string [] na = txNombre.Text.ToLower().Replace("  ", " ").Split(' ');
                            if (na.Count() == 2)
                                usuario = na[0].Substring(0, 1) + na[1];
                            if (na.Count() == 3)
                                usuario = na[0].Substring(0, 1) + na[na.Count() - 1];
                            if (na.Count() >= 4)
                                usuario = na[0].Substring(0, 1) + na[na.Count() - 2];
                        }
                        txIdentificacion.Text = item[3].ToString().Trim();
                        cbArea.Text = "";
                        cbOficina.Text = "";
                        
                        txEmail.Text = usuario + "@" + Configuracion.SOLEERDominio().ToLower();
                        txPassEmail.Text = usuario;
                        txUsuario.Text = usuario;
                        txPass1.Text = usuario;
                        txPass2.Text = usuario;
                        cbEstado.Value = "1";
                        txObserv.Text = "";
                        pnRegistro.DefaultButton = "btGuardar";
                        btGuardar.Text = "Aceptar";
                        btAnterior.Visible = true;
                        pnBuscarEmp.Visible = false;
                        pnDatosGen.Visible = true;
                    }
                }
            }
            else
                MessageShow("Debe seleccionar al menos una persona", "Mensaje");
        }

        private void GuardarDatosUsuario()
        {
            if (txNuevo.Value.ToString().Trim() == "1" && txPass1.Text.Trim() == "")
                MessageShow("Tiene que introducir la contraseña", "Advertencia");
            else
            {
                if (txNombre.Text.Trim() == "")
                {
                    MessageShow("El nombre es obligatorio", "Advertencia");
                    txNombre.Focus();
                }
                else if (cbArea.Text.Trim() == "")
                {
                    MessageShow("El area es obligatorio, seleccioné un area", "Advertencia");
                    cbArea.Focus();
                }
                else if (txUsuario.Text.Trim() == "")
                {
                    MessageShow("El nombre de usuario es obligatorio", "Advertencia");
                    txUsuario.Focus();
                }
                else if (txEmail.Text.Trim() == "")
                {
                    MessageShow("El correo es obligatorio", "Advertencia");
                    txEmail.Focus();
                }
                else
                {
                    if (txPass1.Text.Trim() != txPass2.Text.Trim())
                        MessageShow("Las Contraseñas no Coinciden", "Error");
                    else
                    {
                        try
                        {
                            if (txNuevo.Value.ToString().Trim() == "1" && SelectBD.ADM_UsuarioVerificar(txUsuario.Text.Trim()) == true)
                                MessageShow("Nombre de Usuario no Valido, Ya existe en el sistema", "Error");
                            else
                            {
                                string oficina = "";
                                if (cbOficina.Text.Trim() != "")
                                    oficina = cbOficina.Value.ToString().Trim();
                                InsertBD.ADM_USUARIOSSave(new cADM_USUARIOS(txCodUsuario.Text.Trim(), txNombre.Text.Trim().ToUpper(), txIdentificacion.Text.Trim().ToUpper(), cbArea.Value.ToString().Trim(), oficina, txEmail.Text.Trim().ToLower(), txPassEmail.Text.Trim(), txUsuario.Text.Trim().ToLower(), txPass1.Text.Trim(), Convert.ToInt32(cbEstado.Value.ToString()), Session["UsuarioSOLEER"].ToString(), DateTime.Now, Session["EquipoSOLEER"].ToString(), Session["UsuarioSOLEER"].ToString(), DateTime.Now, Session["EquipoSOLEER"].ToString(), txObserv.Text.Trim().ToUpper()));
                                LimpiarControles();
                                CargarUsuarios();
                                pnRegistro.Visible = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            string s = ex.ToString();
                            MessageShow("Error Guardando Datos del Usuario" , "Error");
                        }
                    }
                }
            }
        }

        protected void btAnterior_Click(object sender, EventArgs e)
        {
            btAnterior.Visible = false;
            btGuardar.Text = "Continuar";
            pnRegistro.DefaultButton = "btBuscarEmp";
            pnBuscarEmp.Visible = true;
            pnDatosGen.Visible = false;
        }

        protected void btCancelarGuarda_Click(object sender, EventArgs e)
        {
            try
            {
                pnRegistro.Visible = false;
            }
            catch (NullReferenceException)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void btActivaDesac_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectBD.ADM_TokenVerificar(Session["UsuarioSOLEER"].ToString()))
                    MessageShow("La sesión actual ha expirado, Por favor vuelva a ingresar al sistema.", "PAGINA CADUCADA");
                else
                {
                    txObservActDes.Text = "";
                    List<object> RowSelected = gvUsuarios.GetSelectedFieldValues(new string[] { "IDUSUARIO", "USUARIO" });
                    if (RowSelected.Count > 0)
                        pnActivaDesac.Visible = true;
                    else
                        MessageShow("Seleccione un Usuario", "Advertencia");
                }
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void btCancelarActDes_Click(object sender, EventArgs e)
        {
            pnActivaDesac.Visible = false;
        }

        protected void btGuardarActDes_Click(object sender, EventArgs e)
        {
            int estado = 1;
            if (cbEstado.Value.ToString().Trim() == "1")
                estado = 0;
            try
            {
                if (txObservActDes.Text.Trim() == "")
                    MessageShow("Describa el motivo por el que desea cambiar el estado del usuario", "Mensaje");
                else
                {
                    string IdExpediente = InsertBD.ADM_UsuarioSaveEstado(txCodUsuario.Text.ToString(), estado, Session["UsuarioSOLEER"].ToString(), Session["EquipoSOLEER"].ToString(), txObservActDes.Text.Trim().ToUpper());
                    gvUsuarios.DataSource = null;
                    LimpiarControles();
                    CargarUsuarios();
                    pnActivaDesac.Visible = false;
                }
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
                MessageShow("Error Cargando la Información", "Error");
            }
        }

        public void LimpiarControles()
        {
            txCodUsuario.Text = "";
            txNombre.Text = "";
            txIdentificacion.Text = "";
            cbArea.Text = "";
            cbOficina.Text = "";
            txEmail.Text = "";
            txPassEmail.Text = "";
            txUsuario.Text = "";
            txPass1.Text = "";
            txPass2.Text = "";
            cbEstado.Text = "";
            txObserv.Text = "";
            gvUsuarios.FilterExpression = "";
            gvUsuarios.Selection.UnselectAll();
        }

        /////Permisos Usuario///////////////////////////////////////////////////////////////////////////////
        #region Permisos Usuario
        protected void btEditPermisos_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectBD.ADM_TokenVerificar(Session["UsuarioSOLEER"].ToString()))
                    MessageShow("La sesión actual ha expirado, Por favor vuelva a ingresar al sistema.", "PAGINA CADUCADA");
                else
                {
                    List<object> RowSelected = gvUsuarios.GetSelectedFieldValues(new string[] { "IDUSUARIO", "USUARIO" });
                    if (RowSelected.Count <= 0)
                        MessageShow("Seleccione un Usuario", "Advertencia");
                    else
                    {
                        ListAllPermisos.Items.Clear();
                        ListPermisosAsig.Items.Clear();
                        cbModulos.Text = "";
                        pnPermisos.Visible = true;
                        foreach (object[] item in RowSelected)
                        {
                            txCodUsuario.Value = item[0].ToString().Trim();
                        }
                    }
                        
                }
            }
            catch (NullReferenceException)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void cbModulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListAllPermisos.Items.Clear();
            ListPermisosAsig.Items.Clear();
            
            var PermisosFalse = SelectBD.ADM_PERMISOSUSUARIOSELECTALL(txCodUsuario.Value.ToString(), cbModulos.Value.ToString(), 0);
            foreach (var item in PermisosFalse)
            {
                ListAllPermisos.Items.Add(new DevExpress.Web.ListEditItem(item.FORMULARIO, item.IDFORMULARIO));
            }

            var PermisosTrue = SelectBD.ADM_PERMISOSUSUARIOSELECTALL(txCodUsuario.Value.ToString(), cbModulos.Value.ToString(), 1);
            foreach (var item in PermisosTrue)
            {
                ListPermisosAsig.Items.Add(new DevExpress.Web.ListEditItem(item.FORMULARIO, item.IDFORMULARIO));
            }
        }

        protected void btAceptarPermisos_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i <= ListAllPermisos.Items.Count - 1; i++)
                    InsertBD.ADM_PermisosUsuarioCambiar(new cADM_PERMISOSUSUARIO(0, txCodUsuario.Text.Trim(), ListAllPermisos.Items[i].Value.ToString(), 0, 1, DateTime.Now, Session["UsuarioSOLEER"].ToString(), Session["EquipoSOLEER"].ToString()));

                for (int i = 0; i <= ListPermisosAsig.Items.Count - 1; i++)
                    InsertBD.ADM_PermisosUsuarioCambiar(new cADM_PERMISOSUSUARIO(0, txCodUsuario.Text.Trim(), ListPermisosAsig.Items[i].Value.ToString(), 1, 1, DateTime.Now, Session["UsuarioSOLEER"].ToString(), Session["EquipoSOLEER"].ToString()));
                MessageShow("Permisos guardados correctamente", "Mensaje");
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void btCancelPermisos_Click(object sender, EventArgs e)
        {
            try
            {
                pnPermisos.Visible = false;
            }
            catch (NullReferenceException)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void btMoveOne_Click(object sender, EventArgs e)
        {
            if (ListAllPermisos.SelectedIndex >= 0)
            {
                ListPermisosAsig.Items.Add(ListAllPermisos.SelectedItem);
                ListAllPermisos.Items.Remove(ListAllPermisos.SelectedItem);
            }
        }

        protected void btMoveAll_Click(object sender, EventArgs e)
        {
            ListPermisosAsig.Items.AddRange(ListAllPermisos.Items);
            ListAllPermisos.Items.Clear();
        }

        protected void btRemoveOne_Click(object sender, EventArgs e)
        {
            if (ListPermisosAsig.SelectedIndex >= 0)
                ListAllPermisos.Items.Add(ListPermisosAsig.SelectedItem);
            ListPermisosAsig.Items.Remove(ListPermisosAsig.SelectedItem);
        }

        protected void btRemoveAll_Click(object sender, EventArgs e)
        {
            ListAllPermisos.Items.AddRange(ListPermisosAsig.Items);
            ListPermisosAsig.Items.Clear();
        }
        #endregion

        #region Usuarios Conectados
        protected void btUserConect_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectBD.ADM_TokenVerificar(Session["UsuarioSOLEER"].ToString()))
                    MessageShow("La sesión actual ha expirado, Por favor vuelva a ingresar al sistema.", "PAGINA CADUCADA");
                else
                {
                    CargarUsuariosConnect();
                    pnUsuarioConect.Visible = true;
                }
            }
            catch(Exception ex)
            {
                string s = ex.ToString();
            }
        }

        protected void btCloseUserConect_Click(object sender, EventArgs e)
        {
            pnUsuarioConect.Visible = false;
        }

        protected void btEndAll_Click(object sender, EventArgs e)
        {
            ConfirmMessageShow("¿Esta seguro que desea continuar?", "Cerrar sesión a todos los usuarios conectados");
            hdConfirm.Value = "ALL";
        }

        protected void btEndbyUser_Click(object sender, EventArgs e)
        {
            List<object> RowSelected = gvUsuariosConectados.GetSelectedFieldValues(new string[] { "IDTOKEN", "USUARIO" });
            if (RowSelected.Count > 0)
            {
                foreach (object[] item in RowSelected)
                {
                    hdUserRemove.Value = item[1].ToString();
                }
                ConfirmMessageShow("¿Esta seguro que desea continuar?", "Cerrar la sesión de " + hdUserRemove.Value.ToString());
                hdConfirm.Value = "ONE";
            }
            else
                MessageShow("Seleccione un usuario", "Mensaje");
        }
        #endregion

        public void ConfirmMessageShow(string message, string title)
        {
            pnAlertConfirm.Visible = true;
            lbTitleConfirm.Text = title;
            lbMessageConfirm.Text = "  " + message;
        }

        protected void btCancelConfirm_Click(object sender, EventArgs e)
        {
            pnAlertConfirm.Visible = false;
        }

        protected void btAceptConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdConfirm.Value == "ONE")
                {
                    InsertBD.ADM_TokenEndByUser(hdUserRemove.Value);
                    CargarUsuariosConnect();
                }
                if (hdConfirm.Value == "ALL")
                {
                    InsertBD.ADM_TokenEndAll();
                    CargarUsuariosConnect();
                }
                pnAlertConfirm.Visible = false;
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
                MessageShow("Error Cargando la Información", "Error");
            }
        }

        public void MessageShow(string message, string title)
        {
            pnAlertBusqueda.Visible = true;
            lbTitleMessage.Text = title;
            lbMessage.Text = "  " + message;
        }
        
        protected void btCloseMessage_OnClick(object sender, EventArgs e)
        {
            pnAlertBusqueda.Visible = false;

            if (lbTitleMessage.Text == "PAGINA CADUCADA")
            {
                System.Threading.Thread.Sleep(1000);
                Session.Clear();
                Session.Abandon();
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void cpLoadingShow_Callback(object source, DevExpress.Web.CallbackEventArgs e)
        {
            System.Threading.Thread.Sleep(200);
        }
    }
}