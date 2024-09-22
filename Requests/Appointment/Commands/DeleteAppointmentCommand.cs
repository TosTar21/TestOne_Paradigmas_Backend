using MediatR;

namespace Services.Requests.Appointments
{
    // El comando para eliminar una cita debe implementar IRequest<Unit>
    public class DeleteAppointmentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
