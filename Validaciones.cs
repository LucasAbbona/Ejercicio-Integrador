using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Integrador
{
    public class Validaciones
    {
        public bool FechaValida(Fecha validaMax,Fecha aValidar)
        {
            if(validaMax.ObtenerAño() > aValidar.ObtenerAño())
            {
                return true;
            }
            else if(validaMax.ObtenerAño() == aValidar.ObtenerAño())
            {
                if (validaMax.ObtenerMes() > aValidar.ObtenerMes())
                {
                    return true;
                }else if(validaMax.ObtenerMes() == aValidar.ObtenerMes())
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
