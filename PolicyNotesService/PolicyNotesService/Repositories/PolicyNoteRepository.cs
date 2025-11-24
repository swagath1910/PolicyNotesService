using Microsoft.EntityFrameworkCore;
using PolicyNotesService.Data;
using PolicyNotesService.Models;

namespace PolicyNotesService.Repositories
{
    public class PolicyNoteRepository : IPolicyNoteRepository
    {
        private readonly PolicyNotesDbContext _context;

        public PolicyNoteRepository(PolicyNotesDbContext context)
        {
            _context = context;
        }

        public async Task<PolicyNote> AddAsync(PolicyNote note)
        {
            _context.PolicyNotes.Add(note);
            await _context.SaveChangesAsync();
            return note;
        }

        public async Task<IEnumerable<PolicyNote>> GetAllAsync()
        {
            return await _context.PolicyNotes.ToListAsync();
        }

        public async Task<PolicyNote?> GetByIdAsync(Guid id)
        {
            return await _context.PolicyNotes.FindAsync(id);
        }
    }
}