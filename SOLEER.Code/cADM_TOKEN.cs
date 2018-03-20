using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLEER.Code
{
    public class cADM_TOKEN
    {
        public int IDTOKEN { get; set; }
        public string USUARIO { get; set; }
        public string TOKEN { get; set; }
        public DateTime? FECHACREACION { get; set; }
        public DateTime? FECHAACTUALIZA { get; set; }
        public DateTime? FECHAEXPIRA { get; set; }
        public int EXPIRADO { get; set; }
        public string PPCREG { get; set; }

        public cADM_TOKEN() { }

        public cADM_TOKEN(int IDTOKEN, string USUARIO, string TOKEN, DateTime? FECHACREACION, DateTime? FECHAACTUALIZA, DateTime? FECHAEXPIRA, int EXPIRADO, string PPCREG)
        {
            this.IDTOKEN = IDTOKEN;
            this.USUARIO = USUARIO;
            this.TOKEN = TOKEN;
            this.FECHACREACION = FECHACREACION;
            this.FECHAACTUALIZA = FECHAACTUALIZA;
            this.FECHAEXPIRA = FECHAEXPIRA;
            this.EXPIRADO = EXPIRADO;
            this.PPCREG = PPCREG;
        }

    }
}
