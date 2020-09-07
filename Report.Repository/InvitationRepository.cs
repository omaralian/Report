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
            return await _context.Invitations.ToListAsync();
        }

        
        public async Task<IEnumerable<dynamic>> ReportAsync2()
        {
            IQueryable<dynamic> query = _context.Invitations
                .Include(i => i.Event)
                .Select(i => new
                {
                    EventId = i.EventId,
                    IndividualId = i.IndividualId,
                    EventTitle = i.Event.Title
                });

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<dynamic>> ReportAsync()
        {
            string sql =
                "SELECT " +
                "Invitations.EventId, " +
                "Invitations.IndividualId, " +
                "Events.Title, " +
                "Events.DateTime, " +
                "Events.Status, " +
                "Individuals.LastName " +
                "FROM Invitations " +
                "LEFT JOIN Events ON Invitations.EventId = Events.Id " +
                "LEFT JOIN Individuals ON Invitations.IndividualId = Individuals.Id " +
                "";

            IQueryable<dynamic> query = _context.Invitations.FromSqlRaw(sql).Select(i => new { i.Event, i.Individual });

            return await query.ToListAsync();
        }

        /*
        public async Task<List<Invitation>> ReportAsync()
        {
            string sql =
                "SELECT " +
                "Invitations.EventId, " +
                "Invitations.IndividualId, " +
                "Events.Title, " +
                "Events.DateTime, " +
                "Events.Status, " +
                "Individuals.FirstName, " +
                "Individuals.LastName " +
                "FROM Invitations " +
                "LEFT JOIN Events ON Invitations.EventId = Events.Id " +
                "LEFT JOIN Individuals ON Invitations.IndividualId = Individuals.Id " +
                "";
            
            var result = await _context.Invitations.FromSqlRaw(sql).ToListAsync();
            return result;
        }
        */
    }
}
