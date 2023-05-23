﻿
namespace Crawler.Domain.ViewModels
{
    public class ResultViewModel
    {
        public IEnumerable<FoundUrlViewModel> FoundUrls { get; set; }
        public IEnumerable<string> UrlsFromHtml { get; set; }
        public IEnumerable<string> UrlsFromXml { get; set; }
    }
}
