using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Data
{
    public class Invitation : BaseEntity
    {
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
        public int IndividualId { get; set; }
        public virtual Individual Individual { get; set; }
    }
}
