using MyClinicApi.Interfaces;
using MyClinicApi.Models;
using MyClinicApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyClinicApi.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ClinicContext _context;

        public AppointmentRepository(ClinicContext context)
        {
            _context = context;
        }

        public appointment AddAppointment(appointment appointment)
        {
            var result =  _context.appointments.Add(appointment);
            _context.SaveChanges();
            return result.Entity;
        }

        public appointment CancelAppointment(appointment data)
        {
            var result = _context.appointments.Update(data);
            _context.SaveChanges();
            return result.Entity;

        }

        public appointment GetAppointmentId(int id)
        {
            var appointmentData    = _context.appointments.FirstOrDefault(p => p.id == id);

            return appointmentData;
        }

        public List<patientappoinment> GetAppointmentsByDate(string date)
        {
            var resultList = (from patient in _context.patients
                              join appointment in _context.appointments
                              on patient.id equals appointment.id
                              where appointment.date == date

                              select new patientappoinment
                              {
                                  firstname = patient.firstname,
                                  date = appointment.date
                              }).ToList();
            return resultList;
            
            //return _context.Appointments
            //    .Where(a => a.Date.Date == date.Date)
            //    .ToList();
        }

        public List<patientappoinment> GetAppointmentsByPatientName(string patientName)
        {
            var resultList = (from patient in _context.patients
                              join appointment in _context.appointments
                              on patient.id equals appointment.patientid
                              where patient.firstname.Contains(patientName)
                              select new patientappoinment
                              {
                                  firstname = patient.firstname,
                                  date = appointment.date
                              }).ToList();
            return resultList;

            //return _context.Patients
            //    .Where(a => Patients.FirstName.Contains(patientName))
            //    .ToList();
        }

        public List<patientappoinment> GetTodaysAppointments()
        {
            string date = DateTime.Today.ToString("yyyy-MM-dd");
            var resultList =  (from patient in _context.patients
                        join appointment in _context.appointments
                        on patient.id equals appointment.patientid
                               where appointment.date == date

                               select new patientappoinment
                        {
                            firstname= patient.firstname,
                            date= appointment.date
                        }).ToList();
            return  resultList;

        }

    




        // Implement other methods
    }
}
