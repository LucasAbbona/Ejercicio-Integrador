using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio_Integrador.Dates;

namespace Ejercicio_Integrador
{
    public class UserInput
    {
        public static Persona.Persona Bienvenida()
        {
            // Datos de usuario
            Console.WriteLine("Bienvenido\nPrimero Necesitaremos sus datos personales\nIndique 1 para ingresar toda la informacion\nIndique 2 para ingresar solo la informacion necesaria");
            int Option = int.Parse(Console.ReadLine());
            Persona.Persona persona = EstablecerSolicitante(Option);
            return persona;
        }
        public static Persona.Persona EstablecerSolicitante(int Option)
        {
            var persona = new Persona.Persona();
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
                case 2:
                    Fecha nacimiento_ = new Fecha();
                    nacimiento_.Establecer(2004, 28, 12);
                    NumeroTelefonico casa_ = new NumeroTelefonico();
                    casa_.Establecer(2315, 65489, 6546, 98795);
                    NumeroTelefonico movil_ = new NumeroTelefonico();
                    movil_.Establecer(1215, 34589, 4566, 34795);
                    persona.EstablecerDatosRequeridos(46111439, "Lucas", "Abbona", nacimiento_, casa_, movil_);
                    return persona;
                default:
                    return persona;
            }
        }
    }
}
