using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Data
{
    public class Individual : BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Invitation> Invitations { get; set; }
    }
}
