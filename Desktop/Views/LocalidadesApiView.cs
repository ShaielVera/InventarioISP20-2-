using Desktop.Service;
using Desktop.Services;
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
    public partial class LocalidadesApiView : Form
    {
        ProvinciasApiService provinciasService = new ProvinciasApiService();
        LocalidadesApiService localidadesService = new LocalidadesApiService();
        Localidad? LocalidadModificado;
        public LocalidadesApiView()
        {
            InitializeComponent();
            //localidadesService 
            _ = LoadLocalidades();
            _ = LoadComboProvincias();
        }

        private async Task LoadComboProvincias()
        {
            var provincias = await provinciasService.GetAllAsync();
            if (provincias != null)
            {
                comboProvincia.DataSource = provincias;
                comboProvincia.DisplayMember = "Name";
                comboProvincia.ValueMember = "Id";
                comboProvincia.SelectedValue = -1; // No seleccionar ningún elemento por defecto
            }
        }

        private async Task LoadLocalidades()
        {
            var localidades = await localidadesService.GetAllAsync();
            if (localidades != null)
            {
                dataGridLocalidades.DataSource = localidades;

                // 1. Mostrar la columna Id y cambiar su encabezado
                if (dataGridLocalidades.Columns["Id"] != null)
                {
                    dataGridLocalidades.Columns["Id"].Visible = true;
                    dataGridLocalidades.Columns["Id"].HeaderText = "ID";
                    dataGridLocalidades.Columns["Id"].DisplayIndex = 0; // La ubica en la primera columna
                }

                // 2. Cambiar el encabezado de Name a Localidad
                if (dataGridLocalidades.Columns["Name"] != null)
                {
                    dataGridLocalidades.Columns["Name"].HeaderText = "Localidad";
                }

                // 3. Ocultar las columnas que no querés mostrar
                if (dataGridLocalidades.Columns["ProvinciaId"] != null)
                    dataGridLocalidades.Columns["ProvinciaId"].Visible = false;

                if (dataGridLocalidades.Columns["IsDeleted"] != null)
                    dataGridLocalidades.Columns["IsDeleted"].Visible = false;

                if (dataGridLocalidades.Columns["isdeleted"] != null)
                    dataGridLocalidades.Columns["isdeleted"].Visible = false;
            }
        }


        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            Localidad localidad = new Localidad
            {
                Name = txtNombre.Text,
                ProvinciaId = comboProvincia.SelectedValue != null ? (int)comboProvincia.SelectedValue : 0 // Asignar un valor predeterminado para ProvinciaId
            };
            bool localidadGuardado;
            if (LocalidadModificado == null)
                localidadGuardado = await localidadesService.AddLocalidadAsync(localidad);
            else
            {
                localidad.Id = LocalidadModificado.Id;
                localidadGuardado = await localidadesService.UpdateLocalidadAsync(localidad);
            }
            if (!localidadGuardado)
            {
                MessageBox.Show("error al guardar la localidad");
                return;
            }
            MessageBox.Show("localidad guardada correctamente");
            await LoadLocalidades();
            ClearTextBox();
            tabControl1.SelectedTab = tabPageLista;
            LocalidadModificado = null;

        }

        private void ClearTextBox()
        {
            txtNombre.Text = "";
            comboProvincia.SelectedValue = -1; // No seleccionar ningún elemento por defecto
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageAgregarEditar;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageLista;
            ClearTextBox();
            LocalidadModificado = null;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //capturamos una localidad seleccionada en el datagridview
            if (dataGridLocalidades.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una localidad para modificar");
                return;
            }
            LocalidadModificado = (Localidad)dataGridLocalidades.CurrentRow.DataBoundItem;
            //llenamos los campos del formulario con los datos de la localidad seleccionada
            txtNombre.Text = LocalidadModificado.Name;
            if (LocalidadModificado.ProvinciaId != 0)
                comboProvincia.SelectedValue = LocalidadModificado.ProvinciaId;
            //cambiamos a la pestaña de agregar/editar
            tabControl1.SelectedTab = tabPageAgregarEditar;
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            //capturamos la localidad seleccionada en el datagridview
            if (dataGridLocalidades.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una localidad para eliminar");
                return;
            }
            var localidadAEliminar = (Localidad)dataGridLocalidades.CurrentRow.DataBoundItem;
            //preguntamos si esta seguro de eliminar la localidad
            var result = MessageBox.Show($"¿Está seguro de eliminar la localidad {localidadAEliminar.Name}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                //eliminamos la localidad
                var localidadEliminada = await localidadesService.DeleteLocalidadAsync((int)localidadAEliminar.Id!);
                if (!localidadEliminada)
                {
                    MessageBox.Show("error al eliminar la localidad");
                    return;
                }

                MessageBox.Show($"localidad {localidadAEliminar.Name} eliminada correctamente");
                await LoadLocalidades();

            }
        }

        private async void CheckEliminado_CheckedChanged(object sender, EventArgs e)
        {
            txtBusqueda.Enabled = !checkEliminado.Checked;
            btnBuscar.Enabled = !checkEliminado.Checked;
            btnModificar.Enabled = !checkEliminado.Checked;
            btnEliminar.Enabled = !checkEliminado.Checked;
            btnNuevo.Enabled = !checkEliminado.Checked;
            btnRestaurar.Enabled = checkEliminado.Checked;
            if (checkEliminado.Checked)
            {
                await LoadDeleteds();
            }
            else
            {
                await LoadLocalidades();
            }
        }

        private async Task LoadDeleteds()
        {
            var localidades = await localidadesService.GetDeletedsAsync();
            if (localidades != null)
            {
                dataGridLocalidades.DataSource = localidades;
            }
        }

        private async void btnRestaurar_Click(object sender, EventArgs e)
        {
            //capturamos la localidad seleccionado en el datagridview
            if (dataGridLocalidades.CurrentRow != null)
            {
                var localidadARestaurar = (Localidad)dataGridLocalidades.CurrentRow.DataBoundItem;
                //preguntamos si esta seguro de restaurar a la localidad
                var result = MessageBox.Show($"¿Está seguro de restaurar a la localidad {localidadARestaurar.Name}?", "Confirmar restauración", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    //restauramos la localidad
                    var localidadRestaurada = await localidadesService.RestoreLocalidadAsync((int)localidadARestaurar.Id!);
                    if (localidadRestaurada)
                    {
                        MessageBox.Show($"localidad {localidadARestaurar.Name} restaurada correctamente");
                        await LoadDeleteds();
                    }
                    else
                    {
                        MessageBox.Show("error al restaurar la localidad");
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una localidad para restaurar");
            }
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            // chequeamos si la tecla presionada es Enter y pulsamos el boton de buscar
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnBuscar.PerformClick();
                e.Handled = true; // Evita que el sonido de "ding" se reproduzca
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            var localidades = await localidadesService.GetAllWithFilterAsync(txtBusqueda.Text);
            if (localidades != null)
            {
                dataGridLocalidades.DataSource = localidades;
            }
        }
    }
}