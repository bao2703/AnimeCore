namespace AnimeCore.Common
{
    public class AppSettings
    {
        public int PageSize { get; set; }

        public string Slide { get; set; }

        public PriceMultiple PriceMultiple { get; set; }
    }

    public class PriceMultiple
    {
        public double Home { get; set; }

        public double Child { get; set; }
    }
}