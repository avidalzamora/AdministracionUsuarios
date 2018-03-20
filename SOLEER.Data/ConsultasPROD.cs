using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLEER.Data
{
    class ConsultasPROD
    {
        public static string ADM_CatalogosSelectAdmin(string ID)
        {
            return "SELECT IDREG, CODTBL, NOMBRE, IDCAT, CONCEPTO, DETALLE, DETALLE2, GRUPO, ESTADO, to_char(FECHAREG, 'DD/MM/YYYY HH24:MI:SS') AS FECHAREG, USERREG, PCREG, to_char(FECHAMODIFY, 'DD/MM/YYYY HH24:MI:SS') AS FECHAMODIFY, USERMODIFY, PCMODIFY FROM SOLEER.ADM_CATALOGOS Where CodTbl = '" + ID + "'";
        }
        public static string ADM_CatalogosSelectAll()
        {
            return "SELECT DISTINCT CodTbl, Nombre FROM SOLEER.ADM_CATALOGOS WHERE CodTbl <> 10 ORDER BY CodTbl";
        }
        public static string ADM_CatalogosSelectCodTbl(string ID)
        {
            return "SELECT IDREG, CODTBL, NOMBRE, IDCAT, CONCEPTO, DETALLE, DETALLE2, GRUPO, ESTADO, to_char(FECHAREG, 'DD/MM/YYYY HH24:MI:SS') AS FECHAREG, USERREG, PCREG, to_char(FECHAMODIFY, 'DD/MM/YYYY HH24:MI:SS') AS FECHAMODIFY, USERMODIFY, PCMODIFY FROM SOLEER.ADM_CATALOGOS Where CodTbl = '" + ID + "' AND ESTADO = 1";
        }
        public static string ADM_CatalogosSelectGrupo(string ID, string Grupo)
        {
            return "SELECT IDREG, CODTBL, NOMBRE, IDCAT, CONCEPTO, DETALLE, DETALLE2, GRUPO, ESTADO, to_char(FECHAREG, 'DD/MM/YYYY HH24:MI:SS') AS FECHAREG, USERREG, PCREG, to_char(FECHAMODIFY, 'DD/MM/YYYY HH24:MI:SS') AS FECHAMODIFY, USERMODIFY, PCMODIFY FROM SOLEER.ADM_CATALOGOS Where CodTbl = '" + ID + "' AND GRUPO = '" + Grupo + "' AND ESTADO = 1";
        }
        public static string ADM_CatalogosSelectRow(string ID, string IdCat)
        {
            return "SELECT IDREG, CODTBL, NOMBRE, IDCAT, CONCEPTO, DETALLE, DETALLE2, GRUPO, ESTADO, to_char(FECHAREG, 'DD/MM/YYYY HH24:MI:SS') AS FECHAREG, USERREG, PCREG, to_char(FECHAMODIFY, 'DD/MM/YYYY HH24:MI:SS') AS FECHAMODIFY, USERMODIFY, PCMODIFY FROM SOLEER.ADM_CATALOGOS Where CodTbl = '" + ID + "' AND IdCat = '" + IdCat + "' AND ESTADO = 1";
        }
        public static string ADM_GetDate()
        {
            return "SELECT to_char(LOCALTIMESTAMP(0), 'DD/MM/YYYY HH24:MI:SS') FROM DUAL";
        }
        public static string ADM_PermisosUsuarioSelectAll(string ID, string Modulo, int TienePer)
        {
            return "SELECT P.IDPERMISO,P.IDUSUARIO,P.IDFORMULARIO,P.TIENEPERMISO,P.ACTIVO, C.CONCEPTO AS FORMULARIO FROM SOLEER.ADM_PERMISOSUSUARIO P INNER JOIN SOLEER.ADM_CATALOGOS C ON P.IDFORMULARIO = C.IDCAT AND C.CODTBL = 8 AND P.ACTIVO = 1 WHERE P.ACTIVO = 1 AND IDUSUARIO = '" + ID + "' AND C.GRUPO = '" + Modulo + "' AND TIENEPERMISO =" + TienePer.ToString();
        }
        public static string ADM_PermisosUsuarioValida(string ID, string usr)
        {
            return "Select TienePermiso From SOLEER.ADM_PERMISOSUSUARIO Where Activo = 1 And IdFormulario = '" + ID + "' And IdUsuario = (Select IdUsuario From SOLEER.ADM_USUARIOS Where Usuario = '" + usr + "')";
        }
        public static string ADM_UsuarioSelectAll()
        {
            return "SELECT P.IDUSUARIO,P.NOMBRE,P.NIDENTIFICACION,P.CODAREA,P.CODOFICINA,P.CORREO,P.PASSCORREO,P.USUARIO,P.ESTADO,P.USERREG,to_char(P.FECHAREG, 'DD/MM/YYYY HH24:MI:SS') AS FECHAREG,P.PCREG,P.USERMODIFY,to_char(P.FECHAMODIFY, 'DD/MM/YYYY HH24:MI:SS') AS FECHAMODIFY,P.PCMODIFY,P.OBSERVACION,A.CONCEPTO AS AREA, O.CONCEPTO AS OFICINA FROM SOLEER.ADM_USUARIOS P INNER JOIN SOLEER.ADM_CATALOGOS A ON P.CODAREA = A.IDCAT AND A.CODTBL = 4 LEFT JOIN SOLEER.ADM_CATALOGOS O ON P.CODAREA = O.IDCAT AND O.CODTBL = 5";
        }
        public static string ADM_UsuarioSelecRow(string ID)
        {
            return "SELECT P.IDUSUARIO,P.NOMBRE,P.NIDENTIFICACION,P.CODAREA,P.CODOFICINA,P.CORREO,P.PASSCORREO,P.USUARIO,P.ESTADO,P.USERREG,to_char(P.FECHAREG, 'DD/MM/YYYY HH24:MI:SS') AS FECHAREG,P.PCREG,P.USERMODIFY,to_char(P.FECHAMODIFY, 'DD/MM/YYYY HH24:MI:SS') AS FECHAMODIFY,P.PCMODIFY,P.OBSERVACION,A.CONCEPTO AS AREA, O.CONCEPTO AS OFICINA FROM SOLEER.ADM_USUARIOS P INNER JOIN SOLEER.ADM_CATALOGOS A ON P.CODAREA = A.IDCAT AND A.CODTBL = 4 LEFT JOIN SOLEER.ADM_CATALOGOS O ON P.CODAREA = O.IDCAT AND O.CODTBL = 5 WHERE P.IDUSUARIO = '" + ID.Trim() + "'";
        }
        public static string ADM_UsuarioVerificar(string usuario)
        {
            return "SELECT 1 FROM SOLEER.ADM_USUARIOS P Where P.USUARIO = '" + usuario.Trim() + "'";
        }
        public static string ADM_UsuarioVerificarID(string usuario)
        {
            return "SELECT 1 FROM SOLEER.ADM_USUARIOS P Where P.IDUSUARIO = '" + usuario.Trim() + "'";
        }
        public static string ADM_UsuariosConectados()
        {
            return "SELECT P.IDTOKEN,P.USUARIO,TO_CHAR(P.FECHACREACION, 'DD/MM/YYYY HH24:MI:SS') AS FECHACREACION,TO_CHAR(P.FECHAACTUALIZA, 'DD/MM/YYYY HH24:MI:SS') AS FECHAACTUALIZA,TO_CHAR(P.FECHAEXPIRA, 'DD/MM/YYYY HH24:MI:SS') AS FECHAEXPIRA,P.PPCREG FROM SOLEER.ADM_TOKEN P WHERE P.EXPIRADO = 0";
        }
        public static string ADM_UsuarioBuscarEmp(string ID, string nombre)
        {
            if(ID.Trim() != "")
                return "SELECT E.ABAN8 AS IDUSUARIO, E.ABTAX AS IDENTIFICACION, E.ABDC AS NOMBRE, USUARIO FROM PRODDTA.F0101 E LEFT JOIN (SELECT ULAN8, USUARIO FROM(SELECT ROW_NUMBER() OVER (PARTITION BY ULAN8 ORDER BY ULUSER) F, ULAN8, ULUSER AS USUARIO FROM SY900.F0092) WHERE F = 1 ORDER BY ULAN8) U ON E.ABAN8 = U.ULAN8 WHERE E.ABAT1 = 'E' AND (E.ABAN8 = '" + ID + "' or ABALKY LIKE '%" + ID + "%')";
            else
                return "SELECT E.ABAN8 AS IDUSUARIO, E.ABTAX AS IDENTIFICACION, E.ABDC AS NOMBRE, USUARIO FROM PRODDTA.F0101 E LEFT JOIN (SELECT ULAN8, USUARIO FROM(SELECT ROW_NUMBER() OVER (PARTITION BY ULAN8 ORDER BY ULUSER) F, ULAN8, ULUSER AS USUARIO FROM SY900.F0092) WHERE F = 1 ORDER BY ULAN8) U ON E.ABAN8 = U.ULAN8 WHERE E.ABAT1 = 'E' AND E.ABDC LIKE '%" + nombre +"%'";
        }

        //public static string ADM_UsuarioBuscarEmp(string ID, string nombre)
        //{
        //    if (ID.Trim() != "")
        //        return "SELECT E.ABAN8 AS IDUSUARIO, E.ABTAX AS IDENTIFICACION, E.ABDC AS NOMBRE, '' AS USUARIO FROM TRNDTA.F0101 E WHERE E.ABAT1 = 'E' AND (E.ABAN8 = '" + ID + "' or ABALKY LIKE '%" + ID + "%')";
        //    else
        //        return "SELECT E.ABAN8 AS IDUSUARIO, E.ABTAX AS IDENTIFICACION, E.ABDC AS NOMBRE, '' AS USUARIO FROM TRNDTA.F0101 E WHERE E.ABAT1 = 'E' AND E.ABDC LIKE '%" + nombre + "%'";
        //}


    }
}
