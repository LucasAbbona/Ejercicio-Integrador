using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Integrador.Dates
{
    public class Fecha : ISettersAndGetters
    {
        public int anio;
        public int dia;
        public int mes;

        //Setters
        public void Establecer(int anio, int dia, int mes)
        {
            this.anio = anio;
            this.dia = DateValidations.validarDia(dia, mes, anio);
            this.mes = mes <= 12 && mes >= 1 ? mes : 0;
        }

        //Getters
        public int ObtenerDia()
        {
            return dia;
        }
        public int ObtenerMes()
        {
            return mes;
        }
        public int ObtenerAño()
        {
            return anio;
        }
        public override string ToString()
        {
            return $"{dia}/{mes}/{anio}";
        }
    }
}
