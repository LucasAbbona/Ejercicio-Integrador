using System.Globalization;
using System.Net;

namespace Ejercicio_Integrador
{
    internal class Program
    {
        static bool Permanecer = true;
        static void Main(string[] args)
        {   
            // Datos de usuario
            Console.WriteLine("Bienvenido\nPrimero Necesitaremos sus datos personales\nIndique 1 para ingresar toda la informacion\nIndique 2 para ingresar solo la informacion necesaria");
            int Option = int.Parse(Console.ReadLine());
            var persona = EstablecerSolicitante(Option);

            //Datos para prestamo
            Random random = new Random();
            Banco banco = new Banco();
            Validaciones validaciones = new Validaciones();

            //Solicitar monto a prestar
            Console.WriteLine("Ingrese Monto total a prestar");
            double patrimonio = double.Parse(Console.ReadLine());
            banco.Establecer(patrimonio);
            
            //Fecha de Autorizacion maxima
            Console.WriteLine("Ingrese fecha maxima para autorizar prestamos");
            Fecha autorizacionMax = new Fecha();
            InsertandoFechas(autorizacionMax);

            while(Permanecer)
            {
                Prestamo prestamo = new Prestamo();
                bool MontoValido = false;
                while (!MontoValido)
                {
                    Console.WriteLine("Ahora indique el monto del prestamo requerido");
                    double Monto = double.Parse(Console.ReadLine());
                    if (banco.Prestamo(Monto))
                    {
                        MontoValido=true;
                        //Estableciendo prestamo
                        prestamo.Establecer(persona,random.Next(1,int.MaxValue),Monto);
                        
                        //Estableciendo Fecha de Autorizacion
                        Fecha autorizacion = new Fecha();
                        bool Valido = false;
                        while (!Valido)
                        {
                            Console.WriteLine("Indique Fecha de Hoy");
                            InsertandoFechas(autorizacion);
                            if(validaciones.FechaValida(autorizacionMax, autorizacion))
                            {
                                prestamo.EstablecerFechaAutorizacion(autorizacion);
                                //Estableciendo Fecha de entrega y pagos
                                Fecha paraEntrega = new Fecha();
                                paraEntrega.Establecer(autorizacion.ObtenerAño(), autorizacion.ObtenerDia(), autorizacion.ObtenerMes());
                                prestamo.EstablecerFechaEntrega(paraEntrega);
                                prestamo.EstablecerFechasPago(paraEntrega);
                                //Archivando Prestamo en el banco
                                banco.RealizarTransacion(Monto);
                                banco.NuevoPrestamo(prestamo);
                                //Informacion del prestamo
                                VerInfoPrestamo(prestamo);
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
                
                //Salir del programa
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

        //User Inputs Methods
        static void InsertandoFechas(Fecha fecha)
        {
            Console.WriteLine("Dia");
            int newDia = int.Parse(Console.ReadLine());
            Console.WriteLine("Mes");
            int newMes = int.Parse(Console.ReadLine());
            Console.WriteLine("Año");
            int newAño = int.Parse(Console.ReadLine());
            fecha.Establecer(newAño, newDia, newMes);
        }
        static void VerInfoPrestamo(Prestamo prestamo)
        {
            Console.WriteLine("1-Ver Toda la informacion del prestamo");
            Console.WriteLine("2-Ver Fecha de Autorizacion");
            Console.WriteLine("3-Ver Monto del prestamo");
            int Eleccion = int.Parse(Console.ReadLine());
            if( Eleccion >= 1 && Eleccion <= 3)
            {
                switch( Eleccion )
                {
                    case 1:
                        prestamo.Imprimir();
                    break;
                    case 2:
                        prestamo.ObtenerFechaAutorizacion().Imprimir();
                        break;
                    case 3:
                        Console.WriteLine($"${prestamo.ObtenerValor()}");
                        break;
                }
            }
        }
        static Persona EstablecerSolicitante(int Option)
        {
            Persona persona = new Persona();
            switch (Option)
            {
                case 1:
                    Fecha nacimiento = new Fecha();
                    nacimiento.Establecer(2004, 28, 12);
                    NumeroTelefonico casa = new NumeroTelefonico();
                    casa.Establecer(2315, 65489, 6546, 98795);
                    NumeroTelefonico movil = new NumeroTelefonico();
                    movil.Establecer(1215, 34589, 4566, 34795);
                    NumeroTelefonico oficina = new NumeroTelefonico();
                    oficina.Establecer(7567, 65569, 5676, 23456);
                    persona.Establecer(46111439, "Lucas", "Abbona", "Agustin", "", nacimiento, casa, movil, oficina);
                    return persona;
                    break;
                case 2:
                    Fecha nacimiento_ = new Fecha();
                    nacimiento_.Establecer(2004, 28, 12);
                    NumeroTelefonico casa_ = new NumeroTelefonico();
                    casa_.Establecer(2315, 65489, 6546, 98795);
                    NumeroTelefonico movil_ = new NumeroTelefonico();
                    movil_.Establecer(1215, 34589, 4566, 34795);
                    persona.EstablecerDatosRequeridos(46111439, "Lucas", "Abbona", nacimiento_, casa_, movil_);
                    return persona;
                    break;
                default:
                    return persona;
                    break;
            }

        }
    }
}