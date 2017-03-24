namespace AnimeCore.Common
{
    public class Authentication
    {
        public Facebook Facebook { get; set; }
    }

    public class Facebook
    {
        public string AppId { get; set; }

        public string AppSecret { get; set; }
    }
}