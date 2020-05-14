using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PRONBS.Models.DataModels
{
    public class Project
    {
        public int Id { get; set; }

        //Location @ Customer !
        [Display(Name = "Site")]
        public int? SiteId { get; set; }
        [Display(Name = "Site")]
        [ForeignKey("SiteId")]
        public Site Site { get; set; }

        //Project personal !
        [Display(Name = "Project Manager")]
        public int? PersonId { get; set; }
        [Display(Name = "Project Manager")]
        [ForeignKey("PersonId")]
        public Person ProjectManager { get; set; }

        [Display(Name = "Technichian")]
        public int? PersonId1 { get; set; }
        [Display(Name = "Technichian")]
        [ForeignKey("PersonId1")]
        public Person Technichian { get; set; }


        [Display(Name = "Extras")]
        public string ExtraPeople { get; set; }

        //Quotas !
        [Display(Name = "Offer #1")]
        public int? OfferId { get; set; }
        [Display(Name = "Offer #1")]
        [ForeignKey("OfferId")]
        public Offer Offer1 { get; set; }

        [Display(Name = "Offer #2")]
        public int? OfferId1 { get; set; }
        [Display(Name = "Offer #2")]
        [ForeignKey("OfferId1")]
        public Offer Offer2 { get; set; }

        [Display(Name = "Offer #3")]
        public int? OfferId2 { get; set; }
        [Display(Name = "Offer #3")]
        [ForeignKey("OfferId2")]
        public Offer Offer3 { get; set; }

        [Display(Name = "Offer #4")]
        public int? OfferId3 { get; set; }
        [Display(Name = "Offer #4")]
        [ForeignKey("OfferId3")]
        public Offer Offer4 { get; set; }

        [Display(Name = "Offer #5")]
        public int? OfferId4 { get; set; }
        [Display(Name = "Offer #5")]
        [ForeignKey("OfferId4")]
        public Offer Offer5 { get; set; }

        //Description !
        [Display(Name = "Description")]
        public string ProjectDescription { get; set; }

        //Planing !
        [Display(Name = "Scheduled Start")]
        public DateTime? ProjectStart { get; set; }

        [Display(Name = "Scheduled End")]
        public DateTime? ProjectEnd { get; set; }

        //Settings !
        [Display(Name = "Type")]
        public int? ProjectTypeId { get; set; }
        [Display(Name = "Type")]
        [ForeignKey("ProjectTypeId")]
        public ProjectType ProjectType { get; set; }

        [Display(Name = "Status")]
        public int? ProjectStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("ProjectStatusId")]
        public ProjectStatus ProjectStatus { get; set; }

        //Log !
        [Display(Name = "Log")]
        public string ProjectLog { get; set; }

        ////Total project cost !
        [Display(Name = "Project Total")]
        public double TotalProjectCost { get; set; }

        ////Total Hours cost !
        [Display(Name = "Total Hours Cost")]
        public double TotalHoursCost { get; set; }

        ////Total material cost !
        [Display(Name = "Total Mtr. Cost")]
        public double TotalMtrCost { get; set; }

    }
    public class ProjectType
    {
        public int Id { get; set; }

        public string ProjectTypeName { get; set; }
    }

    public class ProjectStatus
    {
        public int Id { get; set; }

        public string ProjectStatusName { get; set; }
    }
}
