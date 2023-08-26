using MyClinicApi.Interfaces;
using MyClinicApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyClinicApi.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public List<patientappoinment> GetAppointmentsByDate(string date)
        {
            return _appointmentRepository.GetAppointmentsByDate(date);
        }

        

        public void AddAppointment(appointment appointment)
        {
            // You might want to perform validation or business logic before adding the appointment
            _appointmentRepository.AddAppointment(appointment);
        }

        

        public List<patientappoinment> GetTodaysAppointments()
        {
            //string today = DateTime.Today.ToString("yyyy-mm-dd");            

                return _appointmentRepository.GetTodaysAppointments();
        }
        
        public IEnumerable<appointment> GetAppointmentsByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public void CancelApointment(appointment appointment)
        {
            _appointmentRepository.CancelAppointment(appointment);
        }

    

        List<patientappoinment> IAppointmentService.GetAppointmentsByPatientName(string patientName)
        {
            return _appointmentRepository.GetAppointmentsByPatientName(patientName);
        }

        public appointment GetAppointmentId(int id)
        {
            return _appointmentRepository.GetAppointmentId(id);
        }
    }
    
}

