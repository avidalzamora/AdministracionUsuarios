using Oracle.DataAccess.Client;
using SOLEER.Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.DirectoryServices;
//using System.Data.OracleClient;

namespace SOLEER.Data
{
    public class SelectBD
    {
        //static ConexionBD conn = new ConexionBD();
        #region Administracion

        static byte[] key = { 5, 56, 3, 5, 5, 6, 21, 8, 9, 10, 1, 12, 13, 14, 5, 16, 1, 8, 9, 2, 1, 4, 3, 24 };
        static byte[] iv = { 8, 2, 6, 4, 0, 8, 5, 1 };
        
        public static List<cADM_CATALOGOS> ADM_CatalogosSelectAdmin(string IdTbl)
        {
            List<cADM_CATALOGOS> obj = new List<cADM_CATALOGOS>();
            OracleCommand comando = new OracleCommand { CommandType = CommandType.Text, CommandText = ConsultasPROD.ADM_CatalogosSelectAdmin(IdTbl), Connection = new OracleConnection(ConexionBD.GetConnectionBD()) };
            comando.Connection.Open();
            OracleDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                DateTime? FECHAREG = null;
                if (lector["FECHAREG"] != DBNull.Value)
                    FECHAREG = Convert.ToDateTime(lector["FECHAREG"].ToString());
                DateTime? FECHAMODIFY = null;
                if (lector["FECHAMODIFY"] != DBNull.Value)
                    FECHAMODIFY = Convert.ToDateTime(lector["FECHAMODIFY"].ToString());
                obj.Add(new cADM_CATALOGOS(
                    Convert.ToInt32(lector["IDREG"]),
                    Convert.ToInt32(lector["CODTBL"]),
                    Convert.ToString(lector["NOMBRE"]),
                    Convert.ToString(lector["IDCAT"]),
                    Convert.ToString(lector["CONCEPTO"]),
                    Convert.ToString(lector["DETALLE"]),
                    Convert.ToString(lector["DETALLE2"]),
                    Convert.ToString(lector["GRUPO"]),
                    Convert.ToInt32(lector["ESTADO"]),
                    FECHAREG,
                    Convert.ToString(lector["USERREG"]),
                    Convert.ToString(lector["PCREG"]),
                    FECHAMODIFY,
                    Convert.ToString(lector["USERMODIFY"]),
                    Convert.ToString(lector["PCMODIFY"])));
            }
            comando.Connection.Close();
            lector.Close();
            return obj;
        }

