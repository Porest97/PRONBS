using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PRONBS.Models.DataModels;

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
    }
}
