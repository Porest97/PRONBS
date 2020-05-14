using PRONBS.LAB.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRONBS.LAB.Models.ViewModels
{
    public class ViewModel
    {
        public List<TestModel> TestModels { get; internal set; }

        public List<SubModel> SubModels { get; internal set; }
    }
}
