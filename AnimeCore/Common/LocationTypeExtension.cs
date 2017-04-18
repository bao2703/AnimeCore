using Entities.Domain;

namespace AnimeCore.Common
{
    public static class LocationTypeExtension
    {
        public static string EnumValue(this LocationType locationType)
        {
            switch (locationType)
            {
                case LocationType.HomeChild:
                    return "Home & Child";
            }
            return locationType.ToString();
        }
    }
}