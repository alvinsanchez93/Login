using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using NexMeet.Models;
using NexMeet.Views;

namespace NexMeet.Views
{
    public partial class LoginView : Window
    {
        private readonly NexMeetContext _context;

        public LoginView()
        {
            InitializeComponent();
            _context = new NexMeetContext(); // Inicializar el contexto de base de datos
        }

        private void BtnIngresar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validar credenciales
                var usuario = _context.Usuarios
                    .FirstOrDefault(u => u.Correo == txtCorreo.Text && u.Contraseña == txtContrasena.Password);

                if (usuario != null)
                {
                    // Abrir el menú principal
                    MainMenuView menu = new MainMenuView();
                    menu.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Credenciales incorrectas. Inténtalo nuevamente.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}