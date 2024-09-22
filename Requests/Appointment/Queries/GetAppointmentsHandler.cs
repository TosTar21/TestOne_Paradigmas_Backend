using Entities;
using MediatR;
using Services.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Services.Requests.Appointments
{
    // Manejador para procesar el query de obtener todas las citas
    public class GetAllAppointmentsHandler : IRequestHandler<GetAllAppointmentsQuery, IEnumerable<Appointment>>
    {
        private readonly ISvGenericRepository<Appointment> _appointmentRepository;

        public GetAllAppointmentsHandler(ISvGenericRepository<Appointment> appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        // Método que maneja la lógica para obtener todas las citas
        public async Task<IEnumerable<Appointment>> Handle(GetAllAppointmentsQuery request, CancellationToken cancellationToken)
        {
            var appointments = await _appointmentRepository.Query()
                .Include(a => a.Service) // Incluye el servicio asociado
                .Include(a => a.Status)  // Incluye el estado asociado
                .ToListAsync(cancellationToken);

            // Validación adicional si es necesario
            if (appointments == null || appointments.Count == 0)
            {
                // Aquí puedes retornar una lista vacía o lanzar una excepción, según la lógica de negocio
                return new List<Appointment>();
            }

            return appointments; // Retorna la lista de citas
        }
    }
}
