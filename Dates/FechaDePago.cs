using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Integrador.Dates
{
    public class FechaDePago
    {
        public Fecha FechaDePagoDeCouta { get; set; }
        public double MontoAPagar { get; set; }
        public double RestoApagar { get; set; }
        public FechaDePago(Fecha fecha, double monto, double FaltanteApagar)
        {
            FechaDePagoDeCouta = fecha;
            MontoAPagar = monto;
            RestoApagar = FaltanteApagar;
        }
    }
}
