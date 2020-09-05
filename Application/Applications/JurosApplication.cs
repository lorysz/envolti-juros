using Application.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Application.Applications
{
    public class JurosApplication : IJurosApplication
    {
        public decimal GetTaxaJuros()
        {
            return 0.01m;
        }
        public decimal GetJuros(decimal valorInicial, int meses)
        {
            decimal juros = 0.00m;
            var requisicaoWeb = WebRequest.CreateHttp("http://localhost:57874/taxaJuros");
            requisicaoWeb.Method = "GET";
            requisicaoWeb.UserAgent = "RequisicaoWebDemo";
            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                string jurosString = objResponse.ToString();
                juros = Convert.ToDecimal(jurosString,  new System.Globalization.CultureInfo("en-US"));
                streamDados.Close();
                resposta.Close();
            }

            double jurosCalc = (double)(1 + juros);
            double valorPotencia = Math.Pow(jurosCalc, meses);
            decimal valorFinal = valorInicial * (decimal)valorPotencia;
            return Math.Truncate(valorFinal * 100) / 100;
        }
    }
}
