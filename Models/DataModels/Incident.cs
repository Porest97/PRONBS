using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PRONBS.Models.DataModels
{
    public class Incident
    {
        public int Id { get; set; }

        // Incident settings
        [Display(Name = "Prio.")]
        public int? IncidentPriorityId { get; set; }
        [Display(Name = "Priority")]
        [ForeignKey("IncidentPriorityId")]
        public IncidentPriority IncidentPriority { get; set; }

        [Display(Name = "Status")]
        public int? IncidentStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("IncidentStatusId")]
        public IncidentStatus IncidentStatus { get; set; }

        [Display(Name = "Type")]
        public int? IncidentTypeId { get; set; }
        [Display(Name = "Type")]
        [ForeignKey("IncidentTypeId")]
        public IncidentType IncidentType { get; set; }

        //Incident orgin

        [Display(Name = "INC#")]
        public string IncidentNumber { get; set; }

        [Display(Name = "Created")]
        public DateTime? Created { get; set; }

        [Display(Name = "Creator")]
        public int? PersonId { get; set; }
        [Display(Name = "Creator")]
        [ForeignKey("PersonId")]
        public Person Creator { get; set; }

        //Incident Location
        [Display(Name = "Site")]
        public int? SiteId { get; set; }
        [Display(Name = "Site")]
        [ForeignKey("SiteId")]
        public Site Site { get; set; }

        //Incident Handling
        [Display(Name = "Received")]
        public DateTime? Received { get; set; }

        [Display(Name = "Receiver")]
        public int? PersonId1 { get; set; }
        [Display(Name = "Receiver")]
        [ForeignKey("PersonId1")]
        public Person Receiver { get; set; }

        // Scheduling and assignment
        [Display(Name = "FE Scheduled")]
        public DateTime? FEScheduled { get; set; }

        [Display(Name = "FE Assigned")]
        public int? PersonId2 { get; set; }
        [Display(Name = "FE Assigned")]
        [ForeignKey("PersonId2")]
        public Person FEAssigned { get; set; }

        //Incident Description
        [Display(Name = "Description")]
        public string Description { get; set; }

        //Incident Logg
        [Display(Name = "FE Enters Site")]
        public DateTime? FEEntersSite { get; set; }

        [Display(Name = "FE Exits Site")]
        public DateTime? FEEExitsSite { get; set; }

        [Display(Name = "Logg")]
        public string Logg { get; set; }

        //Incident Resolution
        [Display(Name = "Resolved")]
        public DateTime? IssueResolved { get; set; }


        [Display(Name = "Resolution")]
        public string Resolution { get; set; }

        // PO (Purchase Order)

        [Display(Name = "PO #")]
        public int? PurchaseOrderId { get; set; }
        [Display(Name = "PO #")]
        [ForeignKey("PurchaseOrderId")]
        public PurchaseOrder PurchaseOrder { get; set; }

        // Concatinations 

        [Display(Name = "Inc# and Description")]
        public string NumberDescription { get { return string.Format("{0} {1} ", IncidentNumber, Description); } }

        //Reporting to accounting
        //When Status = Resolved then build an IncidentReport !

        //Incident
        [Display(Name = "Mtrl List")]
        public int? MtrlListId { get; set; }
        [Display(Name = "Mtrl List")]
        [ForeignKey("MtrlListId")]
        public MtrlList MtrlList { get; set; }
    }

    //Prios, Statuses, Types
    public class IncidentPriority
    {
        public int Id { get; set; }

        [Display(Name = "Prio.")]
        public string IncidentPriorityName { get; set; }
    }
    public class IncidentStatus
    {
        public int Id { get; set; }

        [Display(Name = "Status")]
        public string IncidentStatusName { get; set; }
    }
    public class IncidentType
    {
        public int Id { get; set; }

        [Display(Name = "Type")]
        public string IncidentTypeName { get; set; }
    }
    public class MtrlList
    {
        public int Id { get; set; }

        [Display(Name = "Mtrl. List")]
        public string Description { get; set; }

        [Display(Name = "#1")]        
        public string Item1 { get; set; }

        [Display(Name = "#2")]
        public string Item2 { get; set; }

        [Display(Name = "#3")]
        public string Item3 { get; set; }

        [Display(Name = "#4")]
        public string Item4 { get; set; }

        [Display(Name = "#5")]
        public string Item5 { get; set; }

        [Display(Name = "#6")]
        public string Item6 { get; set; }

        [Display(Name = "#7")]
        public string Item7 { get; set; }

        [Display(Name = "#8")]
        public string Item8 { get; set; }

        [Display(Name = "#9")]
        public string Item9 { get; set; }

        [Display(Name = "#10")]
        public string Item10 { get; set; }
    }
}
