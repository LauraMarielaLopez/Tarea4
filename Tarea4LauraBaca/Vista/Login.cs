using Datos;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Vista
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void AceptarButton_Click(object sender, EventArgs e)
        {
            
                if (CorreoTextBox.Text == String.Empty)
                {
                    errorProvider1.SetError(CorreoTextBox, "Ingrese correo de usuario");
                    CorreoTextBox.Focus();
                    return;
                }
                errorProvider1.Clear();
                if (ClaveTextBox.Text == String.Empty)
                {
                    errorProvider1.SetError(ClaveTextBox, "Ingrese una clave");
                    ClaveTextBox.Focus();
                    return;
                }
                errorProvider1.Clear();

                UsuarioDatos userDatos = new UsuarioDatos();

                bool valido = await userDatos.LoginAsync(CorreoTextBox.Text, ClaveTextBox.Text);

                if (valido)
                {
                //menu
                }
                else
                {
                    MessageBox.Show("Datos de usuario incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            

           
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
