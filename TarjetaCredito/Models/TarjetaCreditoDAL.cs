using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace TarjetaCredito.Models
{
    public class TarjetaCreditoDAL
    {
        public static List<TarjetaCredito> obtenerTarjetas()
        {
            List<TarjetaCredito> listadoTarjetas = new List<TarjetaCredito>();
            if (File.Exists(@"c:\users\carlos\Desktop\tarjetas.txt"))
            {
                TextReader lector = File.OpenText(@"c:\users\carlos\Desktop\tarjetas.txt");
                String linea;
                while ((linea = lector.ReadLine()) != null )
                {
                    listadoTarjetas.Add(new TarjetaCredito(linea));
                }
            }
            return listadoTarjetas;
                
        }

    }
}