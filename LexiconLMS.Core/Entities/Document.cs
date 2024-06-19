namespace LexiconLMS.Core.Entities
{
    public class Document : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}
