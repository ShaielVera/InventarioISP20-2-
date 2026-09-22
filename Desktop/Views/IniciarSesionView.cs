using Firebase.Auth;
using Firebase.Auth.Providers;
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
    public partial class IniciarSesionView : Form
    {
        FirebaseAuthClient? firebaseAuthClient;
        int intentos = 0;
        public IniciarSesionView()
        {
            InitializeComponent();
            ConfiguracionFirebaseAuthClient();
        }

        private void ConfiguracionFirebaseAuthClient()
        {
            var configAuthClient = new FirebaseAuthConfig
            {
                ApiKey = "AIzaSyCD23Fa5hKXZ8m07wEmqUChSi7b0Mb9Ucw",
                AuthDomain = "inventarioisp20shay.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider(),
                }
            };
            firebaseAuthClient = new FirebaseAuthClient(configAuthClient);
        }



        private async void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                var user = await firebaseAuthClient!.SignInWithEmailAndPasswordAsync(txtUsuario.Text, txtPassword.Text);
                if (user == null)
                {
                    MessageBox.Show("Credenciales inválidas");
                    intentos++;
                    return;
                }
                MessageBox.Show("Inicio de sesión exitoso");
                this.Hide();
                var mainView = new MenuPrincipalView();
                mainView.ShowDialog();
                this.Close();
            }
            catch (FirebaseAuthException error)
            {
                MessageBox.Show($"Error al iniciar sesión: {error.Reason}");
                intentos++;
            }
            if (intentos >= 3)
            {
                MessageBox.Show("Has excedido el número máximo de intentos. La aplicación se cerrará.");
                Application.Exit();
            }
        }

        private void checkBoxPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = checkBoxPassword.Checked ? '\0' : '*'; // Mostrar u ocultar contraseña
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
