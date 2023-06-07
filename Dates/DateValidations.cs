using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Integrador.Dates
{
    public class DateValidations
    {
        public static bool EsBisiesto(int año)
        {
            return DateTime.IsLeapYear(año);
        }
        public static int validarDia(int dia, int mes, int anio)
        {
            if (dia >= 1 && dia <= 31 && (mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12))
            {
                return dia;
            }
            else if (dia >= 1 && dia <= 30 && (mes == 4 || mes == 6 || mes == 9 || mes == 11))
            {
                return dia;
            }
            else if (EsBisiesto(anio) && dia >= 1 && dia <= 29 && mes == 2)
            {
                return dia;
            }
            else if (!EsBisiesto(anio) && dia >= 1 && dia <= 28 && mes == 2)
            {
                return dia;
            }
            else
            {
                return -1;
            }
        }
        public static bool FechaValida(Fecha validaMax, Fecha aValidar)
        {
            if (validaMax.ObtenerAño() > aValidar.ObtenerAño())
            {
                return true;
            }
            else if (validaMax.ObtenerAño() == aValidar.ObtenerAño())
            {
                if (validaMax.ObtenerMes() > aValidar.ObtenerMes())
                {
                    return true;
                }
                else if (validaMax.ObtenerMes() == aValidar.ObtenerMes())
                {
                    if (validaMax.ObtenerDia() >= aValidar.ObtenerDia())
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Fecha No valida");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Fecha No valida");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Fecha No valida");
                return false;
            }
        }
    }
}
