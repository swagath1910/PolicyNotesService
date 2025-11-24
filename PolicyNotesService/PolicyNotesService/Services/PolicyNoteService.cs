using PolicyNotesService.Models;
using PolicyNotesService.Repositories;

namespace PolicyNotesService.Services
{
    public class PolicyNoteService : IPolicyNoteService
    {
        private readonly IPolicyNoteRepository _repository;
        public PolicyNoteService(IPolicyNoteRepository repository)
        {
            _repository = repository;
        }

        public async Task<PolicyNote> AddNoteAsync(PolicyNote note)
        {
            return await _repository.AddAsync(note);
        }

        public async Task<IEnumerable<PolicyNote>> GetAllNotesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<PolicyNote?> GetNoteByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}