using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpolyeeTask.Models
{
    public class EditDepartViewModel
    {
        public int ID { get; set; }
        public string DepartName { get; set; }
        public int DepartNo { get; set; }
        public DateTime LastModifiedAt { get; set; } = DateTime.Now;
        public string LastModifiedBy { get; set; }
    }
}
