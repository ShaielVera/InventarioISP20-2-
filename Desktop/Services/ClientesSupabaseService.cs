using Desktop.Models;
using DotNetEnv;
using Supabase.Postgrest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;
using static Supabase.Postgrest.Constants;


namespace Desktop.Services
{
    public class ClientesSupabaseService
    {
        Supabase.Client supabase;
        public ClientesSupabaseService()
        {
             _ = SettingSupabaseClient();
        }

        public async Task<List<Cliente>?> GetAllAsync()
        {
            try
            {
                var result = await supabase.From<Cliente>().Get();
                var clientes = result.Models;
                return clientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error obtener los clientes desde la Api: " + ex.Message);
                return null;

            }
        }

        public async Task<List<Cliente>?> GetAllWithFilterAsync(string filter)
        {
            try
            {
                var result = await supabase.From<Cliente>()
                    .Where(c => c.firstname.Contains(filter) || c.lastname.Contains(filter) || c.dni.Contains(filter))
                    .Get();
                var clientes = result.Models;
                return clientes;
                //return clientes.Where(
                //              c=>c.firstname.Contains(filter,StringComparison.OrdinalIgnoreCase) || 
                //              c.lastname.Contains(filter,StringComparison.OrdinalIgnoreCase) ||
                //              c.dni.Contains(filter, StringComparison.OrdinalIgnoreCase))
                //    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error obtener los clientes desde la Api: " + ex.Message);
                return null;

            }
        }

        public async Task<bool> AddClienteAsync(Cliente cliente)
        {
            try
            {
                var response=await supabase.From<Cliente>().Insert(cliente);
                return response.ResponseMessage!.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el cliente desde supabase: " + ex.Message);
                return false;
            }

        }

        public async Task<bool> DeleteClienteAsync(int id)
        {
            try
            {
                await supabase.From<Cliente>()
                    .Where(c => c.id == id)
                    .Delete();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el cliente desde la Api: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateClienteAsync(Cliente cliente)
        {
            try
            {
                var response = await supabase.From<Cliente>().Upsert(cliente);
                return response.ResponseMessage!.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el cliente desde supabase: " + ex.Message);
                return false;
            }

        }

        private async Task SettingSupabaseClient()
        {
            Env.Load("../../../");
            var url = Environment.GetEnvironmentVariable("SUPABASE_URL");
            var key = Environment.GetEnvironmentVariable("SUPABASE_KEY");
            var options = new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = true
            };
            supabase = new Supabase.Client(url, key, options);
            await supabase.InitializeAsync();
        }

    }
}
