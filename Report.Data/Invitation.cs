using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Data
{
    public class Invitation : BaseEntity
    {
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int IndividualId { get; set; }
        public Individual Individual { get; set; }
    }
}
