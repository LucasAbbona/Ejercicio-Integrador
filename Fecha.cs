using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Integrador
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
            this.dia = validarDia(dia, mes);
            this.mes = mes <= 12 && mes >= 1 ? mes : 0;
        }
        //Validacion de Año
        public bool EsBisiesto(int año)
        {
            return DateTime.IsLeapYear(año);
        }
        //Validacion de Dia
        public int validarDia(int dia, int mes)
        {
                if(dia>=1 && dia <=31 && (mes==1 || mes == 3 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12))
                {
                    return dia;
                }
                else if(dia>=1 && dia <=30 && (mes == 4 || mes == 6 || mes== 9 || mes == 11))
                {
                    return dia;
                }
                else if(EsBisiesto(this.anio) && dia>=1 && dia <= 29 && mes==2)
                {
                    return dia;
                }
                else if(!EsBisiesto(this.anio) && dia >= 1 && dia <= 28 && mes == 2)
                {
                    return dia;
                }
                else
                {
                    return -1;
                }
        }
        public void AgregarDias(int dias)
        {
            dia += dias;
            while((dia > 31 && (mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12)) || (dia > 30 && (mes == 4 || mes == 6 || mes == 9 || mes == 11)) || (dia > 28 && mes==2))
            {
                if (dia > 31 && (mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12))
                {
                    dia -= 31;
                    AgregarMes(1);
                }
                else if(dia > 30 && (mes == 4 || mes == 6 || mes == 9 || mes == 11))
                {
                    dia -= 30;
                    AgregarMes(1);
                }
                else if(!EsBisiesto(this.anio) && dia > 28 && mes == 2)
                {
                    dia -= 28;
                    AgregarMes(1);
                }else if(EsBisiesto(this.anio) && dia > 29 && mes == 2)
                {
                    dia -= 29;
                    AgregarMes(1);
                }
                else
                {
                    dia = dia + dias;
                }
            }
        }

        //Meses
        public void AgregarMes(int meses)
        {
            int suma = mes + meses;
            if(suma > 12)
            {
                anio ++;
                mes = suma - 12;
                while (mes > 12)
                {
                    mes = mes - 12;
                    anio++;
                }
            }
            else
            {
                mes = suma;
            }
        }
        public void SacarMes(int meses)
        {
            int resta = mes - meses;
            if(resta < 1)
            {
                anio--;
                mes = 12 + mes - meses;
                while(mes < 1)
                {
                    mes = mes + 12;
                    anio --;
                }
            }
            else
            {
                mes = resta;
            }
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
        public void Imprimir()
        {
            Console.WriteLine($"{dia}/{mes}/{anio}");
        }
    }
}
