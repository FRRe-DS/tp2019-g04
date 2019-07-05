using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microservicio;
using ORT;
using Microservicio.Controllers;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace AppWeb.Pages
{
    public class IndexModel : PageModel
    {

        public List<HistoriaClinica> HistClinicas { get; set; }
        public HistoriaClinica HistoriaClinica { get; set; }

        private Model _context;

        public IndexModel(Model context)
        {
            _context = context;
        }
        

        public void OnGet()
        {
            HttpClient clienteApi = new HttpClient();
            clienteApi.BaseAddress = new Uri("https://localhost:44356");
            HttpResponseMessage response2 = clienteApi.GetAsync("api/values").Result;
            if(response2.StatusCode==HttpStatusCode.OK)
            {
                string ClientesString = response2.Content.ReadAsStringAsync().Result;
                HistClinicas = JsonConvert.DeserializeObject<List<HistoriaClinica>>(ClientesString);
            }
        }
    }
}

