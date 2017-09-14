using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace TarjetaCredito.Models
{
    public class TarjetaCredito
    {
        public string numero { get; set; }

        public TarjetaCredito(string numero)
        {
            this.numero = numero;
        }

        public bool validar()
        {
            if (!new Regex(@"^\d{16}$").IsMatch(numero))
                return false;
            else
            {
                bool esPar = true;
                int suma = 0;
                foreach (char caracter in numero)
                {
                    if (esPar)
                    {
                        var temp = 2 * int.Parse(caracter.ToString());
                        temp = temp / 10 + temp % 10;
                        suma += temp;
                    }
                    else
                    {
                        suma += int.Parse(caracter.ToString());
                    }
                    esPar = !esPar;
                }
                return suma % 10 == 0;
            }
        }

        public static List<bool> validarTarjetas(List<TarjetaCredito> lista)
        {
            List<bool> listaResultados = new List<bool>();
            foreach (var tarjeta in lista)
            {
                listaResultados.Add(tarjeta.validar());
            }
            return listaResultados;
        }

        public override string ToString()
        {
            return String.Format("Tarjeta de Crédito No. {0}", numero);
        }
    }
}