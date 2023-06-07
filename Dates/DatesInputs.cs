using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Integrador.Dates
{
    public class DatesInputs
    {
        public static void InsertandoFechas(Fecha fecha)
        {
            Console.WriteLine("Dia");
            int newDia = int.Parse(Console.ReadLine());
            Console.WriteLine("Mes");
            int newMes = int.Parse(Console.ReadLine());
            Console.WriteLine("Año");
            int newAño = int.Parse(Console.ReadLine());
            fecha.Establecer(newAño, newDia, newMes);
        }
    }
}
