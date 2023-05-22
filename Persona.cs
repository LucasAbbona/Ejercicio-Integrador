using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Integrador
{
    public class Persona : ISettersAndGetters
    {
        Fecha FechaDeNacimiento;
        long identidad;
        string PrimerApellido;
        string PrimerNombre;
        string SegundoApellido;
        string SegundoNombre;
        NumeroTelefonico telefonoCasa;
        NumeroTelefonico telefonoMovil;
        NumeroTelefonico telefonoOficina;
        
        //Methods
        public void Establecer(long dni, string nombre, string apellido,string segundoNombre,string segundoApellido,Fecha nacimiento, NumeroTelefonico casa, NumeroTelefonico movil, NumeroTelefonico oficina)
        {
            identidad = dni;
            PrimerApellido = apellido;
            PrimerNombre = nombre;
            SegundoApellido = segundoApellido;
            SegundoNombre = segundoNombre;
            FechaDeNacimiento = nacimiento;
            telefonoCasa = casa;
            telefonoMovil = movil;
            telefonoOficina = oficina;
        }
        public void EstablecerDatosRequeridos(long dni, string nombre, string apellido, Fecha nacimiento, NumeroTelefonico casa, NumeroTelefonico movil)
        {
            identidad = dni;
            PrimerApellido = apellido;
            PrimerNombre = nombre;
            FechaDeNacimiento = nacimiento;
            telefonoCasa = casa;
            telefonoMovil = movil;
        }

        // Operation Methods
        public int CalcularEdad(Fecha hoy)
        {
            if(hoy.mes > FechaDeNacimiento.mes || (hoy.mes == FechaDeNacimiento.mes && hoy.dia >= FechaDeNacimiento.dia))
            {
                return hoy.anio - FechaDeNacimiento.anio;
            }else
            {
                return hoy.anio - FechaDeNacimiento.anio - 1; 
            }
        }

        // Setters
        
        public void EstablecerIdentidad(long dni)
        {
            identidad = dni;
        }
        public void EstablecerFechaDeNacimiento(Fecha nacimiento)
        {
            FechaDeNacimiento = nacimiento;
        }
        
        // Nombres y Apellidos
        public void EstablecerPrimerNombre(string name)
        {
            PrimerNombre = name;
        }
        public void EstablecerPrimerApellido(string lastname) 
        {
            PrimerApellido = lastname;
        }
        public void EstablecerSegundoNombre(char Secondname)
        {
            PrimerNombre = Secondname.ToString();
        }
        public void EstablecerSegundoApellido(char Secondlastname)
        {
            PrimerApellido = Secondlastname.ToString();
        }
        //Telefonos
        public void EstablecerTelefonoCasa(NumeroTelefonico casa)
        {
            telefonoCasa = casa;
        }
        public void EstablecerTelefonoMovil(NumeroTelefonico movil)
        {
            telefonoMovil = movil;
        }
        public void EstablecerTelefonoOficina(NumeroTelefonico oficina)
        {
            telefonoOficina = oficina;
        }

        // Getters
        public Fecha ObtenerFechaNacimiento()
        {
            return FechaDeNacimiento;
        }
        public long ObtenerIdentidad()
        {
            return identidad;
        }
        public string ObtenerPrimerNombre()
        {
            return PrimerNombre;
        }
        public string ObtenerPrimerApellido()
        {
            return PrimerApellido;
        }
        public string ObtenerSegundoNombre()
        {
            return SegundoNombre;
        }
        public string ObtenerSegundoApellido()
        {
            return SegundoApellido;
        }
        public NumeroTelefonico ObtenerTelefonoCasa()
        {
            return telefonoCasa;
        }
        public NumeroTelefonico ObtenerTelefonoMovil()
        {
            return telefonoMovil;
        }
        public NumeroTelefonico ObtenerTelefonoOficina()
        {
            return telefonoOficina;
        }
        public void Imprimir() 
        {
            Console.WriteLine($"Identificacion: {identidad}\n Nombre Completo: {PrimerNombre} {PrimerApellido} {SegundoNombre} {SegundoApellido}\n");
            Console.WriteLine($"Fecha de Nacimiento:{FechaDeNacimiento}\nTelefonos\nOficina: {telefonoOficina}\nMovil: {telefonoMovil}\nCasa: {telefonoCasa}"); ;
        }
    }
}
