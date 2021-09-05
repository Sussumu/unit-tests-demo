using Demo.Domain.DTOs;
using Demo.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Demo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService ?? throw new ArgumentNullException(nameof(appointmentService));
        }

        [HttpPost]
        public IActionResult Post(ScheduleRequest request)
        {
            var schedule = _appointmentService.Schedule(request);

            return Ok(schedule);
        }
    }
}
