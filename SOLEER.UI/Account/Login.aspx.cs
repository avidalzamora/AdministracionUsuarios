using SOLEER.Data;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace SOLEER.UI.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UsuarioSOLEER"] != null)
                {
                    Response.Redirect("~/Pages/Inicio.aspx", true);
                }
            }
            catch (NullReferenceException)
            { }
        }

        protected void btLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid == true)
                {
                    if (SelectBD.ADM_UsuarioValDom(txUsuario.Text.Trim().ToUpper(), txPassword.Text.Trim()))
                    {
                        string nombreEq = System.Net.Dns.GetHostEntry(Request.ServerVariables["remote_addr"]).HostName;

                        var userlog = SelectBD.ADM_UsuarioLogin(txUsuario.Text.Trim().ToLower(), txPassword.Text.Trim(), nombreEq).FirstOrDefault();
                        if (userlog != null)
                        {
                            if (userlog.ESTADO == 1)
                            {
                                Session["CodigoUsSOLEER"] = userlog.IDUSUARIO;
                                Session["NombreUsSOLEER"] = userlog.NOMBRE;
                                Session["UsuarioSOLEER"] = txUsuario.Text.Trim().ToLower();
                                Session["CodAreaSOLEER"] = userlog.CODAREA;
                                Session["CodOficinaSOLEER"] = userlog.CODOFICINA;
                                Session["EquipoSOLEER"] = nombreEq;
                                Response.Redirect("~/Pages/Inicio.aspx", true);
                            }
                            else
                            {
                                panel_alert.Visible = true;
                                lbError.Text = "El usuario " + txUsuario.Text.Trim() + " tiene estado INACTIVO.";
                                txUsuario.Focus();
                            }

                        }
                        else
                        {
                            panel_alert.Visible = true;
                            lbError.Text = "El usuario " + txUsuario.Text.Trim() + " no existe en la base de datos.";
                            txUsuario.Focus();
                        }
                    }
                    else
                    {
                        panel_alert.Visible = true;
                        lbError.Text = "El nombre de usuario o contraseña no son correctos.";
                        txUsuario.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                string sS = ex.ToString();
            }
        }
    }
}