using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.Web.Models
{
    public class ReportViewModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string CreatedAt { get; set; }
        public string Link 
        {
            get
            {
                return "ReportStaticFiles/" + Name + "." + Type;
            }
            set
            {
                Link = value;
            }

        }
    }
}
