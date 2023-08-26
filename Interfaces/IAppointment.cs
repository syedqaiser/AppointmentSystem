using MyClinicApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyClinicApi.Interfaces
{
    public interface IAppointmentRepository
    {
        List<patientappoinment> GetAppointmentsByDate(string date);
        List<patientappoinment> GetAppointmentsByPatientName(string patientName);
        appointment AddAppointment(appointment appointment);
        appointment CancelAppointment(appointment appointment);
        List<patientappoinment> GetTodaysAppointments();

        appointment GetAppointmentId(int id);
    }

    public interface IAppointmentService
    {
        List<patientappoinment> GetAppointmentsByDate(string date);
        List<patientappoinment> GetAppointmentsByPatientName(string patientName);
        void AddAppointment(appointment appointment);
        void CancelApointment(appointment appointment);

        appointment GetAppointmentId(int id);
        List<patientappoinment> GetTodaysAppointments();
        // Other methods
    }
    
}
