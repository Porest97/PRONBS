using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PRONBS.Models.DataModels
{
    public class Plan
    {
        public int Id  { get; set; }

        //PlanDescription !
        [Display(Name = "Plan")]
        public string PlanDescription { get; set; }

        //Incident !
        [Display(Name = "Incident")]
        public int? IncidentId { get; set; }
        [Display(Name = "Incident")]
        [ForeignKey("IncidentId")]
        public Incident Incident { get; set; }

        // Stages !
        [Display(Name = "#1")]
        public int? StageId { get; set; }
        [Display(Name = "#1")]
        [ForeignKey("StageId")]
        public Stage Stage1 { get; set; }

        [Display(Name = "#2")]
        public int? StageId1 { get; set; }
        [Display(Name = "#2")]
        [ForeignKey("StageId1")]
        public Stage Stage2 { get; set; }

        [Display(Name = "#3")]
        public int? StageId2 { get; set; }
        [Display(Name = "#3")]
        [ForeignKey("StageId2")]
        public Stage Stage3 { get; set; }

        [Display(Name = "#4")]
        public int? StageId3 { get; set; }
        [Display(Name = "#4")]
        [ForeignKey("StageId3")]
        public Stage Stage4 { get; set; }

        [Display(Name = "#5")]
        public int? StageId4 { get; set; }
        [Display(Name = "#5")]
        [ForeignKey("StageId4")]
        public Stage Stage5 { get; set; }

        [Display(Name = "#6")]
        public int? StageId5 { get; set; }
        [Display(Name = "#6")]
        [ForeignKey("StageId5")]
        public Stage Stage6 { get; set; }

        // Drawing UpLoad !

        public string Drawing { get; set; }

        // PlanStatus !
        [Display(Name = "Status")]
        public int? PlanStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("PlanStatusId")]
        public PlanStatus PlanStatus { get; set; }
    }

    public class PlanStatus
    {
        public int Id { get; set; }

        [Display(Name = "Status")]
        public string PlanStatusName { get; set; }
    }

    public class Stage
    {
        public  int Id { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        //StageStatus !
        [Display(Name = "Status")]
        public int? StageStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("StageStatusId")]
        public StageStatus StageStatus { get; set; }
    }

    public class StageStatus
    {
        public int Id { get; set; }

        [Display(Name = "Status")]
        public string StageStatusName { get; set; }
    }
}
