using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class Accion
    {
        public int idReporte { get; set; }
        public int idEmpleado { get; set; }
        public string fechaLimite { get; set; }
        public string fechaRealizado { get; set; }
        public string archivoEvidencia { get; set; }
        public string descripcion { get; set; }

    }
}
