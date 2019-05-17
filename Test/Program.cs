using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ORT;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Test
{
    class Program
    {
        private static Model _context;
        static void Main(string[] args)
        {
            HistoriaClinica HistClin = null;
            //IEnumerable<HistoriaClinica> HistClin = null;
            Metodos M = new Metodos();
            //HistClin = M.GetTodos();
            HistClin = M.GetPorId(1);
            if (HistClin != null)
            {
            //    foreach (var i in HistClin)
            //    {
            //        Console.WriteLine("{0}, {1}", i.Id, i.PacienteId);
            //    }
                  Console.WriteLine("{0}", HistClin.Id);
            }
            //else
            //{
            //    Console.WriteLine("No se Encontro Nada");
            //}
            //M.Borrar(4);


            var services = new ServiceCollection();
            services.AddDbContext<Model>();
            var servicePovide = services.BuildServiceProvider();
            _context = servicePovide.GetService<Model>();

            HistoriaClinica hc = new HistoriaClinica(_context);
            hc.Id = 100;
            hc.PacienteId = 1;

            M.Guardar(hc);
            Console.WriteLine("Echo");
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
            List<HistoriaClinica> HistClin = null;
            HttpClient clienteApi = new HttpClient();
            clienteApi.BaseAddress = new Uri("https://localhost:44356");
            string url = "api/values/" + Convert.ToString(IdHist);
            HttpResponseMessage response2 = clienteApi.GetAsync(url).Result;
            if (response2.StatusCode == HttpStatusCode.OK)
            {
                string ClientesString = response2.Content.ReadAsStringAsync().Result;
                HistClin = JsonConvert.DeserializeObject<List<HistoriaClinica>>(ClientesString);
            }

            var H = HistClin[0];
            return H;
        }
        public void Borrar (int Id)
        {
            HttpClient clienteApi = new HttpClient();
            clienteApi.BaseAddress = new Uri("https://localhost:44356");
            string url = "api/values/" + Convert.ToString(Id);
            clienteApi.DeleteAsync(url);
        }

        public void Guardar(HistoriaClinica Hc)
        {
            var dataEnv = JsonConvert.SerializeObject(Hc);
            HttpClient clienteApi = new HttpClient();
            var content = new StringContent(dataEnv, Encoding.UTF8, "application/json");
            clienteApi.BaseAddress = new Uri("https://localhost:44356");
            clienteApi.PostAsync("api/values", content);
        }
    }
}
