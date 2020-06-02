using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PRONBS.Models.DataModels;
using PRONBS.LAB.Models.DataModels;

namespace PRONBS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PRONBS.Models.DataModels.Company> Company { get; set; }
        public DbSet<PRONBS.Models.DataModels.CompanyRole> CompanyRole { get; set; }
        public DbSet<PRONBS.Models.DataModels.CompanyStatus> CompanyStatus { get; set; }
        public DbSet<PRONBS.Models.DataModels.CompanyType> CompanyType { get; set; }
        public DbSet<PRONBS.Models.DataModels.Incident> Incident { get; set; }
        public DbSet<PRONBS.Models.DataModels.IncidentPriority> IncidentPriority { get; set; }
        public DbSet<PRONBS.Models.DataModels.IncidentStatus> IncidentStatus { get; set; }
        public DbSet<PRONBS.Models.DataModels.IncidentType> IncidentType { get; set; }
        public DbSet<PRONBS.Models.DataModels.Person> Person { get; set; }
        public DbSet<PRONBS.Models.DataModels.PersonAccounts> PersonAccounts { get; set; }
        public DbSet<PRONBS.Models.DataModels.PersonRole> PersonRole { get; set; }
        public DbSet<PRONBS.Models.DataModels.PersonStatus> PersonStatus { get; set; }
        public DbSet<PRONBS.Models.DataModels.PersonType> PersonType { get; set; }
        public DbSet<PRONBS.Models.DataModels.PurchaseOrder> PurchaseOrder { get; set; }
        public DbSet<PRONBS.Models.DataModels.Site> Site { get; set; }
        public DbSet<PRONBS.Models.DataModels.SiteRole> SiteRole { get; set; }
        public DbSet<PRONBS.Models.DataModels.SiteStatus> SiteStatus { get; set; }
        public DbSet<PRONBS.Models.DataModels.SiteType> SiteType { get; set; }
        public DbSet<PRONBS.Models.DataModels.WLog> WLog { get; set; }
        public DbSet<PRONBS.Models.DataModels.WLogStatus> WLogStatus { get; set; }
        public DbSet<PRONBS.Models.DataModels.Offer> Offer { get; set; }
        public DbSet<PRONBS.Models.DataModels.NABLog> NABLog { get; set; }
        public DbSet<PRONBS.Models.DataModels.NABLogStatus> NABLogStatus { get; set; }
        public DbSet<PRONBS.Models.DataModels.Project> Project { get; set; }
        public DbSet<PRONBS.Models.DataModels.ProjectStatus> ProjectStatus { get; set; }
        public DbSet<PRONBS.Models.DataModels.ProjectType> ProjectType { get; set; }
        public DbSet<PRONBS.LAB.Models.DataModels.TestModel> TestModel { get; set; }
        public DbSet<PRONBS.LAB.Models.DataModels.SubModel> SubModel { get; set; }
        public DbSet<PRONBS.Models.DataModels.MtrlList> MtrlList { get; set; }
        public DbSet<PRONBS.Models.DataModels.ProjectReport> ProjectReport { get; set; }
        public DbSet<PRONBS.Models.DataModels.Bill> Bill { get; set; }
        public DbSet<PRONBS.Models.DataModels.BillStatus> BillStatus { get; set; }
        public DbSet<PRONBS.Models.DataModels.Asset> Asset { get; set; }
        public DbSet<PRONBS.Models.DataModels.AssetBrand> AssetBrand { get; set; }
        public DbSet<PRONBS.Models.DataModels.AssetStatus> AssetStatus { get; set; }
        public DbSet<PRONBS.Models.DataModels.AssetType> AssetType { get; set; }
        public DbSet<PRONBS.Models.DataModels.Plan> Plan { get; set; }
        public DbSet<PRONBS.Models.DataModels.Stage> Stage { get; set; }
        public DbSet<PRONBS.Models.DataModels.PlanStatus> PlanStatus { get; set; }
        public DbSet<PRONBS.Models.DataModels.StageStatus> StageStatus { get; set; }
       
        
    }
}
