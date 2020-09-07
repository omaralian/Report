using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Report.Service
{
    public interface IInvitationService
    {
        public Task<string> InvitationReportAsync(string filename, string type);
    }
}
