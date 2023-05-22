using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Integrador
{
    public class Prestamo : ISettersAndGetters
    {
        int NumeroDePrestamo;
        double Valor;
        List<Fecha> FechasDePago = new List<Fecha>();
        Fecha FechaDeAutorizacion;
        Fecha FechaDeEntrega;
        Persona Solicitante;
        double PatrimonioTotal = 100000000;
  
        //Setters
        
        public void Establecer(Persona solicitante, int numero,double monto)
        {
            if(numero > 0)
            {
                NumeroDePrestamo = numero;
            }
            else
            {
                Console.WriteLine("Numero de Prestamo Incorrecto");
            }
            if(monto > 0 && monto < PatrimonioTotal)
            {
                if (PatrimonioTotal - monto > 0)
                {
                    Valor = monto;
                    PatrimonioTotal-= monto;
                }
                else
                {
                    Console.WriteLine("Se ha superado el maximo monto a pedir");
                }
            }
            else
            {
                Console.WriteLine("El Valor del prestamo debe ser mayor a $0 y menor al maximo permitido");
            }
            Solicitante = solicitante;
        }

        //Fechas
        public void EstablecerFechaAutorizacion(Fecha autorizacion)
        {
                FechaDeAutorizacion = autorizacion;  
        }
        public void EstablecerFechaEntrega(Fecha autorizacionReferencia)
        {
            if(Valor > 100000)
            {
                autorizacionReferencia.AgregarDias(10);
            }
            else
            {
                autorizacionReferencia.AgregarDias(7);
            }
            Fecha entrega = new Fecha();
            entrega.Establecer(autorizacionReferencia.anio, autorizacionReferencia.dia, autorizacionReferencia.mes);
            FechaDeEntrega = entrega;
        }
        public void EstablecerFechasPago(Fecha FechaDeReferencia)
        {
            for(int i = 1; i<=6; i++)
            {
                FechaDeReferencia.AgregarDias(30);
                Fecha fecha = new Fecha();
                fecha.Establecer(FechaDeReferencia.anio, FechaDeReferencia.dia, FechaDeReferencia.mes);
                FechasDePago.Add(fecha);
            }
        }

        //Getters
        public Fecha ObtenerFechaAutorizacion()
        {
            return FechaDeAutorizacion;
        }
        public double ObtenerValor()
        {
            return Valor;
        }

        // Imprimir datos del prestamo
        public void Imprimir()
        {
            Console.WriteLine($"El Prestamo N°{NumeroDePrestamo} \nPerteneciente a {Solicitante.ObtenerPrimerNombre()} \nCon Valor de ${Valor}\n Autorizado:");
            FechaDeAutorizacion.Imprimir();
            Console.WriteLine($"Entregado:");
            FechaDeEntrega.Imprimir();
            int i = 1;
            foreach(Fecha fecha in FechasDePago)
            {
                Console.WriteLine($"Fecha de Pago N°{i}:");
                fecha.Imprimir();
                i++;
            }
            Console.ReadLine();
        }
    }
}
