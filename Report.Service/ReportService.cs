using Report.Model;
using Report.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Service
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public IEnumerable<ReportModel> GetAll()
        {
            return _reportRepository.GetAll();
        }
    }
}
