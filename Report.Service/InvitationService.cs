using Report.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Report.Service
{
    public class InvitationService : IInvitationService
    {
        private readonly IInvitationRepository _invitationRepository;
        private readonly IReportRepository _reportRepository;
        public InvitationService(IInvitationRepository invitationRepository, IReportRepository reportRepository)
        {
            _invitationRepository = invitationRepository;
            _reportRepository = reportRepository;
        }

        public async Task<string> InvitationReport(List<String> columns)
        {
            string filename = string.Format(@"{0}", Guid.NewGuid().ToString());

            bool IsInserted = await _reportRepository.Insert(filename, "html", "InProgress");
            if (IsInserted)
                Console.WriteLine("IsInserted: " + IsInserted);

            Task<DataTable> createReportTask = Task<DataTable>.Run(() =>
                _invitationRepository.InvitationReportAsync(columns)
            );

            var createReportAwaiter =  createReportTask.GetAwaiter();

            createReportAwaiter.OnCompleted(() => {
                DataTable dataTable = createReportAwaiter.GetResult();
                string htmlString = DataTableToHTML(dataTable);
                CreateHtmlFile(htmlString, filename);
                _reportRepository.UpdateStatus(filename, "Ready");
            });
            
            return filename;
        }

        private string DataTableToHTML(DataTable dt)
        {
            StringBuilder strHTMLBuilder = new StringBuilder();
            strHTMLBuilder.Append("<html >");
            strHTMLBuilder.Append("<head>");
            strHTMLBuilder.Append("<link rel='stylesheet' href='/lib/bootstrap/dist/css/bootstrap.min.css'/>");
            strHTMLBuilder.Append("<link rel='stylesheet' href='/css/report.css'/>");
            strHTMLBuilder.Append("</head>");
            strHTMLBuilder.Append("<body>");

            strHTMLBuilder.Append("<div class='noprint p-4'>");
            strHTMLBuilder.Append("<button class='btn btn-success' id='exportToCsv'>CSV</button>");
            strHTMLBuilder.Append("</div>");

            strHTMLBuilder.Append("<table width='100%' class='table table-bordered'");

            strHTMLBuilder.Append("<tr >");
            foreach (DataColumn myColumn in dt.Columns)
            {
                strHTMLBuilder.Append("<td >");
                strHTMLBuilder.Append(myColumn.ColumnName);
                strHTMLBuilder.Append("</td>");

            }
            strHTMLBuilder.Append("</tr>");


            foreach (DataRow myRow in dt.Rows)
            {

                strHTMLBuilder.Append("<tr >");
                foreach (DataColumn myColumn in dt.Columns)
                {
                    strHTMLBuilder.Append("<td >");
                    strHTMLBuilder.Append(myRow[myColumn.ColumnName].ToString());
                    strHTMLBuilder.Append("</td>");

                }
                strHTMLBuilder.Append("</tr>");
            }

            // Close tags.  
            strHTMLBuilder.Append("</table>");
            // JQuery
            strHTMLBuilder.Append("<script src='/lib/jquery/dist/jquery.min.js'></script>");
            strHTMLBuilder.Append("<script src='/lib/table2csv/table2csv.min.js'></script>");
            strHTMLBuilder.Append("<script src='/lib/table2csv/function.js'></script>");

            strHTMLBuilder.Append("</body>");
            strHTMLBuilder.Append("</html>");

            string Htmltext = strHTMLBuilder.ToString();

            return Htmltext;
        }

        private void CreateHtmlFile(string content, string filename)
        {
            string filePath = @"ReportStaticFiles/"+ filename + ".html";

            // Check if file already exists. If yes, delete it.     
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            // Create a new file     
            using (FileStream fs = File.Create(filePath))
            {
                // Add some text to file    
                Byte[] title = new UTF8Encoding(true).GetBytes(content);
                fs.Write(title, 0, title.Length);
            }
        }
    }
}
