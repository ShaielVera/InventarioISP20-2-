using Desktop.Services;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.ViewReports
{
    public partial class LocalidadesViewReport : Form
    {
        ReportViewer _report;
        LocalidadesApiService _localidadesService = new LocalidadesApiService();

        public LocalidadesViewReport()
        {
            InitializeComponent();
            _report = new ReportViewer();
            _report.Dock = DockStyle.Fill;
            this.Controls.Add(_report);
        }

        private async void LocalidadesViewReport_Load(object sender, EventArgs e)
        {
            _report.LocalReport.ReportEmbeddedResource = "Desktop.Reports.Localidades.rdlc";

            var localidades = await _localidadesService.GetAllAsync();

            // recorrer la lista de localidades y mostrar el nombre de la provincia
            var listaLocalidades = localidades?.Select(l => new
            {
                l.Id,
                l.Name,
                Provincia = l.Provincia?.Name
            }).ToList();

            _report.LocalReport.DataSources.Add(new ReportDataSource("DSLocalidades", listaLocalidades));
            _report.SetDisplayMode(DisplayMode.PrintLayout);
            _report.ZoomMode = ZoomMode.Percent;
            _report.ZoomPercent = 100;

            _report.RefreshReport();
        }
    }
}
