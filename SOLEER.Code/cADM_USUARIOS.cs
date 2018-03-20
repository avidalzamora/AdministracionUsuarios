using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLEER.Code
{
    public class cADM_USUARIOS
    {
        public string IDUSUARIO { get; set; }
        public string NOMBRE { get; set; }
        public string NIDENTIFICACION { get; set; }
        public string CODAREA { get; set; }
        public string CODOFICINA { get; set; }
        public string CORREO { get; set; }
        public string PASSCORREO { get; set; }
        public string USUARIO { get; set; }
        public string CONTRASENA { get; set; }
        public int ESTADO { get; set; }
        public string USERREG { get; set; }
        public DateTime? FECHAREG { get; set; }
        public string PCREG { get; set; }
        public string USERMODIFY { get; set; }
        public DateTime? FECHAMODIFY { get; set; }
        public string PCMODIFY { get; set; }
        public string OBSERVACION { get; set; }

        public string AREA { get; set; }
        public string OFICINA { get; set; }

        public cADM_USUARIOS() { }

        public cADM_USUARIOS(string IDUSUARIO, string NOMBRE, string NIDENTIFICACION, string CODAREA, string CODOFICINA, string CORREO, string PASSCORREO, string USUARIO, string CONTRASENA, int ESTADO, string USERREG, DateTime? FECHAREG, string PCREG, string USERMODIFY, DateTime? FECHAMODIFY, string PCMODIFY, string OBSERVACION)
        {
            this.IDUSUARIO = IDUSUARIO;
            this.NOMBRE = NOMBRE;
            this.NIDENTIFICACION = NIDENTIFICACION;
            this.CODAREA = CODAREA;
            this.CODOFICINA = CODOFICINA;
            this.CORREO = CORREO;
            this.PASSCORREO = PASSCORREO;
            this.USUARIO = USUARIO;
            this.CONTRASENA = CONTRASENA;
            this.ESTADO = ESTADO;
            this.USERREG = USERREG;
            this.FECHAREG = FECHAREG;
            this.PCREG = PCREG;
            this.USERMODIFY = USERMODIFY;
            this.FECHAMODIFY = FECHAMODIFY;
            this.PCMODIFY = PCMODIFY;
            this.OBSERVACION = OBSERVACION;
        }

        public cADM_USUARIOS(string IDUSUARIO, string NOMBRE, string NIDENTIFICACION, string CODAREA, string CODOFICINA, string CORREO, string PASSCORREO, string USUARIO, int ESTADO, string USERREG, DateTime? FECHAREG, string PCREG, string USERMODIFY, DateTime? FECHAMODIFY, string PCMODIFY, string OBSERVACION, string AREA, string OFICINA)
        {
            this.IDUSUARIO = IDUSUARIO;
            this.NOMBRE = NOMBRE;
            this.NIDENTIFICACION = NIDENTIFICACION;
            this.CODAREA = CODAREA;
            this.CODOFICINA = CODOFICINA;
            this.CORREO = CORREO;
            this.PASSCORREO = PASSCORREO;
            this.USUARIO = USUARIO;
            this.ESTADO = ESTADO;
            this.USERREG = USERREG;
            this.FECHAREG = FECHAREG;
            this.PCREG = PCREG;
            this.USERMODIFY = USERMODIFY;
            this.FECHAMODIFY = FECHAMODIFY;
            this.PCMODIFY = PCMODIFY;
            this.OBSERVACION = OBSERVACION;
            this.AREA = AREA;
            this.OFICINA = OFICINA;
        }


        public cADM_USUARIOS(string IDUSUARIO, string NIDENTIFICACION, string NOMBRE, string USUARIO)
        {
            this.IDUSUARIO = IDUSUARIO;
            this.NIDENTIFICACION = NIDENTIFICACION;
            this.NOMBRE = NOMBRE;
            this.USUARIO = USUARIO;
        }
    }
}
