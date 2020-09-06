using Microsoft.EntityFrameworkCore;
using Report.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Repository
{
    public class InvitationRepository : IInvitationRepository
    {
        private ApplicationDbContext _context;
        public InvitationRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<List<Invitation>> GetAllAsync()
        {
            return await _context.Invitation.ToListAsync();
        }

        
        /*
        public async Task<List<Invitation>> Test()
        {
            var anonymousObjResult = _context.Invitation.Select(c => new { c.EventId, c.IndividualId });
            anonymousObjResult.AllAsync();
            foreach (var obj in anonymousObjResult)
            {
                Console.Write(obj.EventId);
            }
        }
        */
        

        public async Task<List<Invitation>> ReportAsync()
        {
            string sql = @"SELECT [EventId], [IndividualId] FROM [Invitation]";
            var result = await _context.Invitation.FromSqlRaw(sql).ToListAsync();
            return result;
        }
    }
}
