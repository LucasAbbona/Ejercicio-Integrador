using System.Globalization;
using System.Net;
using Ejercicio_Integrador.Dates;

namespace Ejercicio_Integrador
{
    internal class Program
    {
        static bool Permanecer = true;
        static void Main(string[] args)
        {   
            var persona = UserInput.Bienvenida();
            
            //Datos para prestamo
            Banco banco = new Banco();

            //Solicitar Patrimonio del banco
            Console.WriteLine("Ingrese Patrimonio total");
            double patrimonio;
            double.TryParse(Console.ReadLine(),out patrimonio);
            banco.Establecer(patrimonio);
            
            //Fecha de Autorizacion maxima
            Console.WriteLine("Ingrese fecha maxima para autorizar prestamos");
            Fecha autorizacionMax = new Fecha();
            DatesInputs.InsertandoFechas(autorizacionMax);
            while(Permanecer)
            {
                //Menu
                Menu.ShowMenu(persona, banco, autorizacionMax,ref Permanecer);
            }
        }
    }
}