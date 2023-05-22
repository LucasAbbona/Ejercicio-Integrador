using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Integrador
{
    public class Banco
    {
        List<Prestamo> prestamosList = new List<Prestamo>();
        double Patrimonio;
        
        //Setters
        public void Establecer(double partrimony)
        {
            Patrimonio = partrimony;
        }
        public bool Prestamo(double monto)
        {
            if (monto>0 && monto <= Patrimonio) 
            {
                Console.WriteLine("Prestamo disponible");
                return true;
            }
            else if(monto <= 0)
            {
                Console.WriteLine("Recuerde ingresar un monto mayor a 0");
                return false;
            }
            else
            {
                Console.WriteLine("El monto sobrepasa el limite permitido");
                return false;
            }
        } 
        public void RealizarTransacion(double monto)
        {
            Patrimonio -= monto;
        }
        public void NuevoPrestamo(Prestamo prestamo)
        {
            prestamosList.Add(prestamo);
        }

        //Getters
        public double Prestado()
        {
            double TotalPrestado = 0;
            foreach(Prestamo prestamo in prestamosList)
            {
                TotalPrestado += prestamo.ObtenerValor();
            }
            return TotalPrestado;
        }
        public double Disponible()
        {
            return Patrimonio;                       
        }
        public void Imprimir()
        {
            foreach(Prestamo prestamos in  prestamosList)
            {
                prestamos.Imprimir();
            }
        }
    }
}
