using NexMeet.Models;
using System;
using System.Linq;
using System.Data.Entity; // Necesario para .Include()
using System.Windows;

namespace NexMeet.Views
{
    public partial class ReservacionesView : Window
    {
        private readonly NexMeetContext _context; // Campo de solo lectura

        public ReservacionesView()
        {
            InitializeComponent();
            _context = new NexMeetContext(); // Crear instancia del contexto de base de datos
            CargarReservaciones();          // Cargar datos iniciales
        }

        private void CargarReservaciones()
        {
            try
            {
                var reservaciones = _context.Reservaciones
                    .Include(r => r.Usuario)
                    .Include(r => r.Oficina)
                    .ToList();

                dgReservaciones.ItemsSource = reservaciones;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar reservaciones: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Método para manejar la acción de agregar reservación
        private void AgregarReservacion_Click(object sender, RoutedEventArgs e)
        {
            var agregarReservacionView = new AgregarReservacionView();
            if (agregarReservacionView.ShowDialog() == true)
            {
                // Recargar el DataGrid después de agregar una reservación
                CargarReservaciones();
            }
        }


        // Métodos para Editar y Eliminar reservaciones
        private void EditarReservacion_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Funcionalidad de editar reservación aún no implementada.", "Editar");
        }

        private void EliminarReservacion_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Funcionalidad de eliminar reservación aún no implementada.", "Eliminar");
        }
    }
}

