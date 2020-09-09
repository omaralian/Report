using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Threading;

namespace Report.Repository
{
    public class InvitationRepository : IInvitationRepository
    {
        private readonly string _connString;
        public InvitationRepository(IConfiguration configuration)
        {
            _connString = configuration.GetConnectionString("Default");
        }

        public async Task<DataTable> InvitationReportAsync(List<String> columns)
        {
            await Task.Delay(20000);

            string cmdTextColumns = "";

            if (columns.Contains("EventId"))
            {
                cmdTextColumns += "Events.Id AS EventId, ";
            }

            if (columns.Contains("EventTitle"))
            {
                cmdTextColumns += "Events.Title AS EventTitle, ";
            }

            if (columns.Contains("EventStatus"))
            {
                cmdTextColumns += "Events.Status AS EventStatus, ";
            }

            if (columns.Contains("EventDateTime"))
            {
                cmdTextColumns += "Events.DateTime AS EventDateTime, ";
            }

            if (columns.Contains("IndividualName"))
            {
                cmdTextColumns += "CONCAT(Individuals.FirstName, ' ', Individuals.LastName) AS IndividualName, ";
            }

            cmdTextColumns = cmdTextColumns.Substring(0, cmdTextColumns.Length - 2) + " ";

            string cmdText =
                    "" +
                    "SELECT " +
                    cmdTextColumns +
                    "FROM " +
                    "Invitations " +
                    "LEFT JOIN Events ON Invitations.EventId = Events.Id " +
                    "LEFT JOIN Individuals ON Invitations.IndividualId = Individuals.Id " +
                    "ORDER BY Events.Id ASC " +
                    "";

            DataTable dataTable = new DataTable("InvitationReport");

            using (SqlConnection conn = new SqlConnection(_connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                SqlDataReader dataReader = await cmd.ExecuteReaderAsync();
                dataTable.Load(dataReader);
            }

            return dataTable;
        }
    }
}
