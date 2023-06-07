using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio_Integrador.Dates;

namespace Ejercicio_Integrador.Prestamo
{
    public class Prestamo : ISettersAndGetters
    {
        private int NumeroDePrestamo;
        private double Valor;
        private List<FechaDePago> FechasDePago = new List<FechaDePago>();
        private Fecha FechaDeAutorizacion;
        private Fecha FechaDeEntrega;
        private Persona.Persona Solicitante;
        private double PatrimonioTotal = 100000000;
        private double RestanteAPagar;
        //Setters

        public void Establecer(Persona.Persona solicitante, int numero, double monto)
        {
            if (numero > 0)
            {
                NumeroDePrestamo = numero;
            }
            else
            {
                Console.WriteLine("Numero de Prestamo Incorrecto");
            }
            if (monto > 0 && monto < PatrimonioTotal)
            {
                if (PatrimonioTotal - monto > 0)
                {
                    Valor = monto;
                    PatrimonioTotal -= monto;
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
            if (Valor > 100000)
            {
                DateActions.AgregarDias(autorizacionReferencia, 10);
            }
            else
            {
                DateActions.AgregarDias(autorizacionReferencia, 7);
            }
            Fecha entrega = new Fecha();
            entrega.Establecer(autorizacionReferencia.anio, autorizacionReferencia.dia, autorizacionReferencia.mes);
            FechaDeEntrega = entrega;
        }
        public void EstablecerFechasPago(Fecha FechaDeReferencia, int coutas)
        {
            if (coutas > 0 && coutas <= 12)
            {
                double PrecioPorCouta = Valor / coutas;
                RestanteAPagar = Valor;
                for (int i = 1; i <= coutas; i++)
                {
                    DateActions.AgregarDias(FechaDeReferencia, 30);
                    Fecha fecha = new Fecha();
                    fecha.Establecer(FechaDeReferencia.anio, FechaDeReferencia.dia, FechaDeReferencia.mes);
                    RestanteAPagar -= PrecioPorCouta;
                    FechaDePago fechaDePago = new FechaDePago(fecha, PrecioPorCouta, RestanteAPagar);
                    FechasDePago.Add(fechaDePago);
                }
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
        public int ObtenerNumeroDeSerie()
        {
            return NumeroDePrestamo;
        }

        // Imprimir datos del prestamo
        public void Imprimir()
        {
            Console.WriteLine($"El Prestamo N°{NumeroDePrestamo} \nPerteneciente a {Solicitante.ObtenerPrimerNombre()} \nCon Valor de ${Valor}\n Autorizado:");
            Console.WriteLine(FechaDeAutorizacion.ToString());
            Console.WriteLine($"Entregado:");
            Console.WriteLine(FechaDeEntrega.ToString());
            int i = 1;
            foreach (FechaDePago fecha in FechasDePago)
            {
                Console.Write($"Fecha de Pago N°{i}: ");
                Console.WriteLine(fecha.FechaDePagoDeCouta.ToString());
                Console.WriteLine($"Monto a pagar: ${fecha.MontoAPagar.ToString("F2")}\nRestante por Pagar: ${fecha.RestoApagar.ToString("F2")}\n");
                i++;
            }
            Console.ReadLine();
        }
    }
}
