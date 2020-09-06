using System;
using System.Collections.Generic;

namespace Report.Data
{
    public class Event : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateTime { get; set; }
        public EventStatus Status { get; set; }
        public ICollection<Invitation> Invitations { get; set; }
    }
}
