namespace Entities.Domain
{
    public class Episode : TimestampEntity
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public Movie Movie { get; set; }
    }
}