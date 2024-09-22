using Entities;
using MediatR;

namespace Services.Requests.Apointments
{
    public class CreateAppointmentCommand : IRequest<Appointment>
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string CustomerName { get; set; }
        public int ServiceId { get; set; }
    }
}
