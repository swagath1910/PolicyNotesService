using PolicyNotesService.Models;

namespace PolicyNotesService.Repositories
{
    public interface IPolicyNoteRepository
    {
        Task<PolicyNote> AddAsync(PolicyNote note);
        Task<IEnumerable<PolicyNote>> GetAllAsync();
        Task<PolicyNote?> GetByIdAsync(Guid id);
    }
}