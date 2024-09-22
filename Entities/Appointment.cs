using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public string? CustomerName { get; set; }

        // Relación: Una cita puede tener un servicio asociado.
        public int ServiceId { get; set; }
        public Service? Service { get; set; }

        // Estado de la cita.
        public int StatusId { get; set; }
        public AppointmentStatus? Status { get; set; }
    }
}
