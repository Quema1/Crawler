﻿namespace Crawler.Logic.Helpers
{
    public class UrlHelper
    {
        public string GetAbsoluteUrl(string baseUrl, string path)
        {
            var baseUri = new Uri(baseUrl);

            var absoluteUrl = new Uri(baseUri, path);

            return absoluteUrl.ToString().TrimEnd('/');
        }
    }
}