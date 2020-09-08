using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Service
{
    public interface IReportService
    {
        public IEnumerable<Model.ReportModel> GetAll();
    }
}
