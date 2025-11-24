using PolicyNotesService.Models;

namespace PolicyNotesService.Services
{
    public interface IPolicyNoteService
    {
        Task<PolicyNote> AddNoteAsync(PolicyNote note);
        Task<IEnumerable<PolicyNote>> GetAllNotesAsync();
        Task<PolicyNote?> GetNoteByIdAsync(Guid id);
    }
}