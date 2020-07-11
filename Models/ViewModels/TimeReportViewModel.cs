using PRONBS.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRONBS.Models.ViewModels
{
    public class TimeReportViewModel
    {
        public List<WLog> WLogs { get; internal set; }

        public List<NABLog> NABLogs { get; set; }
    }
}
