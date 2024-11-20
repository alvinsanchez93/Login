using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexMeet.Models
{
    public class Reservacion
    {
        public int ReservacionID { get; set; }
        public int UsuarioID { get; set; }
        public int OficinaID { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; }

        public virtual Usuario Usuario { get; set; } // Relación con Usuario
        public virtual Oficina Oficina { get; set; } // Relación con Oficina
    }
}
