using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;


namespace NexMeet.Models
{
    public class NexMeetContext : DbContext
    {
        public NexMeetContext() : base("name=NexMeetDB") { }

        public DbSet<Reservacion> Reservaciones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Oficina> Oficinas { get; set; }
    }
}