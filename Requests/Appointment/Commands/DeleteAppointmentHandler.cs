using Entities;
using MediatR;
using Services.GenericRepository;

namespace Services.Requests.Appointments
{
    // Manejador para procesar el comando de eliminación de una cita
    public class DeleteAppointmentHandler : IRequestHandler<DeleteAppointmentCommand, Unit>
    {
        private readonly ISvGenericRepository<Appointment> _appointmentRepository;

        public DeleteAppointmentHandler(ISvGenericRepository<Appointment> appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        // Método que maneja la lógica para eliminar la cita
        public async Task<Unit> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
        {
            // Verifica si la cita existe en la base de datos
            var appointment = await _appointmentRepository.GetByIdAsync(request.Id);
            if (appointment == null)
            {
                // Si la cita no existe, lanza una excepción que será manejada por el middleware de errores
                throw new KeyNotFoundException($"No se encontró la cita con ID {request.Id}.");
            }

            // Elimina la cita
            await _appointmentRepository.DeleteAsync(request.Id);
            // Guarda los cambios
            await _appointmentRepository.SaveChangesAsync();

            // Retorna Unit.Value indicando que la operación fue exitosa
            return Unit.Value;
        }
    }
}