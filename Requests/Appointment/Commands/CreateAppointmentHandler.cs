// Requests/Appointments/CreateAppointmentHandler.cs
using Entities;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Services.GenericRepository;
using Services.Hubs;
using Services.Requests.Apointments;
using System.Threading;
using System.Threading.Tasks;

namespace Requests.Appointments
{
    public class CreateAppointmentHandler : IRequestHandler<CreateAppointmentCommand, Appointment>
    {
        private readonly ISvGenericRepository<Appointment> _appointmentRepository;
        private readonly IHubContext<NotificationHub> _hubContext;

        public CreateAppointmentHandler(ISvGenericRepository<Appointment> appointmentRepository, IHubContext<NotificationHub> hubContext)
        {
            _appointmentRepository = appointmentRepository;
            _hubContext = hubContext;
        }

        public async Task<Appointment> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = new Appointment
            {
                Description = request.Description,
                Date = request.Date,
                CustomerName = request.CustomerName,
                ServiceId = request.ServiceId,
                StatusId = 3 // Ejemplo de estado pendiente
            };

            await _appointmentRepository.AddAsync(appointment);
            await _appointmentRepository.SaveChangesAsync();

            await _hubContext.Clients.All.SendAsync("ReceiveNotification", "Nueva cita creada!");

            return appointment;
        }
    }
}
