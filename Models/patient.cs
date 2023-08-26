using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyClinicApi.Models
{
    public class patient
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public DateTime dateofbirth { get; set; }
        public string contactnumber { get; set; }
    }

}
