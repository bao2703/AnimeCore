﻿namespace Entities.Domain
{
    public class VideoAds : Advertisement
    {
        public string Video { get; set; }

        public VideoAdsLocation VideoAdsLocation { get; set; }
    }
}