using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Report.Repository
{
    public interface IInvitationRepository
    {
        public Task<DataTable> InvitationReportAsync();
    }
}
