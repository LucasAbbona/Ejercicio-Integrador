using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio_Integrador.Dates;

namespace Ejercicio_Integrador.Persona
{
    public class PersonaService
    {
        public int CalcularEdad(Fecha hoy, Persona persona)
        {
            if (hoy.mes > persona.ObtenerFechaNacimiento().mes || hoy.mes == persona.ObtenerFechaNacimiento().mes && hoy.dia >= persona.ObtenerFechaNacimiento().dia)
            {
                return hoy.anio - persona.ObtenerFechaNacimiento().anio;
            }
            else
            {
                return hoy.anio - persona.ObtenerFechaNacimiento().anio - 1;
            }
        }
    }
}
