using DotNetEnv;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Desktop.Service
{
    public class PaisesApiService
    {
        HttpClient httpClient;
        JsonSerializerOptions options;

        public PaisesApiService()
        {
            httpClient = SettingHttpClient();
            options = SettingJsonSerializer();
        }

        public async Task<List<Pais>?> GetAllAsync()//obteniendo paises
        {
            try
            {
                var response = await httpClient.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var paises = JsonSerializer.Deserialize<List<Pais>>(json, options);
                    return paises;
                }
                else
                {
                    MessageBox.Show("Error al obtener los paises: " + response.ReasonPhrase);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los paises: " + ex.Message);
                return null;
            }
        }

        public async Task<List<Pais>?> GetAllWithFiltersAsync(string filter)//obteniendo paiseses mediante filtro
        {
            try
            {
                var response = await httpClient.GetAsync($"?filtro={filter}");
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al obtener las paises: " + response.ReasonPhrase);
                    return null;
                }
                var json = await response.Content.ReadAsStringAsync();
                var paises = JsonSerializer.Deserialize<List<Pais>>(json, options);
                return paises;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener las Paises: " + ex.Message);
                return null;
            }
        }
        public async Task<List<Pais>?> GetAllDeletedAsync()//obteniendo paises eliminadas
        {
            try
            {
                var response = await httpClient.GetAsync("deleteds");
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al obtener las paises eliminados: " + response.ReasonPhrase);
                    return null;
                }
                var json = await response.Content.ReadAsStringAsync();
                var paises = JsonSerializer.Deserialize<List<Pais>>(json, options);
                return paises;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener las paises eliminados: " + ex.Message);
                return null;
            }
        }

        public async Task<bool> AddPaisesAsync(Pais pais)//agregando una pais
        {
            try
            {
                SettingJsonSerializer();
                var json = JsonSerializer.Serialize(pais, options);
                var PaisJson = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("", PaisJson);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al crear el pais: " + response.ReasonPhrase);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el pais desde la Api: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdatePaisesAsync(Pais pais) //modificando un pais
        {
            try
            {
                // Configuramos las opciones de serialización para ignorar propiedades nulas y hacer que la búsqueda de propiedades sea insensible a mayúsculas
                var options = new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                    PropertyNameCaseInsensitive = true,
                };
                //configuramos la serializacion de paiseses para que ignore las propiedades nulas y no tenga en cuenta mayusculas o minusculas en los nombres de las propiedades
                SettingJsonSerializer();
                var json = JsonSerializer.Serialize(pais, options);
                var PaisJson = new StringContent(json, Encoding.UTF8, "application/json");
                string IdPais = pais.Id.ToString(); //filtro para actualizar solo la pais con el id que se pasa por el parametro pais
                var response = await httpClient.PutAsync(IdPais, PaisJson);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al actualizar el pais: " + response.ReasonPhrase);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el pais desde la Api: " + ex.Message);
                return false;
            }

        }

        public async Task<bool> DeletePaisAsync(int id) //eliminando un pais
        {
            try
            {
                var response = await httpClient.DeleteAsync(id.ToString());
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al eliminar el pais: " + response.ReasonPhrase);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el pais desde la Api: " + ex.Message);
                return false;
            }

        }
        //restaurar un pais
        public async Task<bool> RestorePaisAsync(int id)
        {
            try
            {
                var response = await httpClient.PutAsync($"restore/{id}", null);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al restaurar el pais: " + response.ReasonPhrase);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al restaurar el pais desde la Api: " + ex.Message);
                return false;
            }
        }

        private HttpClient? SettingHttpClient()
        {
            Env.Load("../../../"); //cargando las variables de entorno del archivo .env
            //var urlApi = Environment.GetEnvironmentVariable("URLAPI");
            var urlApi = Environment.GetEnvironmentVariable("URLAPI");
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(urlApi + "Paises/");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            return httpClient;
        }

        private JsonSerializerOptions SettingJsonSerializer()
        {
            return new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNameCaseInsensitive = true,
            };
        }
    }
}