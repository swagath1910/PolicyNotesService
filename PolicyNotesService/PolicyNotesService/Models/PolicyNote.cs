namespace PolicyNotesService.Models
{
    public class PolicyNote
    {
        public Guid  Id { get; set; }
        public string PolicyNumber { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
    }
}
