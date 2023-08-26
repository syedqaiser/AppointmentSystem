using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyClinicApi.Models
{
    public class appointment
    {
        [Key]
        public int id { get; set; }
        public string date { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public string cancellationreason { get; set; }
        public int doctorid { get; set; }
        //public Doctor doctor { get; set; }
        public int patientid { get; set; }
        

    }
}
