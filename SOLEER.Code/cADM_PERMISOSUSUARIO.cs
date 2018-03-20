using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLEER.Code
{
    public class cADM_PERMISOSUSUARIO
    {
        public int IDPERMISO { get; set; }
        public string IDUSUARIO { get; set; }
        public string IDFORMULARIO { get; set; }
        public int TIENEPERMISO { get; set; }
        public int ACTIVO { get; set; }
        public DateTime? FECHAREG { get; set; }
        public string USERREG { get; set; }
        public string PCREG { get; set; }

        public string FORMULARIO { get; set; }

        public cADM_PERMISOSUSUARIO() { }

        public cADM_PERMISOSUSUARIO(int IDPERMISO, string IDUSUARIO, string IDFORMULARIO, int TIENEPERMISO, int ACTIVO, DateTime? FECHAREG, string USERREG, string PCREG)
        {
            this.IDPERMISO = IDPERMISO;
            this.IDUSUARIO = IDUSUARIO;
            this.IDFORMULARIO = IDFORMULARIO;
            this.TIENEPERMISO = TIENEPERMISO;
            this.ACTIVO = ACTIVO;
            this.FECHAREG = FECHAREG;
            this.USERREG = USERREG;
            this.PCREG = PCREG;
        }

        public cADM_PERMISOSUSUARIO(int IDPERMISO, string IDUSUARIO, string IDFORMULARIO, int TIENEPERMISO, int ACTIVO, string FORMULARIO)
        {
            this.IDPERMISO = IDPERMISO;
            this.IDUSUARIO = IDUSUARIO;
            this.IDFORMULARIO = IDFORMULARIO;
            this.TIENEPERMISO = TIENEPERMISO;
            this.ACTIVO = ACTIVO;
            this.FORMULARIO = FORMULARIO;
        }
    }
}
