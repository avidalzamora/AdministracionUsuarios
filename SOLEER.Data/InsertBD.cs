using Oracle.DataAccess.Client;
using SOLEER.Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLEER.Data
{
    public class InsertBD
    {
        #region Administracion
        public static string ADM_CATALOGOSSave(cADM_CATALOGOS obj)
        {
            OracleCommand comando = new OracleCommand() { CommandText = "SP_ADM_CATALOGOSSAVE", CommandType = CommandType.StoredProcedure, Connection = new OracleConnection(ConexionBD.GetConnectionBD()) };
            comando.Parameters.Add(new OracleParameter("PIDREG", OracleDbType.Int32)).Value = obj.IDREG;
            comando.Parameters.Add(new OracleParameter("PCODTBL", OracleDbType.Int32)).Value = obj.CODTBL;
            comando.Parameters.Add(new OracleParameter("PNOMBRE", OracleDbType.NVarchar2)).Value = obj.NOMBRE;
            comando.Parameters.Add(new OracleParameter("PIDCAT", OracleDbType.NVarchar2)).Value = obj.IDCAT;
            comando.Parameters.Add(new OracleParameter("PCONCEPTO", OracleDbType.NVarchar2)).Value = obj.CONCEPTO;
            comando.Parameters.Add(new OracleParameter("PDETALLE", OracleDbType.NVarchar2)).Value = obj.DETALLE;
            comando.Parameters.Add(new OracleParameter("PDETALLE2", OracleDbType.NVarchar2)).Value = obj.DETALLE2;
            comando.Parameters.Add(new OracleParameter("PGRUPO", OracleDbType.NVarchar2)).Value = obj.GRUPO;
            comando.Parameters.Add(new OracleParameter("PESTADO", OracleDbType.Int32)).Value = obj.ESTADO;
            comando.Parameters.Add(new OracleParameter("PUSERREG", OracleDbType.NVarchar2)).Value = obj.USERREG;
            comando.Parameters.Add(new OracleParameter("PPCREG", OracleDbType.NVarchar2)).Value = obj.PCREG;
            comando.Parameters.Add(new OracleParameter("PUSERMODIFY", OracleDbType.NVarchar2)).Value = obj.USERMODIFY;
            comando.Parameters.Add(new OracleParameter("PPCMODIFY", OracleDbType.NVarchar2)).Value = obj.PCMODIFY;
            comando.Parameters.Add(new OracleParameter("OIDREG", OracleDbType.Int32)).Direction = ParameterDirection.Output;
            comando.Connection.Open();
            comando.ExecuteNonQuery();
            comando.Connection.Close();
            return Convert.ToString(comando.Parameters["OIDREG"].Value.ToString());
        }

        public static string ADM_CatalogosActivaDes(int IDREG, string userMod, string pcMod)
        {
            OracleCommand comando = new OracleCommand() { CommandText = "SP_ADM_CATALOGOSACTIVADES", CommandType = CommandType.StoredProcedure, Connection = new OracleConnection(ConexionBD.GetConnectionBD()) };
            comando.Parameters.Add(new OracleParameter("PIDREG", OracleDbType.Int32)).Value = IDREG;
            comando.Parameters.Add(new OracleParameter("PUSERMODIFY", OracleDbType.NVarchar2)).Value = userMod;
            comando.Parameters.Add(new OracleParameter("PPCMODIFY", OracleDbType.NVarchar2)).Value = pcMod;
            comando.Parameters.Add(new OracleParameter("OIDREG", OracleDbType.Int32)).Direction = ParameterDirection.Output;
            comando.Connection.Open();
            comando.ExecuteNonQuery();
            comando.Connection.Close();
            return Convert.ToString(comando.Parameters["OIDREG"].Value.ToString());
        }

        public static string ADM_PermisosUsuarioCambiar(cADM_PERMISOSUSUARIO obj)
        {
            OracleCommand comando = new OracleCommand() { CommandText = "SP_ADM_PERMISOSUSUARIOSCAMBIAR", CommandType = CommandType.StoredProcedure, Connection = new OracleConnection(ConexionBD.GetConnectionBD()) };
            comando.Parameters.Add(new OracleParameter("PIDPERMISO", OracleDbType.Int32)).Value = obj.IDPERMISO;
            comando.Parameters.Add(new OracleParameter("PIDUSUARIO", OracleDbType.NVarchar2)).Value = obj.IDUSUARIO;
            comando.Parameters.Add(new OracleParameter("PIDFORMULARIO", OracleDbType.NVarchar2)).Value = obj.IDFORMULARIO;
            comando.Parameters.Add(new OracleParameter("PTIENEPERMISO", OracleDbType.Int32)).Value = obj.TIENEPERMISO;
            comando.Parameters.Add(new OracleParameter("PACTIVO", OracleDbType.Int32)).Value = obj.ACTIVO;
            comando.Parameters.Add(new OracleParameter("PUSERREG", OracleDbType.NVarchar2)).Value = obj.USERREG;
            comando.Parameters.Add(new OracleParameter("PPCREG", OracleDbType.NVarchar2)).Value = obj.PCREG;
            comando.Parameters.Add(new OracleParameter("OIDPERMISO", OracleDbType.Int32)).Direction = ParameterDirection.Output;
            comando.Connection.Open();
            comando.ExecuteNonQuery();
            comando.Connection.Close();
            return Convert.ToString(comando.Parameters["OIDPERMISO"].Value.ToString());
        }

        public static string ADM_USUARIOSSave(cADM_USUARIOS obj)
        {
            OracleCommand comando = new OracleCommand() { CommandText = "SP_ADM_USUARIOSSAVE", CommandType = CommandType.StoredProcedure, Connection = new OracleConnection(ConexionBD.GetConnectionBD()) };
            comando.Parameters.Add(new OracleParameter("PIDUSUARIO", OracleDbType.NVarchar2)).Value = obj.IDUSUARIO;
            comando.Parameters.Add(new OracleParameter("PNOMBRE", OracleDbType.NVarchar2)).Value = obj.NOMBRE;
            comando.Parameters.Add(new OracleParameter("PNIDENTIFICACION", OracleDbType.NVarchar2)).Value = obj.NIDENTIFICACION;
            comando.Parameters.Add(new OracleParameter("PCODAREA", OracleDbType.NVarchar2)).Value = obj.CODAREA;
            comando.Parameters.Add(new OracleParameter("PCODOFICINA", OracleDbType.NVarchar2)).Value = obj.CODOFICINA;
            comando.Parameters.Add(new OracleParameter("PCORREO", OracleDbType.NVarchar2)).Value = obj.CORREO;
            comando.Parameters.Add(new OracleParameter("PPASSCORREO", OracleDbType.NVarchar2)).Value = obj.PASSCORREO;
            comando.Parameters.Add(new OracleParameter("PUSUARIO", OracleDbType.NVarchar2)).Value = obj.USUARIO;
            comando.Parameters.Add(new OracleParameter("PCONTRASENA", OracleDbType.NVarchar2)).Value = obj.CONTRASENA;
            comando.Parameters.Add(new OracleParameter("PESTADO", OracleDbType.Int32)).Value = obj.ESTADO;
            comando.Parameters.Add(new OracleParameter("PUSERREG", OracleDbType.NVarchar2)).Value = obj.USERREG;
            comando.Parameters.Add(new OracleParameter("PPCREG", OracleDbType.NVarchar2)).Value = obj.PCREG;
            comando.Parameters.Add(new OracleParameter("PUSERMODIFY", OracleDbType.NVarchar2)).Value = obj.USERMODIFY;
            comando.Parameters.Add(new OracleParameter("PPCMODIFY", OracleDbType.NVarchar2)).Value = obj.PCMODIFY;
            comando.Parameters.Add(new OracleParameter("POBSERVACION", OracleDbType.NVarchar2)).Value = obj.OBSERVACION;
            comando.Parameters.Add(new OracleParameter("OIDUSUARIO", OracleDbType.NVarchar2, 100)).Direction = ParameterDirection.Output;
            comando.Connection.Open();
            comando.ExecuteNonQuery();
            comando.Connection.Close();
            if (comando.Parameters["OIDUSUARIO"].Value.ToString() != "null")
                return Convert.ToString(comando.Parameters["OIDUSUARIO"].Value.ToString());
            else
                return "0";
        }

        public static string ADM_UsuarioSaveEstado(string IdUs, int Estado, string userMod, string pcMod, string Observ)
        {
            OracleCommand comando = new OracleCommand() { CommandText = "SP_ADM_USUARIOSSAVEESTADO", CommandType = CommandType.StoredProcedure, Connection = new OracleConnection(ConexionBD.GetConnectionBD()) };
            comando.Parameters.Add(new OracleParameter("PIDUSUARIO", OracleDbType.NVarchar2)).Value = IdUs;
            comando.Parameters.Add(new OracleParameter("PESTADO", OracleDbType.Int32)).Value = Estado;
            comando.Parameters.Add(new OracleParameter("PUSERMODIFY", OracleDbType.NVarchar2)).Value = userMod;
            comando.Parameters.Add(new OracleParameter("PPCMODIFY", OracleDbType.NVarchar2)).Value = pcMod;
            comando.Parameters.Add(new OracleParameter("POBSERVACION", OracleDbType.NVarchar2)).Value = Observ;
            comando.Parameters.Add(new OracleParameter("OIDUSUARIO", OracleDbType.Int32)).Direction = ParameterDirection.Output;
            comando.Connection.Open();
            comando.ExecuteNonQuery();
            comando.Connection.Close();
            return Convert.ToString(comando.Parameters["OIDUSUARIO"].Value.ToString());
        }

        public static string ADM_TokenEndAll()
        {
            OracleCommand comando = new OracleCommand() { CommandText = "SP_ADM_TOKENENDALL", CommandType = CommandType.StoredProcedure, Connection = new OracleConnection(ConexionBD.GetConnectionBD()) };
            comando.Connection.Open();
            comando.ExecuteNonQuery();
            comando.Connection.Close();
            return "";
        }

        public static string ADM_TokenEndByUser(string usuario)
        {
            OracleCommand comando = new OracleCommand() { CommandText = "SP_ADM_TOKENENDBYUSER", CommandType = CommandType.StoredProcedure, Connection = new OracleConnection(ConexionBD.GetConnectionBD()) };
            comando.Parameters.Add(new OracleParameter("PUSUARIO", OracleDbType.NVarchar2)).Value = usuario;
            comando.Connection.Open();
            comando.ExecuteNonQuery();
            comando.Connection.Close();
            return "";
        }

        #endregion

    }
}
