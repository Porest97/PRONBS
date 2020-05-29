using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PRONBS.Models.DataModels
{
    public class MonthlyTimeReport
    {
        public int Id { get; set; }

        [Display(Name = "Created")]
        public DateTime? Created { get; set; }

        [Display(Name = "Creator")]
        public int? PersonId { get; set; }
        [Display(Name = "Creator")]
        [ForeignKey("PersonId")]
        public Person Creator { get; set; }


    }
}
