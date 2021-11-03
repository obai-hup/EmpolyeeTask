using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmpolyeeTask.Models
{
    public class Department
    {
        public int ID { get; set; }

        [Required, MinLength(10)]

        public string DepartName { get; set; }

        [Required,Display(Name ="DepartNumber")]

        public int DepartNo { get; set; }


      

        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
