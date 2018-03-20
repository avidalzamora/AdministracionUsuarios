using SOLEER.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SOLEER.UI
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UsuarioSOLEER"] != null)
                {
                    lbUS.Text = Session["UsuarioSOLEER"].ToString();
                    lbNombreUS.Text = Session["NombreUsSOLEER"].ToString();
                    lbCodUs.Text = Session["CodigoUsSOLEER"].ToString();
                }
                else
                {
                    Response.Redirect("~/Account/Login.aspx");
                }
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            ValidarMenu();
        }

        protected void ValidarMenu()
        {
            #region Quitar Permisos
            //Grupo 0   Cadena de Suministros
            mnGrupo0Sub0Item0.Visible = false;
            mnGrupo0Sub0Item1.Visible = false;
            mnGrupo0Sub0Item2.Visible = false;
            mnGrupo0Sub0Item3.Visible = false;
            mnGrupo0Sub0Item4.Visible = false;
            mnGrupo0Sub0Item5.Visible = false;
            mnGrupo0Sub0Item6.Visible = false;
            mnGrupo0Sub0Item7.Visible = false;

            mnGrupo0Sub1Item0.Visible = false;

            //Grupo 1    Servicio al Cliente
            mnGrupo1Sub0Item0.Visible = false;
            mnGrupo1Sub0Item1.Visible = false;
            mnGrupo1Sub0Item2.Visible = false;
            mnGrupo1Sub0Item3.Visible = false;
            mnGrupo1Sub0Item4.Visible = false;
            mnGrupo1Sub0Item5.Visible = false;
            mnGrupo1Sub0Item6.Visible = false;
            mnGrupo1Sub0Item7.Visible = false;

            mnGrupo1Sub1Item0.Visible = false;
            
            mnGrupo1Sub2Item0.Visible = false;
            mnGrupo1Sub2Item1.Visible = false;
            
            //Grupo 2     Finanzas
            mnGrupo2Sub0Item0.Visible = false;

            //Grupo 3    Administracion
            mnGrupo3Sub0Item0.Visible = false;
            mnGrupo3Sub0Item1.Visible = false;
            mnGrupo3Sub0Item2.Visible = false;
            mnGrupo3Sub0Item3.Visible = false;
            mnGrupo3Sub0Item4.Visible = false;
            mnGrupo3Sub0Item5.Visible = false;
            
            mnGrupo3Sub1Item0.Visible = false;
            mnGrupo3Sub1Item1.Visible = false;
            mnGrupo3Sub1Item2.Visible = false;

            //Grupo 4     Ayuda
            
            mnGrupo4Sub0Item0.Visible = false;
            #endregion

            #region Validar Permisos
            //Grupo 0   Cadena de Suministros
            mnGrupo0Sub0Item0.Visible = true;
            mnGrupo0Sub0Item1.Visible = true;
            mnGrupo0Sub0Item2.Visible = true;
            mnGrupo0Sub0Item3.Visible = true;
            mnGrupo0Sub0Item4.Visible = true;
            mnGrupo0Sub0Item5.Visible = true;
            mnGrupo0Sub0Item6.Visible = true;
            mnGrupo0Sub0Item7.Visible = true;

            mnGrupo0Sub1Item0.Visible = true;

            //Grupo 1    Servicio al Cliente
            mnGrupo1Sub0Item0.Visible = true;
            mnGrupo1Sub0Item1.Visible = true;
            mnGrupo1Sub0Item2.Visible = true;
            mnGrupo1Sub0Item3.Visible = true;
            mnGrupo1Sub0Item4.Visible = true;
            mnGrupo1Sub0Item5.Visible = true;
            mnGrupo1Sub0Item6.Visible = true;
            mnGrupo1Sub0Item7.Visible = true;

            mnGrupo1Sub1Item0.Visible = true;

            mnGrupo1Sub2Item0.Visible = true;
            mnGrupo1Sub2Item1.Visible = true;

            //Grupo 2     Finanzas
            mnGrupo2Sub0Item0.Visible = true;

            //Grupo 3    Administracion
            mnGrupo3Sub0Item0.Visible = SelectBD.ADM_PermisoUsuarioValidaFrm(Session["UsuarioSOLEER"].ToString(), "1"); //Administrar Usuario
            mnGrupo3Sub0Item1.Visible = SelectBD.ADM_PermisoUsuarioValidaFrm(Session["UsuarioSOLEER"].ToString(), "2"); //Administrar Catalogo
            mnGrupo3Sub0Item2.Visible = true;
            mnGrupo3Sub0Item3.Visible = true;
            mnGrupo3Sub0Item4.Visible = true;
            mnGrupo3Sub0Item5.Visible = true;

            mnGrupo3Sub1Item0.Visible = true;
            mnGrupo3Sub1Item1.Visible = true;
            mnGrupo3Sub1Item2.Visible = true;


            //Grupo 4     Ayuda
            mnGrupo4Sub0Item0.Visible = true;

            #endregion

            #region Crear Menu
            //Grupo 0   Cadena de Suministros
            if (mnGrupo0Sub0Item0.Visible == true || mnGrupo0Sub0Item1.Visible == true || mnGrupo0Sub0Item2.Visible == true || mnGrupo0Sub0Item3.Visible == true ||
            mnGrupo0Sub0Item4.Visible == true || mnGrupo0Sub0Item5.Visible == true || mnGrupo0Sub0Item6.Visible == true || mnGrupo0Sub0Item7.Visible == true)
                mnGrupo0Sub0.Visible = true;
            else
                mnGrupo0Sub0.Visible = false;
            mnGrupo0Sub1Item0.Visible = true;

            if(mnGrupo0Sub0.Visible == true || mnGrupo0Sub1Item0.Visible == true)
                mnGrupo0.Visible = true;
            else
                mnGrupo0.Visible = false;

            
            //Grupo 1    Servicio al Cliente
            if (mnGrupo1Sub0Item0.Visible == true || mnGrupo1Sub0Item1.Visible == true || mnGrupo1Sub0Item2.Visible == true || mnGrupo1Sub0Item3.Visible == true ||
            mnGrupo1Sub0Item4.Visible == true || mnGrupo1Sub0Item5.Visible == true || mnGrupo1Sub0Item6.Visible == true || mnGrupo1Sub0Item7.Visible == true)
                mnGrupo1Sub0.Visible = true;
            else
                mnGrupo1Sub0.Visible = false;
            mnGrupo1Sub1Item0.Visible = true;

            if (mnGrupo1Sub2Item0.Visible == true || mnGrupo1Sub2Item1.Visible == true)
                mnGrupo1Sub2.Visible = true;
            else
                mnGrupo1Sub2.Visible = false;

            if (mnGrupo1Sub0.Visible == true || mnGrupo1Sub1Item0.Visible == true || mnGrupo1Sub2.Visible == true)
                mnGrupo1.Visible = true;
            else
                mnGrupo1.Visible = false;


            //Grupo 2     Finanzas
            if (mnGrupo2Sub0Item0.Visible == true)
                mnGrupo2Sub0.Visible = true;
            else
                mnGrupo2Sub0.Visible = false;

            if (mnGrupo2Sub0.Visible == true)
                mnGrupo2.Visible = true;
            else
                mnGrupo2.Visible = false;


            //Grupo 3    Administracion
            if (mnGrupo3Sub0Item0.Visible == true || mnGrupo3Sub0Item1.Visible == true || mnGrupo3Sub0Item2.Visible == true ||
            mnGrupo3Sub0Item3.Visible == true || mnGrupo3Sub0Item4.Visible == true || mnGrupo3Sub0Item5.Visible == true)
                mnGrupo3Sub0.Visible = true;
            else
                mnGrupo3Sub0.Visible = false;

            if (mnGrupo3Sub1Item0.Visible == true || mnGrupo3Sub1Item1.Visible == true || mnGrupo3Sub1Item2.Visible == true)
                mnGrupo3Sub1.Visible = true;
            else
                mnGrupo3Sub1.Visible = false;

            if (mnGrupo3Sub0.Visible == true || mnGrupo3Sub1.Visible == true)
                mnGrupo3.Visible = true;
            else
                mnGrupo3.Visible = false;

            
            //Grupo 4     Ayuda
            if (mnGrupo4Sub0Item0.Visible == true)
                mnGrupo4.Visible = true;
            else
                mnGrupo4.Visible = false;
            #endregion


        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Account/Login.aspx");
        }
    }
}