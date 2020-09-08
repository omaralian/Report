using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Report.Model;


namespace Report.Repository
{
    public interface IReportRepository
    {
        public Task<bool> Insert(string Name, string Type, string Status);

        public Task<bool> UpdateStatus(string Name, string Status);

        public IEnumerable<ReportModel> GetAll();
    }
}
