namespace LexiconLMS.Core.Entities
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ActivityType Type { get; set; } = ActivityType.Lecture;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;

        // Computed property
        public string SearchableString => $"{Name} {Description} {StartDate:yyyy-MM-dd} {EndDate:yyyy-MM-dd}";

        // Navigation properties
        public int ModuleId { get; set; }
        public Module Module { get; set; } = new Module();
        public ICollection<Document> Documents { get; set; } = new List<Document>();
    }
}