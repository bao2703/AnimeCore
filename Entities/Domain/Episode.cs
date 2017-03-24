namespace Entities.Domain
{
    public class Episode : TrackAbleEntity
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public virtual Movie Movie { get; set; }
    }
}