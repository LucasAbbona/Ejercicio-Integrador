using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Ejercicio_Integrador.Dates;

namespace Ejercicio_Integrador.Prestamo
{
    public class PrestamoCreacion
    {
        static Random random = new Random();
        public static void CreandoPrestamos(Persona.Persona persona, Banco banco, Fecha autorizacionMax)
        {
            Prestamo prestamo = new Prestamo();

            bool MontoValido = false;
            while (!MontoValido)
            {
                double Monto = SetMonto();
                if (banco.Prestamo(Monto))
                {
                    MontoValido = true;
                    //Estableciendo prestamo
                    prestamo.Establecer(persona, random.Next(1, int.MaxValue), Monto);
                    //Estableciendo Fecha de Autorizacion
                    Fecha autorizacion = new Fecha();
                    bool Valido = false;
                    while (!Valido)
                    {
                        Console.WriteLine("Indique Fecha de Hoy");
                        DatesInputs.InsertandoFechas(autorizacion);
                        if (DateValidations.FechaValida(autorizacionMax, autorizacion))
                        {
                            EstableciendoPrestamoFechas(autorizacion, prestamo);
                            //Archivando Prestamo en el banco
                            banco.RealizarTransacion(Monto);
                            banco.NuevoPrestamo(prestamo);
                            //Informacion del prestamo
                            prestamo.Imprimir();
                            //Total Prestado
                            Console.WriteLine($"${banco.Prestado()} Prestado");
                            Valido = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Monto no disponible");
                }
            }
        }
        static double SetMonto()
        {
            Console.WriteLine("Ahora indique el monto del prestamo requerido");
            double Monto;
            double.TryParse(Console.ReadLine(), out Monto);
            return Monto;
        }
        static void EstableciendoPrestamoFechas(Fecha autorizacion, Prestamo prestamo)
        {
            prestamo.EstablecerFechaAutorizacion(autorizacion);
            //Estableciendo Fecha de entrega y pagos
            Fecha paraEntrega = new Fecha();
            paraEntrega.Establecer(autorizacion.ObtenerAño(), autorizacion.ObtenerDia(), autorizacion.ObtenerMes());
            prestamo.EstablecerFechaEntrega(paraEntrega);
            EstableciendoCoutas(paraEntrega, prestamo);
        }
        static void EstableciendoCoutas(Fecha paraEntrega, Prestamo prestamo)
        {
            Console.WriteLine("Indique coutas a pagar. Maximo 12, Minimo 1");
            int coutas;
            int.TryParse(Console.ReadLine(), out coutas);
            prestamo.EstablecerFechasPago(paraEntrega, coutas);
        }
    }
}
