using Newtonsoft.Json;
using ORT;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //HistoriaClinica HistClin = null;
            IEnumerable<HistoriaClinica> HistClin = null;
            Metodos M = new Metodos();

            HistClin= M.GetTodos();

            if (HistClin != null)
            {
                foreach (var i in HistClin)
                {
                    Console.WriteLine("{0}, {1}", i.Id, i.PacienteId);
            }
              //  Console.WriteLine("{0}", HistClin.Id);
            }
            else
            {
                Console.WriteLine("No se Encontro Nada");
            }
            M.Borrar(1);
            Console.WriteLine("Echo");
            HistClin = M.GetTodos();

            if (HistClin != null)
            {
                foreach (var i in HistClin)
                {
                    Console.WriteLine("{0}, {1}", i.Id, i.PacienteId);
                }
                //  Console.WriteLine("{0}", HistClin.Id);
            }
            else
            {
                Console.WriteLine("No se Encontro Nada");
            }
            Console.ReadLine();
        }


    }

    public class Metodos
    {
        public IEnumerable<HistoriaClinica> GetTodos()
        {
            IEnumerable<HistoriaClinica> HistClin = null;
            HttpClient clienteApi = new HttpClient();
            clienteApi.BaseAddress = new Uri("https://localhost:44356");
            HttpResponseMessage response2 = clienteApi.GetAsync("api/values").Result;
            if (response2.StatusCode == HttpStatusCode.OK)
            {
                string ClientesString = response2.Content.ReadAsStringAsync().Result;
                HistClin = JsonConvert.DeserializeObject<List<HistoriaClinica>>(ClientesString);
            }

            return HistClin;
        }
        public HistoriaClinica GetPorId(int IdHist)
        {
            string IdH = "1";
            HistoriaClinica HistClin = null;
            HttpClient clienteApi = new HttpClient();
            clienteApi.BaseAddress = new Uri("https://localhost:44356");
            HttpResponseMessage response2 = clienteApi.GetAsync("api/values/{IdH}").Result;
            if (response2.StatusCode == HttpStatusCode.OK)
            {
                string ClientesString = response2.Content.ReadAsStringAsync().Result;
                HistClin = JsonConvert.DeserializeObject<HistoriaClinica>(ClientesString);
            }

            return HistClin;
        }
        public void Borrar (int Id)
        {
            HttpClient clienteApi = new HttpClient();
            clienteApi.BaseAddress = new Uri("https://localhost:44356");
            clienteApi.DeleteAsync("api/values/1");
        }
    }
}
