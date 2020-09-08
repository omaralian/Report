using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Report.Model;

namespace Report.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly string _connString;
        public ReportRepository(IConfiguration configuration)
        {
            _connString = configuration.GetConnectionString("Default");
        }

        public IEnumerable<ReportModel> GetAll()
        {
            List<ReportModel> reportModelList = new List<ReportModel>();

            using (SqlConnection conn = new SqlConnection(_connString))
            {
                conn.Open();
                string cmdText = "SELECT * FROM Reports ORDER BY CreatedAt DESC";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    ReportModel reportModel = new ReportModel();

                    reportModel.Name = dataReader["Name"].ToString();
                    reportModel.Type = dataReader["Type"].ToString();
                    reportModel.CreatedAt = dataReader["CreatedAt"].ToString();
                    reportModel.Status = dataReader["Status"].ToString();

                    reportModelList.Add(reportModel);
                }
            }

            return reportModelList;
        }

        public async Task<bool> Insert(string Name, string Type, string Status)
        {
            int effectedRows = 0;
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string cmdText = "INSERT INTO Reports(Name, Type, Status, CreatedAt) VALUES(@Name, @Type, @Status, @CreatedAt)";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Type", Type);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                effectedRows = await cmd.ExecuteNonQueryAsync();
            }

            return (effectedRows > 0);
        }

        public async Task<bool> UpdateStatus(string Name, string Status)
        {
            int effectedRows = 0;
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string cmdText = "UPDATE Reports SET Status = @Status WHERE Name = @Name";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Status", Status);
                effectedRows = await cmd.ExecuteNonQueryAsync();
            }

            return (effectedRows > 0);
        }
    }
}
