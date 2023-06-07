using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Integrador
{
    public class Exit
    {
        public static void ExitProgram(ref bool Permanecer,Banco banco)
        {
            Console.WriteLine("Desea salir del programa?");
                    string Salir = Console.ReadLine();
                    if(Salir.ToLower() == "si")
                    {
                        Console.WriteLine($"Se ha prestado un total de ${banco.Prestado()} y quedan disponibles ${banco.Disponible()}");
                        Permanecer = false;   
                    }
                    else
                    {
                        Permanecer = true;
                    }
        }
    }
}
