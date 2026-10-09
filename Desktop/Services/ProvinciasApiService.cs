using DotNetEnv;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Desktop.Services
{
    public class ProvinciasApiService
    {
            HttpClient httpClient;
            JsonSerializerOptions options;
            public ProvinciasApiService()
            {
                httpClient = SettingHttpClient();
                options = SettingJsonSerializer();
            }
            public async Task<List<Provincia>?> GetAllAsync()
            {
                try
                {
                    var response = await httpClient.GetAsync("");
                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Error al obtener las provincias: " + response.ReasonPhrase);
                        return null;
                    }
                    var json = await response.Content.ReadAsStringAsync();
                    var provincias = JsonSerializer.Deserialize<List<Provincia>>(json, options);
                    return provincias;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error obtener las provincias desde la Api: " + ex.Message);
                    return null;

                }
            }

            public async Task<List<Provincia>?> GetAllWithFilterAsync(string filter)
            {
                try
                {
                    var response = await httpClient.GetAsync($"?filtro={filter}");
                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Error al obtener las provincias: " + response.ReasonPhrase);
                        return null;
                    }
                    var json = await response.Content.ReadAsStringAsync();
                    var provincias = JsonSerializer.Deserialize<List<Provincia>>(json, options);
                    return provincias;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error obtener las provincias desde la Api: " + ex.Message);
                    return null;

                }
            }

            public async Task<bool> AddProvinciaAsync(Provincia provincia)
            {
                try
                {
                    var json = JsonSerializer.Serialize(provincia, options);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync("", content);
                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Error al crear la provincia: " + response.ReasonPhrase);
                        return false;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear la provincia desde la Api: " + ex.Message);
                    return false;
                }
            }

            public async Task<bool> DeleteProvinciaAsync(int id)
            {
                try
                {
                    var response = await httpClient.DeleteAsync(id.ToString());
                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Error al eliminar la provincia: " + response.ReasonPhrase);
                        return false;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar la provincia desde la Api: " + ex.Message);
                    return false;
                }
            }

            public async Task<List<Provincia>?> GetDeletedsAsync()
            {
                try
                {
                    var response = await httpClient.GetAsync("deleteds");
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var provincias = JsonSerializer.Deserialize<List<Provincia>>(json, options);
                        return provincias;
                    }
                    else
                    {
                        MessageBox.Show("Error al obtener las provincias       : " + response.ReasonPhrase);
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error obtener las provincias desde la Api: " + ex.Message);
                    return null;

                }
            }

            public async Task<bool> RestoreProvinciaAsync(int id)
            {
                try
                {
                    var response = await httpClient.PutAsync($"restore/{id}", null);
                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Error al restaurar la provincia: " + response.ReasonPhrase);
                        return false;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al restaurar la provincia desde la Api: " + ex.Message);
                    return false;
                }
            }



            public async Task<bool> UpdateProvinciaAsync(Provincia provincia)
            {
                try
                {
                    // Configuramos las opciones de serialización para ignorar propiedades nulas y hacer que la búsqueda de propiedades sea insensible a mayúsculas
                    var options = new JsonSerializerOptions
                    {
                        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                        PropertyNameCaseInsensitive = true,
                    };

                    var json = JsonSerializer.Serialize(provincia, options);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    string idprovincia = provincia.Id.ToString();
                    var response = await httpClient.PutAsync(idprovincia, content);
                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Error al actualizar la provincia: " + response.ReasonPhrase);
                        return false;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar la provincia desde la Api: " + ex.Message);
                    return false;
                }
            }

            private HttpClient SettingHttpClient()
            {
                Env.Load("../../../");
                //var urlApi = Environment.GetEnvironmentVariable("URLAPI");
                var urlApiLocal = Environment.GetEnvironmentVariable("URLAPI");
                //instanciamos el httpClient y lo configuramos para poder utilizarlo en cada uno de los métodos
                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(urlApiLocal + "Provincias/");
                //agregamos apikey de la url
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