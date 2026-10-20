using Desktop.Services;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using Microsoft.Reporting.WinForms;
using Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class SplashView : Form
    {
        bool dataReady = false;
        bool printReady = false;

        public SplashView()
        {
            InitializeComponent();
        }

        private void SplashView_Load(object sender, EventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            progressBar.Increment(5);
            if (dataReady && printReady && progressBar.Value >= 100)
            {
                timer.Stop();
                this.Hide();
                IniciarSesionView iniciarSesionView = new IniciarSesionView();
                iniciarSesionView.ShowDialog();
                this.Close();
            }
        }

        private async Task GetData()
        {
            await Task.Run(() =>
            {
                ClientesApiService _clientesService = new ClientesApiService();
                // Simulate data loading
                var clientes = _clientesService.GetAllAsync().Result;
                dataReady = true;
            });
        }

        private async Task PrintReport()
        {
            await Task.Run(() =>
            {
                ReportViewer _report = new ReportViewer();
                _report.LocalReport.ReportEmbeddedResource = "Desktop.Reports.Clientes.rdlc";

                var clientes = new List<Cliente>
                {
                    new Cliente { Id = 1, Firstname = "Shaiel", Lastname = "Vera", Dni = "44496912", Address = "N. Zamaro 2559" },

                };

                _report.LocalReport.DataSources.Add(new ReportDataSource("DSClientes", clientes));
                _report.SetDisplayMode(DisplayMode.PrintLayout);
                _report.ZoomMode = ZoomMode.Percent;
                _report.ZoomPercent = 100;

                _report.RefreshReport();
                printReady = true;
            });
        }

        private async void SplashView_Activated(object sender, EventArgs e)
        {
            var dataTask = GetData();
            var printTask = PrintReport();
            await Task.WhenAll(dataTask, printTask);
        }
    }
}
