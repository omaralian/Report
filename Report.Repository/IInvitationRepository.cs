using Report.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Report.Repository
{
    public interface IInvitationRepository
    {
        Task<List<Invitation>> GetAllAsync();
        Task<List<Invitation>> ReportAsync();
    }
}
