using Entities;
using MediatR;
using System.Collections.Generic;

namespace Services.Requests.Appointments
{
    // Query para obtener todas las citas
    public class GetAllAppointmentsQuery : IRequest<IEnumerable<Appointment>>
    {
    }
}
