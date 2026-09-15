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
    public partial class ClientesApiView : Form
    {
        ClientesApiService clientesService = new ClientesApiService();
        Cliente clienteModificado;
        public ClientesApiView()
        {
            InitializeComponent();
            _ = LoadClientes();
        }

        private async Task LoadClientes()
        {
            var clientes = await clientesService.GetAllAsync();
            if (clientes != null)
            {
                dataGridClientes.DataSource = clientes;
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            var clientes = await clientesService.GetAllWithFilterAsync(txtBusqueda.Text);
            if (clientes != null)
            {
                dataGridClientes.DataSource = clientes;
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente
            {
                Firstname = txtNombre.Text,
                Lastname = txtApellido.Text,
                Dni = txtDni.Text,
                Address = txtDireccion.Text,
                LocalidadId = 1
            };
            bool clienteGuardado;
            if (clienteModificado == null)
            {
                clienteGuardado = await clientesService.AddClienteAsync(cliente);
            }
            else
            {
                cliente.Id = clienteModificado.Id;
                cliente.Created_at = clienteModificado.Created_at;
                cliente.LocalidadId = clienteModificado.LocalidadId;
                clienteGuardado = await clientesService.UpdateClienteAsync(cliente);
            }
            if (!clienteGuardado)
            {
                MessageBox.Show("Error al guardar el cliente");
            }
            MessageBox.Show("Cliente guardado correctamente");
            await LoadClientes();
            ClearTextBox();
            tabControl1.SelectedTab = tabPageLista;
            clienteModificado = null;

        }

        private void ClearTextBox()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            txtDireccion.Clear();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageAgregarEditar;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageLista;
            ClearTextBox();
            clienteModificado = null;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //capturamos el cliente seleccionado en la grilla
            if (dataGridClientes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente para modificar");

            }
            clienteModificado = (Cliente)dataGridClientes.CurrentRow.DataBoundItem;
            //llenamos los campos del formulario con los datos del cliente seleccionado
            txtNombre.Text = clienteModificado.Firstname;
            txtApellido.Text = clienteModificado.Lastname;
            txtDni.Text = clienteModificado.Dni;
            txtDireccion.Text = clienteModificado.Address;
            //cambiamos a la pestaña de agregar/editar
            tabControl1.SelectedTab = tabPageAgregarEditar;
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            //chequeamos si la tecla presionada es Enter y pulsamos el botón de buscar
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnBuscar.PerformClick();
                e.Handled = true; // Evita que el sonido de "ding" se reproduzca
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            //capturamos el cliente seleccionado en la grilla
            if (dataGridClientes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente para eliminar");
                return;
            }

            var clienteAEliminar = (Cliente)dataGridClientes.CurrentRow.DataBoundItem;
            //preguntamos si está seguro de eliminar el cliente
            var result = MessageBox.Show($"¿Está seguro de eliminar al cliente {clienteAEliminar.Firstname} {clienteAEliminar.Lastname}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                //eliminamos el cliente
                var clienteEliminado = await clientesService.DeleteClienteAsync((int)clienteAEliminar.Id);
                if (!clienteEliminado)
                {

                    MessageBox.Show("Error al eliminar el cliente");
                    return;
                }
            }
            else 
                {
                    MessageBox.Show($"Cliente {clienteAEliminar.Firstname} {clienteAEliminar.Lastname} eliminado correctamente");
                    await LoadClientes();
                }
        }

        private async void CheckEliminado_CheckedChanged(object sender, EventArgs e)
        {
            txtBusqueda.Enabled = !checkEliminado.Checked;
            btnBuscar.Enabled = !checkEliminado.Checked;
            btnNuevo.Enabled = !checkEliminado.Checked;
            btnModificar.Enabled = !checkEliminado.Checked;
            btnEliminar.Enabled = !checkEliminado.Checked;
            btnRestaurar.Enabled = checkEliminado.Checked;
            if (checkEliminado.Checked)
            {
                await LoadDeleteds();
            }
            else
            {
                await LoadClientes();
            }
        }

        private async Task LoadDeleteds()
        {
            var clientes = await clientesService.GetDeletedsAsync();
            if (clientes != null)
            {
                dataGridClientes.DataSource = clientes;
            }
        }

        private async void btnRestaurar_Click(object sender, EventArgs e)
        {
            //restauramos el cliente seleccionado en la grilla
            if (dataGridClientes.CurrentRow != null)
            {
                var clienteARestaurar = (Cliente)dataGridClientes.CurrentRow.DataBoundItem;
                //preguntamos si está seguro de restaurar el cliente
                var result = MessageBox.Show($"¿Está seguro de restaurar al cliente {clienteARestaurar.Firstname} {clienteARestaurar.Lastname}?", "Confirmar restauración", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    //restauramos el cliente
                    var clienteRestaurado = await clientesService.RestoreClienteAsync((int)clienteARestaurar.Id!);
                    if (clienteRestaurado)
                    {
                        MessageBox.Show($"Cliente {clienteARestaurar.Firstname} {clienteARestaurar.Lastname} restaurado correctamente");
                        await LoadDeleteds();
                    }
                    else
                    {
                        MessageBox.Show("Error al restaurar el cliente");
                    }
                }
            }

            else
            {
                MessageBox.Show("Seleccione un cliente para restaurar");
            }
        }
    }
}