        public static List<cADM_CATALOGOS> ADM_CatalogosSelectAll()
        {
            List<cADM_CATALOGOS> obj = new List<cADM_CATALOGOS>();
            OracleCommand comando = new OracleCommand { CommandType = CommandType.Text, CommandText = ConsultasPROD.ADM_CatalogosSelectAll(), Connection = new OracleConnection(ConexionBD.GetConnectionBD()) };
            comando.Connection.Open();
            OracleDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                obj.Add(new cADM_CATALOGOS(
                    Convert.ToInt32(lector["CODTBL"]),
                    Convert.ToString(lector["NOMBRE"]), "", ""
                    ));
            }
            comando.Connection.Close();
            lector.Close();
            return obj;
        }

        public static List<cADM_CATALOGOS> ADM_CatalogosSelectCodTbl(string IdTbl)
        {
            List<cADM_CATALOGOS> obj = new List<cADM_CATALOGOS>();
            OracleCommand comando = new OracleCommand { CommandType = CommandType.Text, CommandText = ConsultasPROD.ADM_CatalogosSelectCodTbl(IdTbl), Connection = new OracleConnection(ConexionBD.GetConnectionBD()) };
            comando.Connection.Open();
            OracleDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                DateTime? FECHAREG = null;
                if (lector["FECHAREG"] != DBNull.Value)
                    FECHAREG = Convert.ToDateTime(lector["FECHAREG"].ToString());
                DateTime? FECHAMODIFY = null;
                if (lector["FECHAMODIFY"] != DBNull.Value)
                    FECHAMODIFY = Convert.ToDateTime(lector["FECHAMODIFY"].ToString());
                obj.Add(new cADM_CATALOGOS(
                    Convert.ToInt32(lector["IDREG"]),
                    Convert.ToInt32(lector["CODTBL"]),
                    Convert.ToString(lector["NOMBRE"]),
                    Convert.ToString(lector["IDCAT"]),
                    Convert.ToString(lector["CONCEPTO"]),
                    Convert.ToString(lector["DETALLE"]),
                    Convert.ToString(lector["DETALLE2"]),
                    Convert.ToString(lector["GRUPO"]),
                    Convert.ToInt32(lector["ESTADO"]),
                    FECHAREG,
                    Convert.ToString(lector["USERREG"]),
                    Convert.ToString(lector["PCREG"]),
                    FECHAMODIFY,
                    Convert.ToString(lector["USERMODIFY"]),
                    Convert.ToString(lector["PCMODIFY"])));
            }
            comando.Connection.Close();
            lector.Close();
            return obj;
        }

        public static List<cADM_CATALOGOS> ADM_CatalogosSelectGrupo(string IdTbl, string Grupo)
        {
            List<cADM_CATALOGOS> obj = new List<cADM_CATALOGOS>();
            OracleCommand comando = new OracleCommand { CommandType = CommandType.Text, CommandText = ConsultasPROD.ADM_CatalogosSelectGrupo(IdTbl, Grupo), Connection = new OracleConnection(ConexionBD.GetConnectionBD()) };
            comando.Connection.Open();
            OracleDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                DateTime? FECHAREG = null;
                if (lector["FECHAREG"] != DBNull.Value)
                    FECHAREG = Convert.ToDateTime(lector["FECHAREG"].ToString());
                DateTime? FECHAMODIFY = null;
                if (lector["FECHAMODIFY"] != DBNull.Value)
                    FECHAMODIFY = Convert.ToDateTime(lector["FECHAMODIFY"].ToString());
                obj.Add(new cADM_CATALOGOS(
                    Convert.ToInt32(lector["IDREG"]),
                    Convert.ToInt32(lector["CODTBL"]),
                    Convert.ToString(lector["NOMBRE"]),
                    Convert.ToString(lector["IDCAT"]),
                    Convert.ToString(lector["CONCEPTO"]),
                    Convert.ToString(lector["DETALLE"]),
                    Convert.ToString(lector["DETALLE2"]),
                    Convert.ToString(lector["GRUPO"]),
                    Convert.ToInt32(lector["ESTADO"]),
                    FECHAREG,
                    Convert.ToString(lector["USERREG"]),
                    Convert.ToString(lector["PCREG"]),
                    FECHAMODIFY,
                    Convert.ToString(lector["USERMODIFY"]),
                    Convert.ToString(lector["PCMODIFY"])));
            }
            comando.Connection.Close();
            lector.Close();
            return obj;
        }

        public static List<cADM_CATALOGOS> ADM_CatalogosSelectRow(string IdTbl, string IdCat)
        {
            List<cADM_CATALOGOS> obj = new List<cADM_CATALOGOS>();
            OracleCommand comando = new OracleCommand { CommandType = CommandType.Text, CommandText = ConsultasPROD.ADM_CatalogosSelectRow(IdTbl, IdCat), Connection = new OracleConnection(ConexionBD.GetConnectionBD()) };
            comando.Connection.Open();
            OracleDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                DateTime? FECHAREG = null;
                if (lector["FECHAREG"] != DBNull.Value)
                    FECHAREG = Convert.ToDateTime(lector["FECHAREG"].ToString());
                DateTime? FECHAMODIFY = null;
                if (lector["FECHAMODIFY"] != DBNull.Value)
                    FECHAMODIFY = Convert.ToDateTime(lector["FECHAMODIFY"].ToString());
                obj.Add(new cADM_CATALOGOS(
                    Convert.ToInt32(lector["IDREG"]),
                    Convert.ToInt32(lector["CODTBL"]),
                    Convert.ToString(lector["NOMBRE"]),
                    Convert.ToString(lector["IDCAT"]),
                    Convert.ToString(lector["CONCEPTO"]),
                    Convert.ToString(lector["DETALLE"]),
                    Convert.ToString(lector["DETALLE2"]),
                    Convert.ToString(lector["GRUPO"]),
                    Convert.ToInt32(lector["ESTADO"]),
                    FECHAREG,
                    Convert.ToString(lector["USERREG"]),
                    Convert.ToString(lector["PCREG"]),
                    FECHAMODIFY,
                    Convert.ToString(lector["USERMODIFY"]),
                    Convert.ToString(lector["PCMODIFY"])));
            }
            comando.Connection.Close();
            lector.Close();
            return obj;
        }

        public static List<cADM_PERMISOSUSUARIO> ADM_PERMISOSUSUARIOSELECTALL(string Id, string Modulo, int TienePer)
        {
            List<cADM_PERMISOSUSUARIO> obj = new List<cADM_PERMISOSUSUARIO>();
            OracleCommand comando = new OracleCommand { CommandType = CommandType.Text, CommandText = ConsultasPROD.ADM_PermisosUsuarioSelectAll(Id, Modulo, TienePer), Connection = new OracleConnection(ConexionBD.GetConnectionBD()) };
            comando.Connection.Open();
            OracleDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                obj.Add(new cADM_PERMISOSUSUARIO(
                    Convert.ToInt32(lector["IDPERMISO"]),
                    Convert.ToString(lector["IDUSUARIO"]),
                    Convert.ToString(lector["IDFORMULARIO"]),
                    Convert.ToInt32(lector["TIENEPERMISO"]),
                    Convert.ToInt32(lector["ACTIVO"]),
                    Convert.ToString(lector["FORMULARIO"])
                    ));
            }
            comando.Connection.Close();
            lector.Close();
            return obj;
        }

        public static bool ADM_PermisoUsuarioValidaFrm(string usuario, string Formulario)
        {
            string res = "0";
            OracleCommand comando = new OracleCommand() { CommandText = ConsultasPROD.ADM_PermisosUsuarioValida(Formulario, usuario), CommandType = CommandType.Text, Connection = new OracleConnection(ConexionBD.GetConnectionBD()) };
            try
            {
                comando.Connection.Open();
                res = comando.ExecuteScalar().ToString();
                comando.Connection.Close();
                if (res == "1")
                    return true;
                else
                    return false;
            }
            catch(Exception ex)
            {
                comando.Connection.Close();
                string s = ex.ToString();
                return false;
            }
        }

        public static string ADM_GetActualDate()
        {
            string res = "0";
            OracleCommand comando = new OracleCommand() { CommandText = ConsultasPROD.ADM_GetDate(), CommandType = CommandType.Text, Connection = new OracleConnection(ConexionBD.GetConnectionBD()) };
            comando.Connection.Open();
            res = comando.ExecuteScalar().ToString();
            comando.Connection.Close();
            return res;
        }

        public static bool ADM_TokenVerificar(string Token)
        {
            OracleCommand comando = new OracleCommand() { CommandText = "SP_ADM_TOKENVERIFICAR", CommandType = CommandType.StoredProcedure, Connection = new OracleConnection(ConexionBD.GetConnectionBD()) };
            comando.Parameters.Add(new OracleParameter("PUSUARIO", OracleDbType.NVarchar2)).Value = Token;
            comando.Parameters.Add(new OracleParameter("OIDTOKEN", OracleDbType.Int32)).Direction = ParameterDirection.Output;
            comando.Connection.Open();
            comando.ExecuteNonQuery();
            comando.Connection.Close();
            int res = 0;
            if (comando.Parameters["OIDTOKEN"].Value.ToString() != "null")
                res = Convert.ToInt32(comando.Parameters["OIDTOKEN"].Value.ToString());
            if (res == 0)
                return false;
            else
                return true;
        }

        public static List<cADM_USUARIOS> ADM_UsuarioLogin(string usuario, string pasword, string pcreg)
        {
            List<cADM_USUARIOS> obj = new List<cADM_USUARIOS>();
            string Token = EncryptDecryptPhrase.Encrypt(usuario + ',' + pasword + ',' + DateTime.Now.ToShortDateString(), key, iv);
            OracleCommand comando = new OracleCommand() { CommandText = "SP_ADM_USUARIOSLOGIN", CommandType= CommandType.StoredProcedure, Connection = new OracleConnection(ConexionBD.GetConnectionBD()) };
            comando.Parameters.Add(new OracleParameter("PUSUARIO", OracleDbType.NVarchar2)).Value = usuario;
            comando.Parameters.Add(new OracleParameter("PCONTRASENA", OracleDbType.NVarchar2)).Value = pasword;
            comando.Parameters.Add(new OracleParameter("PTOKEN", OracleDbType.NVarchar2)).Value = Token;
            comando.Parameters.Add(new OracleParameter("PPCREG", OracleDbType.NVarchar2)).Value = pcreg;

            comando.Parameters.Add(new OracleParameter("OIDUSUARIO", OracleDbType.NVarchar2, 100)).Direction = ParameterDirection.Output;
            comando.Parameters.Add(new OracleParameter("ONOMBRE", OracleDbType.NVarchar2, 100)).Direction = ParameterDirection.Output;
            comando.Parameters.Add(new OracleParameter("ONIDENTIFICACION", OracleDbType.NVarchar2, 100)).Direction = ParameterDirection.Output;
            comando.Parameters.Add(new OracleParameter("OCODAREA", OracleDbType.NVarchar2, 100)).Direction = ParameterDirection.Output;
            comando.Parameters.Add(new OracleParameter("OCODOFICINA", OracleDbType.NVarchar2, 100)).Direction = ParameterDirection.Output;
            comando.Parameters.Add(new OracleParameter("OCORREO", OracleDbType.NVarchar2, 100)).Direction = ParameterDirection.Output;
            comando.Parameters.Add(new OracleParameter("OPASSCORREO", OracleDbType.NVarchar2, 100)).Direction = ParameterDirection.Output;
            comando.Parameters.Add(new OracleParameter("OUSUARIO", OracleDbType.NVarchar2, 100)).Direction = ParameterDirection.Output;
            comando.Parameters.Add(new OracleParameter("OESTADO", OracleDbType.Int32)).Direction = ParameterDirection.Output;
            comando.Parameters.Add(new OracleParameter("OUSERREG", OracleDbType.NVarchar2, 100)).Direction = ParameterDirection.Output;
            comando.Parameters.Add(new OracleParameter("OFECHAREG", OracleDbType.NVarchar2, 100)).Direction = ParameterDirection.Output;
            comando.Parameters.Add(new OracleParameter("OPCREG", OracleDbType.NVarchar2, 100)).Direction = ParameterDirection.Output;
            comando.Parameters.Add(new OracleParameter("OUSERMODIFY", OracleDbType.NVarchar2, 100)).Direction = ParameterDirection.Output;
            comando.Parameters.Add(new OracleParameter("OFECHAMODIFY", OracleDbType.NVarchar2, 100)).Direction = ParameterDirection.Output;
            comando.Parameters.Add(new OracleParameter("OPCMODIFY", OracleDbType.NVarchar2, 100)).Direction = ParameterDirection.Output;
            comando.Parameters.Add(new OracleParameter("OOBSERVACION", OracleDbType.NVarchar2, 200)).Direction = ParameterDirection.Output;
            comando.Parameters.Add(new OracleParameter("OAREA", OracleDbType.NVarchar2, 100)).Direction = ParameterDirection.Output;
            comando.Parameters.Add(new OracleParameter("OOFICINA", OracleDbType.NVarchar2, 100)).Direction = ParameterDirection.Output;

            comando.Connection.Open();
            comando.ExecuteNonQuery();
            comando.Connection.Close();

            if (comando.Parameters["OIDUSUARIO"].Value.ToString() != "null")
            {
                DateTime? FECHAREG = null;
                if (comando.Parameters["OFECHAREG"].Value.ToString() != "null")
                    FECHAREG = Convert.ToDateTime(comando.Parameters["OFECHAREG"].Value.ToString());
                DateTime? FECHAMODIFY = null;
                if (comando.Parameters["OFECHAMODIFY"].Value.ToString() != "null")
                    FECHAMODIFY = Convert.ToDateTime(comando.Parameters["OFECHAMODIFY"].Value.ToString());
                obj.Add(new cADM_USUARIOS(
                    Convert.ToString(comando.Parameters["OIDUSUARIO"].Value),
                    Convert.ToString(comando.Parameters["ONOMBRE"].Value),
                    Convert.ToString(comando.Parameters["ONIDENTIFICACION"].Value),
                    Convert.ToString(comando.Parameters["OCODAREA"].Value),
                    Convert.ToString(comando.Parameters["OCODOFICINA"].Value),
                    Convert.ToString(comando.Parameters["OCORREO"].Value),
                    Convert.ToString(comando.Parameters["OPASSCORREO"].Value),
                    Convert.ToString(comando.Parameters["OUSUARIO"].Value),
                    Convert.ToInt32(comando.Parameters["OESTADO"].Value.ToString()),
                    Convert.ToString(comando.Parameters["OUSERREG"].Value),
                    FECHAREG,
                    Convert.ToString(comando.Parameters["OPCREG"].Value),
                    Convert.ToString(comando.Parameters["OUSERMODIFY"].Value),
                    FECHAMODIFY,
                    Convert.ToString(comando.Parameters["OPCMODIFY"].Value),
                    Convert.ToString(comando.Parameters["OOBSERVACION"].Value),
                    Convert.ToString(comando.Parameters["OAREA"].Value),
                    Convert.ToString(comando.Parameters["OOFICINA"].Value)
                    ));
            }
            return obj;
        }

        public static List<cADM_USUARIOS> ADM_UsuarioSelectAll()
        {
            List<cADM_USUARIOS> obj = new List<cADM_USUARIOS>();
            OracleCommand comando = new OracleCommand() { CommandText = ConsultasPROD.ADM_UsuarioSelectAll(), CommandType= CommandType.Text, Connection = new OracleConnection(ConexionBD.GetConnectionBD()) };
            comando.CommandType = CommandType.Text;
            comando.Connection.Open();
            OracleDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                DateTime? FECHAREG = null;
                if (lector["FECHAREG"] != DBNull.Value)
                    FECHAREG = Convert.ToDateTime(lector["FECHAREG"].ToString());
                DateTime? FECHAMODIFY = null;
                if (lector["FECHAMODIFY"] != DBNull.Value)
                    FECHAMODIFY = Convert.ToDateTime(lector["FECHAMODIFY"].ToString());
                obj.Add(new cADM_USUARIOS(
                    Convert.ToString(lector["IDUSUARIO"]),
                    Convert.ToString(lector["NOMBRE"]),
                    Convert.ToString(lector["NIDENTIFICACION"]),
                    Convert.ToString(lector["CODAREA"]),
                    Convert.ToString(lector["CODOFICINA"]),
                    Convert.ToString(lector["CORREO"]),
                    Convert.ToString(lector["PASSCORREO"]),
                    Convert.ToString(lector["USUARIO"]),
                    Convert.ToInt32(lector["ESTADO"]),
                    Convert.ToString(lector["USERREG"]),
                    FECHAREG,
                    Convert.ToString(lector["PCREG"]),
                    Convert.ToString(lector["USERMODIFY"]),
                    FECHAMODIFY,
                    Convert.ToString(lector["PCMODIFY"]),
                    Convert.ToString(lector["OBSERVACION"]),
                    Convert.ToString(lector["AREA"]),
                    Convert.ToString(lector["OFICINA"])
                    ));
            }
            comando.Connection.Close();
            lector.Close();
            return obj;
        }

        public static List<cADM_USUARIOS> ADM_UsuarioSelectID(string ID)
        {
            List<cADM_USUARIOS> obj = new List<cADM_USUARIOS>();
            OracleCommand comando = new OracleCommand() { CommandText= ConsultasPROD.ADM_UsuarioSelecRow(ID), CommandType= CommandType.Text, Connection = new OracleConnection(ConexionBD.GetConnectionBD()) };
            comando.CommandType = CommandType.Text;
            comando.Connection.Open();
            OracleDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                DateTime? FECHAREG = null;
                if (lector["FECHAREG"] != DBNull.Value)
                    FECHAREG = Convert.ToDateTime(lector["FECHAREG"].ToString());
                DateTime? FECHAMODIFY = null;
                if (lector["FECHAMODIFY"] != DBNull.Value)
                    FECHAMODIFY = Convert.ToDateTime(lector["FECHAMODIFY"].ToString());
                obj.Add(new cADM_USUARIOS(
                    Convert.ToString(lector["IDUSUARIO"]),
                    Convert.ToString(lector["NOMBRE"]),
                    Convert.ToString(lector["NIDENTIFICACION"]),
                    Convert.ToString(lector["CODAREA"]),
                    Convert.ToString(lector["CODOFICINA"]),
                    Convert.ToString(lector["CORREO"]),
                    Convert.ToString(lector["PASSCORREO"]),
                    Convert.ToString(lector["USUARIO"]),
                    Convert.ToInt32(lector["ESTADO"]),
                    Convert.ToString(lector["USERREG"]),
                    FECHAREG,
                    Convert.ToString(lector["PCREG"]),
                    Convert.ToString(lector["USERMODIFY"]),
                    FECHAMODIFY,
                    Convert.ToString(lector["PCMODIFY"]),
                    Convert.ToString(lector["OBSERVACION"]),
                    Convert.ToString(lector["AREA"]),
                    Convert.ToString(lector["OFICINA"])
                    ));
            }
            comando.Connection.Close();
            lector.Close();
            return obj;
        }

        public static List<cADM_TOKEN> ADM_UsuariosConectados()
        {
            List<cADM_TOKEN> obj = new List<cADM_TOKEN>();
            OracleCommand comando = new OracleCommand { CommandType = CommandType.Text, CommandText = ConsultasPROD.ADM_UsuariosConectados(), Connection = new OracleConnection(ConexionBD.GetConnectionBD()) };
            comando.Connection.Open();
            OracleDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                DateTime? FECHACREACION = null;
                if (lector["FECHACREACION"] != DBNull.Value)
                    FECHACREACION = Convert.ToDateTime(lector["FECHACREACION"]);
                DateTime? FECHAACTUALIZA = null;
                if (lector["FECHAACTUALIZA"] != DBNull.Value)
                    FECHAACTUALIZA = Convert.ToDateTime(lector["FECHAACTUALIZA"]);
                DateTime? FECHAEXPIRA = null;
                if (lector["FECHAEXPIRA"] != DBNull.Value)
                    FECHAEXPIRA = Convert.ToDateTime(lector["FECHAEXPIRA"]);
                obj.Add(new cADM_TOKEN(
                    Convert.ToInt32(lector["IDTOKEN"]),
                    Convert.ToString(lector["USUARIO"]),
                    "",
                    FECHACREACION,
                    FECHAACTUALIZA,
                    FECHAEXPIRA,
                    0,
                    Convert.ToString(lector["PPCREG"])));
            }
            comando.Connection.Close();
            lector.Close();
            return obj;
        }

        public static List<cADM_USUARIOS> ADM_UsuarioBuscarEmp(string ID, string nombre)
        {
            List<cADM_USUARIOS> obj = new List<cADM_USUARIOS>();
            OracleCommand comando = new OracleCommand() { CommandText= ConsultasPROD.ADM_UsuarioBuscarEmp(ID, nombre), CommandType= CommandType.Text, Connection = new OracleConnection(ConexionBD.GetConnectionBD()) };
            comando.CommandType = CommandType.Text;
            comando.Connection.Open();
            OracleDataReader dr = comando.ExecuteReader();
            while (dr.Read())
                obj.Add(new cADM_USUARIOS(Convert.ToString(dr["IDUSUARIO"]), Convert.ToString(dr["IDENTIFICACION"]), Convert.ToString(dr["NOMBRE"]), Convert.ToString(dr["USUARIO"])));
            comando.Connection.Close();
            dr.Close();
            return obj;
        }

        public static bool ADM_UsuarioValDom(string username, string pwd)
        {
            string domainAndUsername = Configuracion.SOLEERDominio() + @"\" + username;
            DirectoryEntry entry = new DirectoryEntry(Configuracion.SOLEERRutaDominio(), domainAndUsername, pwd);
            try
            {
                //Bind to the native AdsObject to force authentication.
                object obj = entry.NativeObject;
                DirectorySearcher search = new DirectorySearcher(entry);
                search.Filter = "(SAMAccountName=" + username + ")";
                search.PropertiesToLoad.Add("cn");
                SearchResult result = search.FindOne();
                if (result == null)
                    return false;
                else
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ADM_UsuarioVerificar(string usr)
        {
            string res = "0";
            OracleCommand comando = new OracleCommand() { CommandText = ConsultasPROD.ADM_UsuarioVerificar(usr), CommandType = CommandType.Text, Connection = new OracleConnection(ConexionBD.GetConnectionBD()) };
            try
            {
                comando.Connection.Open();
                res = comando.ExecuteScalar().ToString();
                comando.Connection.Close();
                if (res == "1")
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                string s = ex.ToString();
                return false;
            }
        }

        public static bool ADM_UsuarioVerificarID(string usr)
        {
            string res = "0";
            OracleCommand comando = new OracleCommand() { CommandText = ConsultasPROD.ADM_UsuarioVerificarID(usr), CommandType = CommandType.Text, Connection = new OracleConnection(ConexionBD.GetConnectionBD()) };
            try
            {
                comando.Connection.Open();
                res = comando.ExecuteScalar().ToString();
                comando.Connection.Close();
                if (res == "1")
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                string s = ex.ToString();
                return false;
            }
        }

        public static bool ADM_ValidarFechaVal(string fecha)
        {
            try
            {
                DateTime j = DateTime.MinValue;
                bool val = DateTime.TryParse(fecha.Substring(0, 10), out j);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string EncPrueba()
        {
            return "ServerPROD=" + EncryptDecryptPhrase.Encrypt("", key, iv) + "\nBDPROD=" + EncryptDecryptPhrase.Encrypt("", key, iv) + "\nServerTRN=" + EncryptDecryptPhrase.Encrypt("", key, iv) + "\nBDTRN=" + EncryptDecryptPhrase.Encrypt("", key, iv) + "\n\nID=" + EncryptDecryptPhrase.Encrypt("", key, iv) + "\nPASS=" + EncryptDecryptPhrase.Encrypt("", key, iv);
        }
        #endregion



    }
}
