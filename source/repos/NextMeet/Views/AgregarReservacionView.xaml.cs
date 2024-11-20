using NexMeet.Models;
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
    public partial class AgregarReservacionView : Window
    {
        private readonly NexMeetContext _context;

        public AgregarReservacionView()
        {
            InitializeComponent();
            _context = new NexMeetContext();
            CargarDatos(); // Cargar datos iniciales en los ComboBox
        }

        private void CargarDatos()
        {
            try
            {
                // Cargar usuarios en el ComboBox
                cbUsuarios.ItemsSource = _context.Usuarios.ToList();
                cbUsuarios.DisplayMemberPath = "Nombre";
                cbUsuarios.SelectedValuePath = "UsuarioID";

                // Cargar oficinas en el ComboBox
                cbOficinas.ItemsSource = _context.Oficinas.ToList();
                cbOficinas.DisplayMemberPath = "Nombre";
                cbOficinas.SelectedValuePath = "OficinaID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GuardarReservacion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validar campos obligatorios
                if (cbUsuarios.SelectedValue == null || cbOficinas.SelectedValue == null ||
                    dpFechaInicio.SelectedDate == null || dpFechaFin.SelectedDate == null ||
                    string.IsNullOrWhiteSpace(tbHoraInicio.Text) || string.IsNullOrWhiteSpace(tbHoraFin.Text))
                {
                    MessageBox.Show("Por favor, completa todos los campos.", "Validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Validar formato de hora
                if (!TimeSpan.TryParse(tbHoraInicio.Text, out var horaInicio) ||
                    !TimeSpan.TryParse(tbHoraFin.Text, out var horaFin))
                {
                    MessageBox.Show("Por favor, introduce un formato de hora válido (HH:mm).", "Validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Combinar fecha y hora
                var fechaInicio = dpFechaInicio.SelectedDate.Value.Add(horaInicio);
                var fechaFin = dpFechaFin.SelectedDate.Value.Add(horaFin);

                // Validar que la fecha de inicio sea anterior a la fecha de fin
                if (fechaInicio >= fechaFin)
                {
                    MessageBox.Show("La fecha y hora de inicio deben ser anteriores a la fecha y hora de fin.", "Validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Crear nueva reservación
                var nuevaReservacion = new Reservacion
                {
                    UsuarioID = (int)cbUsuarios.SelectedValue,
                    OficinaID = (int)cbOficinas.SelectedValue,
                    FechaInicio = fechaInicio,
                    FechaFin = fechaFin,
                    Estado = "Activo"
                };

                // Guardar en la base de datos
                _context.Reservaciones.Add(nuevaReservacion);
                _context.SaveChanges();

                MessageBox.Show("Reservación agregada con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true; // Cerrar ventana y retornar éxito
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la reservación: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // Cerrar ventana sin realizar cambios
        }
    }
}