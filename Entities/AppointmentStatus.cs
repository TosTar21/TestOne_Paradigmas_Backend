namespace Entities
{
    public class AppointmentStatus
    {
        public int Id { get; set; } // La llave primaria debe estar presente y seguir las convenciones
        public string? Name { get; set; }

        // Relación con las citas
        public List<Appointment>? Appointments { get; set; }
    }
}
