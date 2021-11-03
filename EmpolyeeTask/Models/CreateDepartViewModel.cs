using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpolyeeTask.Models
{
    public class CreateDepartViewModel
    {
        public string DepartName { get; set; }

        public int DepartNo { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
    }
}
