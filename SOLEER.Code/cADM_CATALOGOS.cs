using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLEER.Code
{
    public class cADM_CATALOGOS
    {
        public int IDREG { get; set; }
        public int CODTBL { get; set; }
        public string NOMBRE { get; set; }
        public string IDCAT { get; set; }
        public string CONCEPTO { get; set; }
        public string DETALLE { get; set; }
        public string DETALLE2 { get; set; }
        public string GRUPO { get; set; }
        public int ESTADO { get; set; }
        public DateTime? FECHAREG { get; set; }
        public string USERREG { get; set; }
        public string PCREG { get; set; }
        public DateTime? FECHAMODIFY { get; set; }
        public string USERMODIFY { get; set; }
        public string PCMODIFY { get; set; }

        public cADM_CATALOGOS() { }

        public cADM_CATALOGOS(int IDREG, int CODTBL, string NOMBRE, string IDCAT, string CONCEPTO, string DETALLE, string DETALLE2, string GRUPO, int ESTADO, DateTime? FECHAREG, string USERREG, string PCREG, DateTime? FECHAMODIFY, string USERMODIFY, string PCMODIFY)
        {
            this.IDREG = IDREG;
            this.CODTBL = CODTBL;
            this.NOMBRE = NOMBRE;
            this.IDCAT = IDCAT;
            this.CONCEPTO = CONCEPTO;
            this.DETALLE = DETALLE;
            this.DETALLE2 = DETALLE2;
            this.GRUPO = GRUPO;
            this.ESTADO = ESTADO;
            this.FECHAREG = FECHAREG;
            this.USERREG = USERREG;
            this.PCREG = PCREG;
            this.FECHAMODIFY = FECHAMODIFY;
            this.USERMODIFY = USERMODIFY;
            this.PCMODIFY = PCMODIFY;
        }


        public cADM_CATALOGOS(int CODTBL, string NOMBRE, string DETALLE, string DETALLE2)
        {
            this.CODTBL = CODTBL;
            this.NOMBRE = NOMBRE;
            this.DETALLE = DETALLE;
            this.DETALLE2 = DETALLE2;
        }
    }
}
