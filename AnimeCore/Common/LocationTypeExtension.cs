using Entities.Domain;

namespace AnimeCore.Common
{
    public static class BannerTypeExtension
    {
        public static string EnumValue(this BannerType bannerType)
        {
            switch (bannerType)
            {
                case BannerType.HomeChild:
                    return "Home & Child";
            }
            return bannerType.ToString();
        }
    }
}