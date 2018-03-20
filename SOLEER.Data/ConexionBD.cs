using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Configuration;
using System.Data;

namespace SOLEER.Data
{
    public class Configuracion
    {
        public static string GetPassTrue() { return "TrueJhk4554#VZ$&FSDGdfg/=dfSFs64586ijTrue"; }
        public static string SOLEERAdminServidorCorreo() { return "192.168.1.10"; }
        public static string SOLEERRutaDominio() { return "LDAP://ACREAL.COM.NI/DC=ACREAL, DC=COM, DC=NI"; }
        public static string SOLEERDominio() { return "ACREAL.COM.NI"; }
        public static string SOLEERAdminCorreo() { return "acelreal@elreal.gob.ni"; }
        public static string SOLEERAdminPassWord() { return "vzSTLjb$M1G0Bet#2017"; }
    }

    class ConexionBD
    {
        public static string GetConnectionBD()
        {
            byte[] key = { 5, 9, 2, 8, 1, 3, 6, 1, 9, 23, 31, 56, 13, 4, 21, 76, 7, 1, 0, 20, 26, 12, 8, 4 };
            byte[] iv = { 3, 22, 5, 9, 6, 15, 2, 8 };
            string srv = EncryptDecryptPhrase.Decrypt(ConfigurationManager.AppSettings.Get("srv").ToString(), key, iv);
            string bd = EncryptDecryptPhrase.Decrypt(ConfigurationManager.AppSettings.Get("bd"), key, iv);
            string srvn = EncryptDecryptPhrase.Decrypt(ConfigurationManager.AppSettings.Get("srvn").ToString(), key, iv);
            string bdn = EncryptDecryptPhrase.Decrypt(ConfigurationManager.AppSettings.Get("bdn"), key, iv);
            string id = EncryptDecryptPhrase.Decrypt(ConfigurationManager.AppSettings.Get("id"), key, iv);
            string psw = EncryptDecryptPhrase.Decrypt(ConfigurationManager.AppSettings.Get("psw"), key, iv);
            
            return "Data Source=(DESCRIPTION= (ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" + srv + ")(PORT=1521))) (CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + bd + "))); User Id=" + id + ";Password=" + psw + ";Enlist=true;Pooling=true";
            //return "Data Source=(DESCRIPTION= (ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" + srvn + ")(PORT=1521))) (CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + bdn + "))); User Id=" + id + ";Password=" + psw + ";Enlist=true;Pooling=true";
        }
    }
}
