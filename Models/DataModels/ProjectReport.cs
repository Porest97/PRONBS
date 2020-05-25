using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PRONBS.Models.DataModels
{
    public class ProjectReport
    {
        public int Id { get; set; }

        [Display(Name ="Report")]
        public string ReportName { get; set;}
        [Display(Name = "Conclusions")]
        public string ReportConclusions { get; set; }

        //Project !
        [Display(Name = "Project")]
        public int? ProjectId { get; set; }
        [Display(Name = "Project")]
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        //Incidents !
        [Display(Name = "Incidents")]
        public List<Incident> Incidents { get; internal set; }

        //Status !
        [Display(Name = "Status")]
        public int? ReportStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("ReportStatusId")]
        public ReportStatus ReportStatus { get; set; }
    }

    public class ReportStatus
    {
        public int Id { get; set; }

        [Display(Name = "Status")]
        public string ReportStatusName { get; set; }
    }
}
