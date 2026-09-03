using Consola.Class;
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
    public partial class ArticulosView : Form
    {
        public ArticulosView()
        {
            InitializeComponent();
        }

        private void BtnAgregarAlumno_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno("Alejandro","Ramirez");
            ListAlumnos.Items.Add(alumno);
            
        }
    }
}
