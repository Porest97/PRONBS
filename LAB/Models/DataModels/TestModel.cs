using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PRONBS.LAB.Models.DataModels
{
    public class TestModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public double TotalHours { get; set; }

        public double TotalMtr { get; set; }

        public double TotalAmount { get; set; }

        [Display(Name = "Offer #1")]
        public int? SubModelId { get; set; }
        [Display(Name = "Offer #1")]
        [ForeignKey("SubModelId")]
        public SubModel Offer1 { get; set; }

        [Display(Name = "Offer #2")]
        public int? SubModelId1 { get; set; }
        [Display(Name = "Offer #2")]
        [ForeignKey("SubModelId1")]
        public SubModel Offer2 { get; set; }

        


    }

    public class SubModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public double Hours { get; set; }

        public double Price { get; set; }

        public double Mtr { get; set; }

        public double TotalCost { get; set; }
    }
}
