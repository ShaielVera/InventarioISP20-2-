using Desktop.Models;
using DotNetEnv;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class ProbandoIA_Gemini : Form
    {
        public ProbandoIA_Gemini()
        {
            InitializeComponent();
        }

        private async void BtnEnviar_Click(object sender, EventArgs e)
        {
            TxtRespuesta.Text = "Procesando consulta, por favor espere...";

            Env.Load("../../../");
            var apikey = Environment.GetEnvironmentVariable("APIKEY_GEMINI");
            if (apikey == null)
            {
                TxtRespuesta.Text = "No se encontró la APIKEY en las variables de entorno.";
                return;
            }

            if (string.IsNullOrWhiteSpace(TxtConsulta.Text))
            {
                TxtRespuesta.Text = "Por favor, ingrese una consulta antes de enviar.";
                return;
            }
            //creamos un hhtpclient para hacer la peticion a la api de gemini con using
            using (var client = new HttpClient())
            {
                var url = "https://generativelanguage.googleapis.com/v1beta/interactions";
                client.DefaultRequestHeaders.Add("x-goog-api-key", $"{apikey}");

                var requestBody = new
                {
                    model = "gemini-3.5-flash",
                    input = TxtConsulta.Text
                };

                var response = await client.PostAsJsonAsync(url, requestBody);
                if (response == null)
                {
                    TxtRespuesta.Text = "No se recibió respuesta de la API.";
                    return;
                }

                ResponseGemini? responseGemini = await response.Content.ReadFromJsonAsync<ResponseGemini>();
                if (responseGemini == null)
                {
                    TxtRespuesta.Text = "No se pudo deserializar la respuesta de la API.";
                    return;
                }
                TxtRespuesta.Text = responseGemini.steps[1].content[0].text;

            }
        }
    }
}
