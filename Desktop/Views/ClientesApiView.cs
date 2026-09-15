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
            //Cliente cliente = new Cliente
            //{
            //    firstname = txtNombre.Text,
            //    lastname = txtApellido.Text,
            //    dni = txtDni.Text,
            //    address = txtDireccion.Text,
            //};
            //bool clienteGuardado;
            //if (clienteModificado == null)
            //{
            //    clienteGuardado = await clientesService.AddClienteAsync(cliente);
            //}
            //else
            //{
            //    cliente.id = clienteModificado.id;
            //    cliente.created_at = clienteModificado.created_at;
            //    clienteGuardado = await clientesService.UpdateClienteAsync(cliente);
            //}
            //if (clienteGuardado)
            //{
            //    MessageBox.Show("Cliente guardado correctamente");
            //    LoadClientes();
            //    ClearTextBox();
            //    tabControl1.SelectedTab = tabPageLista;
            //    clienteModificado = null;
            //}
            //else
            //{
            //    MessageBox.Show("Error al guardar el cliente");
            //}
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
            //if (dataGridClientes.CurrentRow != null)
            //{
            //    clienteModificado = (Cliente)dataGridClientes.CurrentRow.DataBoundItem;
            //    //llenamos los campos del formulario con los datos del cliente seleccionado
            //    txtNombre.Text = clienteModificado.firstname;
            //    txtApellido.Text = clienteModificado.lastname;
            //    txtDni.Text = clienteModificado.dni;
            //    txtDireccion.Text = clienteModificado.address;
            //    //cambiamos a la pestaña de agregar/editar
            //    tabControl1.SelectedTab = tabPageAgregarEditar;
            //}
            //else
            //{
            //    MessageBox.Show("Seleccione un cliente para modificar");
            //}
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
            //if (dataGridClientes.CurrentRow != null)
            //{
            //    var clienteAEliminar = (Cliente)dataGridClientes.CurrentRow.DataBoundItem;
            //    //preguntamos si está seguro de eliminar el cliente
            //    var result = MessageBox.Show($"¿Está seguro de eliminar al cliente {clienteAEliminar.firstname} {clienteAEliminar.lastname}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //    if (result == DialogResult.Yes) {
            //        //eliminamos el cliente
            //        var clienteEliminado = await clientesService.DeleteClienteAsync((int)clienteAEliminar.id!);
            //        if (clienteEliminado)
            //        {
            //            MessageBox.Show($"Cliente {clienteAEliminar.firstname} {clienteAEliminar.lastname} eliminado correctamente");
            //            LoadClientes();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Error al eliminar el cliente");
            //        }
            //    }
            //}

            //else
            //{
            //    MessageBox.Show("Seleccione un cliente para eliminar");
            //}
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
