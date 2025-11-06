using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    public class Paquete
    {

        private int nroRegistro;
        private double peso;
        private string zonaDestino;
        public int NroRegistro{get;set;}
        public double Peso { get; set; }
        public string ZonaDestino { get; set; }

        public Paquete(int id, double peso, string zona)
        { 
        
            NroRegistro = id;
            Peso = peso;
            ZonaDestino = zona;
        
        }

        public override string ToString()
        {
            return $"Registro {NroRegistro} Peso{Peso} Zona Destiino:{ZonaDestino}"; 
        }

    }
}
