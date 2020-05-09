using PRONBS.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRONBS.Models.ViewModels
{
    public class DataViewModel
    {
        //DATA Entities ! 
        
        public List<Company> Companies { get; internal set; }
        
        public List<Incident> Incidents { get; internal set; }
        
        public List<Person> People { get; internal set; }

        public List<PurchaseOrder> PurchaseOrders { get; internal set; }

        public List<Site> Sites { get; internal set; }             

        public List<WLog> WLogs { get; internal set; }

       

    }
}
