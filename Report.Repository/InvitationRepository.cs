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

        public async Task<DataTable> InvitationReportAsync()
        {
            await Task.Delay(20000);
            DataTable dataTable = new DataTable("InvitationReport");

            using (SqlConnection conn = new SqlConnection(_connString))
            {
                conn.Open();
                string cmdText = "SELECT * FROM Events";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                SqlDataReader dataReader = await cmd.ExecuteReaderAsync();
                dataTable.Load(dataReader);
            }

            return dataTable;
        }
    }
}
