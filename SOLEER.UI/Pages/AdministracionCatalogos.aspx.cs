using SOLEER.Code;
using SOLEER.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SOLEER.UI.Pages
{
    public partial class AdministracionCatalogos : System.Web.UI.Page
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
                    TienePermiso = SelectBD.ADM_PermisoUsuarioValidaFrm(Session["UsuarioSOLEER"].ToString(), "2"); //Administrar Catalogo
                    if (Session["UsuarioSOLEER"] == null || TienePermiso == false)
                    { }
                    else
                    {
                        if (SelectBD.ADM_TokenVerificar(Session["UsuarioSOLEER"].ToString()))
                            MessageShow("La sesión actual ha expirado, Por favor vuelva a ingresar al sistema.", "PAGINA CADUCADA");
                        else
                        {
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

        private void CargarCatalogos(string codtbl)
        {
            try
            {
                var tblRes = SelectBD.ADM_CatalogosSelectAdmin(codtbl);
                gvDetalles.DataSource = tblRes;
                gvDetalles.DataBind();
                Session.Add("TblCatalogAdmSOLEER", tblRes);
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
                var cat = SelectBD.ADM_CatalogosSelectAll();
                cbCatalogos.DataSource = cat;
                cbCatalogos.ValueField = "CODTBL";
                cbCatalogos.TextField = "NOMBRE";
                cbCatalogos.DataBind();

                cbCatalogosR.DataSource = cat;
                cbCatalogosR.ValueField = "CODTBL";
                cbCatalogosR.TextField = "NOMBRE";
                cbCatalogosR.DataBind();

                cbCatalogosG.DataSource = cat;
                cbCatalogosG.ValueField = "CODTBL";
                cbCatalogosG.TextField = "NOMBRE";
                cbCatalogosG.DataBind();

                cbEstado.DataSource = SelectBD.ADM_CatalogosSelectCodTbl("6");
                cbEstado.ValueField = "IDCAT";
                cbEstado.TextField = "CONCEPTO";
                cbEstado.DataBind();
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
            }
        }

        private void InicializarGrid()
        {
            if (Session["EstadoAllSOLEER"] == null)
                Session["EstadoAllSOLEER"] = SelectBD.ADM_CatalogosSelectCodTbl("6");


            gvDetalles.DataSource = Session["TblCatalogAdmSOLEER"];
            
            DevExpress.Web.GridViewDataComboBoxColumn gvcbEstadoIN = gvDetalles.Columns["ESTADO"] as DevExpress.Web.GridViewDataComboBoxColumn;
            gvcbEstadoIN.PropertiesComboBox.DataSource = (List<cADM_CATALOGOS>)Session["EstadoAllSOLEER"];
            gvcbEstadoIN.PropertiesComboBox.ValueField = "IDCAT";
            gvcbEstadoIN.PropertiesComboBox.TextField = "CONCEPTO";
        }

        protected void cbCatalogos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCatalogos.Value.ToString().Trim() != "")
            {
                CargarCatalogos(cbCatalogos.Value.ToString());
            }
        }

        protected void cbCatalogosR_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCatalogosR.Value.ToString() == "0")
            {
                txNombreCat.Text = "";
                txNombreCat.Enabled = true;
            }
            else
            {
                txNombreCat.Text = cbCatalogosR.Text.Trim();
                txNombreCat.Enabled = false;
            }
        }

        protected void cbCatalogosG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCatalogosG.Value.ToString().Trim() != "")
            {
                CargarElementosCat(cbCatalogosG.Value.ToString());
            }
        }

        protected void cbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGrupo.Text.Trim() != "")
                txGrupo.Text = cbGrupo.Value.ToString();
        }

        protected void ckTienePadre_CheckedChanged(object sender, EventArgs e)
        {
            MostrarGrupo(ckTienePadre.Checked);
        }

        private void CargarElementosCat(string item)
        {
            cbGrupo.DataSource = SelectBD.ADM_CatalogosSelectCodTbl(item);
            cbGrupo.ValueField = "IdCat";
            cbGrupo.TextField = "Concepto";
            cbGrupo.DataBind();
            cbGrupo.Text = "";
        }

        private void MostrarGrupo(bool estado)
        {
            lbCatalogo.Visible = estado;
            cbCatalogosG.Visible = estado;
            lbGrupo.Visible = estado;
            cbGrupo.Visible = estado;
            txGrupo.Text = "0";
            cbCatalogosG.Value = "0";
            CargarElementosCat("0");
        }

        protected void gvDetalles_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (SelectBD.ADM_TokenVerificar(Session["UsuarioSOLEER"].ToString()))
                    MessageShow("La sesión actual ha expirado, Por favor vuelva a ingresar al sistema.", "PAGINA CADUCADA");
                else
                {
                    List<object> RowSelected = gvDetalles.GetSelectedFieldValues(new string[] { "IDREG", "ESTADO" });
                    if (RowSelected.Count > 0)
                    {
                        foreach (object[] item in RowSelected)
                        {
                            txIdReg.Value = item[0].ToString();
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

        protected void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectBD.ADM_TokenVerificar(Session["UsuarioSOLEER"].ToString()))
                    MessageShow("La sesión actual ha expirado, Por favor vuelva a ingresar al sistema.", "PAGINA CADUCADA");
                else
                {
                    LimpiarControles();
                    cbCatalogosR.Enabled = true;
                    cbCatalogosR.Value = cbCatalogos.Value;
                    txNombreCat.Text = cbCatalogos.Text;
                    txNombreCat.Enabled = true;
                    ckTienePadre.Checked = false;
                    pnRegistro.Visible = true;
                    pnGrupo.Visible = true;
                }
            }
            catch (NullReferenceException)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void btEdit_Click(object sender, EventArgs e)
        {
            try
            {
                List<object> RowSelected = gvDetalles.GetSelectedFieldValues(new string[] { "IDREG", "IDCAT", "CONCEPTO", "DETALLE", "DETALLE2", "GRUPO", "ESTADO" });
                if (RowSelected.Count > 0)
                {
                    foreach (object[] item in RowSelected)
                    {
                        cbCatalogosR.Value = cbCatalogos.Value;
                        txNombreCat.Text = cbCatalogos.Text;
                        txIdReg.Value = item[0].ToString();
                        txIdCat.Text = item[1].ToString();
                        txConcepto.Text = item[2].ToString();
                        txDetalle.Text = item[3].ToString();
                        txDetalle2.Text = item[4].ToString();
                        txGrupo.Text = item[5].ToString();
                        cbEstado.Value = item[6].ToString();

                        cbCatalogosR.Enabled = false;
                        txNombreCat.Enabled = false;

                        pnRegistro.Visible = true;
                        pnGrupo.Visible = false; 
                    }
                }
                else
                    MessageShow("Seleccione un Item", "Advertencia");
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
                if (txNombreCat.Text.Trim() == "")
                {
                    MessageShow("El nombre del catalogo es obligatorio", "Advertencia");
                    txNombreCat.Focus();
                }
                else if (txConcepto.Text.Trim() == "")
                {
                    MessageShow("El concepto es obligatorio", "Advertencia");
                    txConcepto.Focus();
                }
                else
                {
                    try
                    {
                        InsertBD.ADM_CATALOGOSSave(new cADM_CATALOGOS(Convert.ToInt32(txIdReg.Value.ToString()), Convert.ToInt32(cbCatalogosR.Value.ToString()), txNombreCat.Text.Trim().ToUpper(), txIdCat.Text.Trim().ToUpper(), txConcepto.Text.Trim().ToUpper(), txDetalle.Text.Trim().ToUpper(), txDetalle2.Text.Trim().ToUpper(), txGrupo.Text.Trim().ToUpper(), Convert.ToInt32(cbEstado.Value.ToString()), DateTime.Now, Session["UsuarioSOLEER"].ToString(), Session["EquipoSOLEER"].ToString(), DateTime.Now, Session["UsuarioSOLEER"].ToString(), Session["EquipoSOLEER"].ToString()));
                        LimpiarControles();
                        CargarCatalogos(cbCatalogos.Value.ToString());
                        CargarCombos();
                        pnRegistro.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        string s = ex.ToString();
                        MessageShow("Error Guardando Datos del Usuario", "Error");
                    }
                }
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
            }
        }

        protected void btCancelarGuarda_Click(object sender, EventArgs e)
        {
            pnRegistro.Visible = false;
        }

        protected void btActivaDesac_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectBD.ADM_TokenVerificar(Session["UsuarioSOLEER"].ToString()))
                    MessageShow("La sesión actual ha expirado, Por favor vuelva a ingresar al sistema.", "PAGINA CADUCADA");
                else
                {
                    List<object> RowSelected = gvDetalles.GetSelectedFieldValues(new string[] { "IDREG", "ESTADO" });
                    if (RowSelected.Count > 0)
                    {
                        hdConfirm.Value = "ACTIVADES";
                        ConfirmMessageShow("Esta seguro que desea cambiar el estado del registro", "Mensaje");
                    }
                    else
                        MessageShow("Seleccione un Item", "Advertencia");
                }
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
                Response.Redirect("~/Account/Login.aspx");
            }
        }
        
        public void LimpiarControles()
        {
            cbCatalogosR.Value = "0";
            txNombreCat.Text = "";
            txIdReg.Value = "0";
            txIdCat.Text = "0";
            txConcepto.Text = "";
            txDetalle.Text = "";
            txDetalle2.Text = "";
            txGrupo.Text = "0";
            cbEstado.Value = "1";

            gvDetalles.FilterExpression = "";
            gvDetalles.Selection.UnselectAll();
        }

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
                if (hdConfirm.Value == "ACTIVADES")
                {
                    InsertBD.ADM_CatalogosActivaDes(Convert.ToInt32(txIdReg.Value.ToString()), Session["UsuarioSOLEER"].ToString(), Session["EquipoSOLEER"].ToString());
                    CargarCatalogos(cbCatalogos.Value.ToString());
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