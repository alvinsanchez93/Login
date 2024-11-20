using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace NexMeet.Models
{
    // Clase inicializadora para la base de datos
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<NexMeetContext>
    {
        // Método Seed: Población inicial de datos
        protected override void Seed(NexMeetContext context)
        {
            // Agregar un usuario administrador
            context.Usuarios.Add(new Usuario
            {
                Nombre = "Admin",
                Correo = "admin@nexmeet.com",
                Contraseña = "admin123",
                Rol = "Administrador"
            });

            // Agregar un usuario empleado
            context.Usuarios.Add(new Usuario
            {
                Nombre = "Empleado",
                Correo = "empleado@nexmeet.com",
                Contraseña = "empleado123",
                Rol = "Empleado"
            });

            // Guardar los cambios en la base de datos
            context.SaveChanges();
        }
    }
}

