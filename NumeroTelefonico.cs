using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Integrador
{
    public class NumeroTelefonico
    {
        private int codigoArea;
        private int extension;
        private int intercambio;
        private int linea;

        //Setters
        public void Establecer(int codigoArea, int extension, int intercambio, int linea)
        {
            this.codigoArea = codigoArea;
            this.extension = extension;
            this.intercambio = intercambio;
            this.linea = linea;
        }

        //Getters
        public override string ToString()
        {
            return $"Codigo de area: {codigoArea}\n Extension: {extension}\nIntercambio: {intercambio}\nLinea: {linea}";
        }

    }
}
