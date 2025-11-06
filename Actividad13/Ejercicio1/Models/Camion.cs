using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    public class Camion
    {
        private double pesoControl;
        private Stack<Paquete> manifiesto=new Stack<Paquete>();

        public int Patente { get; set; }
        public double PesoMax { get; set; }

        public Camion(int patente, double peso)
        { 
            Patente = patente;
            PesoMax= peso;
        }


        public bool AgregarPaquete(Paquete unPaquete)
        {
            if (unPaquete == null) throw new Exception("Paquete Nulo");
            if(unPaquete.Peso+pesoControl > PesoMax) return false;

            manifiesto.Push(unPaquete);
            pesoControl += unPaquete.Peso;
            return true;
        }

        public double CargaEnKg()
        {
            return pesoControl;        
        }

        public Paquete QuitarPaquete()
        { 
            return manifiesto.Pop();
        }

        public string[] VerCarga()
        {
            string[] carga=new string[manifiesto.Count];
            int n = 0;
            foreach (Paquete v in manifiesto)
            {
                carga[n] = v.ToString();
                ++n;
            }
            return carga;
        }

    }
}
