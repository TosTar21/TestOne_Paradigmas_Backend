using Microsoft.AspNetCore.Mvc;
using MediatR;
using Services.DTO;
using Services.Requests.Apointments;
using Services.Requests.Appointments; 

namespace TestOne_Paradigmas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppointmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Acción para crear una nueva cita
        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] DTOAppointment appointmentDto)
        {
            var command = new CreateAppointmentCommand
            {
                Description = appointmentDto.Description,
                Date = appointmentDto.Date,
                CustomerName = appointmentDto.CustomerName,
                ServiceId = appointmentDto.ServiceId
            };
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAppointments), new { id = result.Id }, result);
        }

        // Acción para obtener todas las citas
        [HttpGet]
        public async Task<IActionResult> GetAppointments()
        {
            var query = new GetAllAppointmentsQuery();
            var appointments = await _mediator.Send(query);
            return Ok(appointments);
        }

        // Acción para eliminar una cita por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            await _mediator.Send(new DeleteAppointmentCommand { Id = id });
            return NoContent();
        }
    }
}
