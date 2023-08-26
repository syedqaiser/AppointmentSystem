using MyClinicApi.Interfaces;
using MyClinicApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }  

    


        [HttpPost]
        public IActionResult AddAppointment(appointment appointment)
        {
            _appointmentService.AddAppointment(appointment);
            return CreatedAtAction(nameof(GetAppointmentId), new { id = appointment.id}, appointment);
        }

        [HttpPost("cancel")]
        public IActionResult CancelAppointment(appointment appointment)
        {
            _appointmentService.CancelApointment(appointment);
            return CreatedAtAction(nameof(GetAppointmentId), new { id = appointment.id }, appointment); ;
           // return null;
        }

        [HttpGet("today")]
        public IActionResult GetTodaysAppointments()
        {
            List<patientappoinment> appointments = _appointmentService.GetTodaysAppointments();
            return Ok(appointments);
        }

        [HttpGet("byDate")]
        public IActionResult GetAppointmentsByDate(string date)
        {
            IEnumerable<patientappoinment> appointments = _appointmentService.GetAppointmentsByDate(date);
            return Ok(appointments);
        }
        [HttpGet("{names}")]
        public IActionResult GetAppointmentById(string name)
        {
           List<patientappoinment> appointment = _appointmentService.GetAppointmentsByPatientName(name);
            if (appointment == null)
                return NotFound();
            return Ok(appointment);
        }

        [HttpGet("{id}")]
        public IActionResult GetAppointmentId(int id)
        {
            var appointment = _appointmentService.GetAppointmentId(id);
            if (appointment == null)
                return NotFound();
            return Ok(appointment);
        }
    }
}

