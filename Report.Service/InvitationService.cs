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

        public async Task<string> InvitationReport(string type)
        {
            string filename = string.Format(@"{0}", Guid.NewGuid().ToString());

            bool IsInserted = await _reportRepository.Insert(filename, type, "InProgress");
            if (IsInserted)
                Console.WriteLine("IsInserted: " + IsInserted);

            Task<DataTable> createReportTask = Task<DataTable>.Run(() =>
                _invitationRepository.InvitationReportAsync()
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
            strHTMLBuilder.Append("</head>");
            strHTMLBuilder.Append("<body>");
            strHTMLBuilder.Append("<table border='1px' cellpadding='1' cellspacing='1' bgcolor='lightyellow' style='font-family:Garamond; font-size:smaller'>");

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

            //Close tags.  
            strHTMLBuilder.Append("</table>");
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
