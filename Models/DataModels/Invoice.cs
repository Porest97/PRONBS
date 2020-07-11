using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PRONBS.Models.DataModels
{
    public class Invoice
    {
        public int Id { get; set; }

        [Display(Name = "Invoice date")]
        public DateTime InvoiceDate { get; set; }
        [Display(Name = "Invoice no")]
        public int? InvoiceNumber { get; set; }
        [Display(Name = "OCR")]
        public int? OCRNumber { get; set; }

        [Display(Name = "Cust NO")]
        public string CustomerNumber { get; set; }
        [Display(Name = "Terms of Delivery")]
        public string TermsOfDelivery { get; set; }
        [Display(Name = "Your VAT no")]
        public string YourVATNumber { get; set; }

        //Our Reference
        [Display(Name = "Our Reference")]
        public int? PersonId { get; set; }
        [Display(Name = "Our Reference")]
        [ForeignKey("PersonId")]
        public Person OurReference { get; set; }
        [Display(Name = "Due date")]
        public string PaymentConditions { get; set; }
        [Display(Name = "Due date")]
        public DateTime InvoiceDueDate { get; set; }
        [Display(Name = "Penalty Interest")]
        public string PenaltyInetrest { get; set; }


        

        //Invoice to Company
        [Display(Name = "Invoice To:")]
        public int? CompanyId { get; set; }
        [Display(Name = "Invoice To:")]
        [ForeignKey("CompanyId")]
        public Company InvoiceTo { get; set; }

        //Invoice from Company
        [Display(Name = "Invoice From:")]
        public int? CompanyId1 { get; set; }
        [Display(Name = "Invoice From:")]
        [ForeignKey("CompanyId1")]
        public Company InvoiceFrom { get; set; }

        //Invoice Items !

        //WorkLog 1 - 5 !
        [Display(Name = "#1")]
        public int? WorkLogId { get; set; }
        [Display(Name = "#1")]
        [ForeignKey("WorkLogId")]
        public WLog WL1 { get; set; }

        [Display(Name = "#2")]
        public int? WorkLogId1 { get; set; }
        [Display(Name = "#2")]
        [ForeignKey("WorkLogId1")]
        public WLog WL2 { get; set; }

        [Display(Name = "#3")]
        public int? WorkLogId2 { get; set; }
        [Display(Name = "#3")]
        [ForeignKey("WorkLogId2")]
        public WLog WL3 { get; set; }

        [Display(Name = "#4")]
        public int? WorkLogId3 { get; set; }
        [Display(Name = "#4")]
        [ForeignKey("WorkLogId3")]
        public WLog WL4 { get; set; }

        [Display(Name = "#5")]
        public int? WorkLogId4 { get; set; }
        [Display(Name = "#5")]
        [ForeignKey("WorkLogId4")]
        public WLog WL5 { get; set; }

        //WorkLog 6 - 10 !
        [Display(Name = "#6")]
        public int? WorkLogId5 { get; set; }
        [Display(Name = "#6")]
        [ForeignKey("WorkLogId5")]
        public WLog WL6 { get; set; }

        [Display(Name = "#7")]
        public int? WorkLogId6 { get; set; }
        [Display(Name = "#7")]
        [ForeignKey("WorkLogId6")]
        public WLog WL7 { get; set; }

        [Display(Name = "#8")]
        public int? WorkLogId7 { get; set; }
        [Display(Name = "#8")]
        [ForeignKey("WorkLogId7")]
        public WLog WL8 { get; set; }

        [Display(Name = "#9")]
        public int? WorkLogId8 { get; set; }
        [Display(Name = "#9")]
        [ForeignKey("WorkLogId8")]
        public WLog WL9 { get; set; }

        [Display(Name = "#10")]
        public int? WorkLogId9 { get; set; }
        [Display(Name = "#10")]
        [ForeignKey("WorkLogId9")]
        public WLog WL10 { get; set; }

        //WorkLog 11 - 15 !
        [Display(Name = "#11")]
        public int? WorkLogId10 { get; set; }
        [Display(Name = "#11")]
        [ForeignKey("WorkLogId10")]
        public WLog WL11 { get; set; }

        [Display(Name = "#12")]
        public int? WorkLogId11 { get; set; }
        [Display(Name = "#12")]
        [ForeignKey("WorkLogId11")]
        public WLog WL12 { get; set; }

        [Display(Name = "#13")]
        public int? WorkLogId12 { get; set; }
        [Display(Name = "#13")]
        [ForeignKey("WorkLogId12")]
        public WLog WL13 { get; set; }

        [Display(Name = "#14")]
        public int? WorkLogId13 { get; set; }
        [Display(Name = "#14")]
        [ForeignKey("WorkLogId13")]
        public WLog WL14 { get; set; }

        [Display(Name = "#15")]
        public int? WorkLogId14 { get; set; }
        [Display(Name = "#15")]
        [ForeignKey("WorkLogId14")]
        public WLog WL15 { get; set; }

        //WorkLog 16 - 20 !
        [Display(Name = "#16")]
        public int? WorkLogId15 { get; set; }
        [Display(Name = "#16")]
        [ForeignKey("WorkLogId15")]
        public WLog WL16 { get; set; }

        [Display(Name = "#17")]
        public int? WorkLogId16 { get; set; }
        [Display(Name = "#17")]
        [ForeignKey("WorkLogId16")]
        public WLog WL17 { get; set; }

        [Display(Name = "#18")]
        public int? WorkLogId17 { get; set; }
        [Display(Name = "#18")]
        [ForeignKey("WorkLogId17")]
        public WLog WL18 { get; set; }

        [Display(Name = "#19")]
        public int? WorkLogId18 { get; set; }
        [Display(Name = "#19")]
        [ForeignKey("WorkLogId18")]
        public WLog WL19 { get; set; }

        [Display(Name = "#20")]
        public int? WorkLogId19 { get; set; }
        [Display(Name = "#20")]
        [ForeignKey("WorkLogId19")]
        public WLog WL20 { get; set; }


    }
}
