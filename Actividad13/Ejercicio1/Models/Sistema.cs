using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    public class Sistema
    {
        public List<Paquete> listaPaquetes=new List<Paquete>();
        private List<Camion> listaCamiones=new List<Camion>();

        public Sistema() 
        {
            listaCamiones.Add(new Camion(100, 1000));
            listaCamiones.Add(new Camion(101, 1000));
            listaCamiones.Add(new Camion(102, 1000));
        }

        public void Descargar(FileStream fs)
        {
            StreamReader sr = new StreamReader(fs);
            while (sr.EndOfStream==false)
            {
                string linea=sr.ReadLine();
                string[] datos = linea.Split(';');
                int id=Convert.ToInt32(datos[0]);
                double peso=Convert.ToDouble(datos[1]);
                string zona=datos[2];

                Paquete unPaquete = new Paquete(id, peso, zona);
                listaPaquetes.Add(unPaquete);
            }
            sr.Close();
        }

        public void RetirarCamion(FileStream fs,int posicion)
        { 
            StreamWriter sw=new StreamWriter(fs);
            Camion c=listaCamiones[posicion];
            foreach(string p in c.VerCarga())
            {
                sw.WriteLine(p);
            }
            sw.Close();
        }

        public string[] CamionesCargados()
        {
            string[] cs = new string[listaCamiones.Count];
            int n = 0;
            foreach (Camion c in listaCamiones)
            {
                cs[n++] = $"{c.Patente}({c.PesoMax})";
            }
            return cs;
        }

        public double CargarPaquete(int camionElegido, Paquete seleccionado)
        {
            Camion c = listaCamiones[camionElegido];
            if (c.AgregarPaquete(seleccionado) == true)
            {
                listaPaquetes.Remove(seleccionado);
            }
            return c.CargaEnKg();
        }

    }
}
