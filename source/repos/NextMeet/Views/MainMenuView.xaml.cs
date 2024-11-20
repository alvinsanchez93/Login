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

namespace NexMeet.Views
{
    public partial class MainMenuView : Window
    {
        public MainMenuView()
        {
            InitializeComponent();
        }

        private void Reservaciones_Click(object sender, RoutedEventArgs e)
        {
            ReservacionesView reservacionesView = new ReservacionesView();
            reservacionesView.Show(); // Abre la ventana de reservaciones
            this.Close();            // Cierra la ventana actual
        }


        private void Oficinas_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Aquí irá la vista de Oficinas.", "Oficinas");
        }

        private void CerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            // Regresar al Login
            new LoginView().Show();
            this.Close();
        }
    }
}
