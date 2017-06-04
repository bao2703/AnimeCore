namespace Entities.Domain
{
    public class Episode : TimestampEntity
    {
        public string Name { get; set; }

        public string Source { get; set; }

        public int MovieId { get; set; }

        public Movie Movie { get; set; }
    }
}