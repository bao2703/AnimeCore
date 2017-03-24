namespace Entities.Domain
{
    public class Episode : TrackAbleEntity
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public Movie Movie { get; set; }
    }
}