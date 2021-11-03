using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmpolyeeTask.Models
{
    public class Employee : IdentityUser
    {
        public Employee()
        {

        }
        [Required, MinLength(4)]
        public string FirstName { get; set; }

        [Required, MinLength(4)]

        public string LastName { get; set; }


        //public string FullName
        //{
        //    get
        //    {
        //        string fullName = LastName;
        //        if (!string.IsNullOrWhiteSpace(FirstName))
        //        {
        //            if (!string.IsNullOrWhiteSpace(fullName))
        //            {
        //                fullName += ", ";
        //            }

        //            fullName += FirstName;
        //        }
        //        return fullName;
        //    }
        //}
        public string FullName { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "You Must Choose a Country")]
        [Display(Name = "Country")]
        public int CountryId { get; set; }
        public virtual Country country { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "You Must Choose a Department")]
        [Display(Name = "Departmenet")]
        public int DepartId { get; set; }

        public virtual Department Departments { get; set; }
    }
}
