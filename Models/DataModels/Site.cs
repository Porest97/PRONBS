using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRONBS.Models.DataModels
{
    public class Site
    {
        public int Id { get; set; }

        [Display(Name = "#")]
        public string SiteNumber { get; set; }

        [Display(Name = "Site")]
        public string SiteName { get; set; }

        [Display(Name = "Streetaddress")]
        public string StreetAddress { get; set; }

        [Display(Name = "Postalcode")]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "Address")]
        public string Address { get { return string.Format("{0} {1} {2}", StreetAddress, ZipCode, City); } }

        [Display(Name = "No - Site")]
        public string NoSite { get { return string.Format("{0} {1} {2}", SiteNumber, "-", SiteName); } }

        [Display(Name = "NO Floors")]
        public string NumberOfFloors { get; set; }

        [Display(Name = "Site notes")]
        public string SiteNotes { get; set; }

        //Site settings !
        [Display(Name = "Site Role")]
        public int? SiteRoleId { get; set; }
        [Display(Name = "Site Role")]
        [ForeignKey("SiteRoleId")]
        public SiteRole SiteRole { get; set; }

        public int? SiteStatusId { get; set; }
        [Display(Name = "Site Status")]
        [ForeignKey("SiteStatusId")]
        public SiteStatus SiteStatus { get; set; }

        [Display(Name = "Site Type")]
        public int? SiteTypeId { get; set; }
        [Display(Name = "Site Type")]
        [ForeignKey("SiteTypeId")]
        public SiteType SiteType { get; set; }

        //Site Contacts !
        [Display(Name = "Site Contact")]
        public int? PersonId { get; set; }
        [Display(Name = "Site Contact")]
        [ForeignKey("PersonId")]
        public Person Contact1 { get; set; }

        [Display(Name = "Site Contact")]
        public int? PersonId1 { get; set; }
        [Display(Name = "Site Contact")]
        [ForeignKey("PersonId1")]
        public Person Contact2 { get; set; }

        [Display(Name = "Company")]
        public int? CompanyId { get; set; }
        [Display(Name = "Company")]
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
    }

    //Roles, Statuses and Types !

    public class SiteRole
    {
        public int Id { get; set; }

        [Display(Name = "Role")]
        public string SiteRoleName { get; set; }
    }

    public class SiteStatus
    {
        public int Id { get; set; }

        [Display(Name = "Status")]
        public string SiteStatusName { get; set; }
    }

    public class SiteType
    {
        public int Id { get; set; }

        [Display(Name = "Type")]
        public string SiteTypeName { get; set; }
    }
}