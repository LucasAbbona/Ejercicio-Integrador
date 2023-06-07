using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio_Integrador.Dates;
using Ejercicio_Integrador.Prestamo;

namespace Ejercicio_Integrador
{
    public class Menu
    {
        public static void ShowMenu(Persona.Persona persona,Banco banco,Fecha autorizacionMax,ref bool Continue)
        {
            Console.WriteLine("--Menu--\n1-Nuevo Prestamo\n2-Ver Prestamos\n3-Salir");
            int.TryParse(Console.ReadLine(), out var Selection);
            if(Selection == 1)
            {
                PrestamoCreacion.CreandoPrestamos(persona, banco,autorizacionMax);
                Exit.ExitProgram(ref Continue, banco);
            }
            else if(Selection == 2)
            {
                Console.WriteLine("Indique Numero de identificacion del Prestamo");
                int.TryParse(Console.ReadLine(), out var ID);
                banco.Imprimir(ID);
                Exit.ExitProgram(ref Continue, banco);
            }
            else if(Selection == 3)
            {
                Exit.ExitProgram(ref Continue,banco);
            }
        }
    }
}
