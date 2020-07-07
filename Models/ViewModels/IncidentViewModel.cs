using PRONBS.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRONBS.Models.ViewModels
{
    public class IncidentViewModel
    {
        public List<Incident> Incidents { get; internal set; }

        public List<NABLog> NABLogs { get; internal set; }

    }
}
