using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Integrador.Dates
{
    public static class DateActions
    {
        public static void AgregarDias(Fecha fecha, int dias)
        {
            fecha.dia += dias;
            while (fecha.dia > 31 && (fecha.mes == 1 || fecha.mes == 3 || fecha.mes == 5 || fecha.mes == 7 || fecha.mes == 8 || fecha.mes == 10 || fecha.mes == 12) || fecha.dia > 30 && (fecha.mes == 4 || fecha.mes == 6 || fecha.mes == 9 || fecha.mes == 11) || fecha.dia > 28 && fecha.mes == 2)
            {
                if (fecha.dia > 31 && (fecha.mes == 1 || fecha.mes == 3 || fecha.mes == 5 || fecha.mes == 7 || fecha.mes == 8 || fecha.mes == 10 || fecha.mes == 12))
                {
                    fecha.dia -= 31;
                    AgregarMes(fecha, 1);
                }
                else if (fecha.dia > 30 && (fecha.mes == 4 || fecha.mes == 6 || fecha.mes == 9 || fecha.mes == 11))
                {
                    fecha.dia -= 30;
                    AgregarMes(fecha, 1);
                }
                else if (!DateValidations.EsBisiesto(fecha.anio) && fecha.dia > 28 && fecha.mes == 2)
                {
                    fecha.dia -= 28;
                    AgregarMes(fecha, 1);
                }
                else if (DateValidations.EsBisiesto(fecha.anio) && fecha.dia > 29 && fecha.mes == 2)
                {
                    fecha.dia -= 29;
                    AgregarMes(fecha, 1);
                }
                else
                {
                    fecha.dia = fecha.dia + dias;
                }
            }
        }

        //Meses
        public static void AgregarMes(Fecha fecha, int meses)
        {
            int suma = fecha.mes + meses;
            if (suma > 12)
            {
                fecha.anio++;
                fecha.mes = suma - 12;
                while (fecha.mes > 12)
                {
                    fecha.mes = fecha.mes - 12;
                    fecha.anio++;
                }
            }
            else
            {
                fecha.mes = suma;
            }
        }
        public static void SacarMes(Fecha fecha, int meses)
        {
            int resta = fecha.mes - meses;
            if (resta < 1)
            {
                fecha.anio--;
                fecha.mes = 12 + fecha.mes - meses;
                while (fecha.mes < 1)
                {
                    fecha.mes = fecha.mes + 12;
                    fecha.anio--;
                }
            }
            else
            {
                fecha.mes = resta;
            }
        }
    }
}
