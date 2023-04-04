﻿using Crawler.Logic.Crawlers;
using Crawler.Logic.Helpers;
using Crawler.Logic.Parsers;
using Crawler.Logic.Services;
using Crawler.Logic.Validators;

namespace Crawler.ConsoleOutput
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var consoleHandler = new ConsoleWrapper();
            var validator = new UrlValidator();
            using var httpClient = new HttpClient();
            var httpClientService = new HttpClientService(httpClient);
            var helper = new UrlHelper();
            var responseTimeService = new ResponseTimeService(httpClientService, consoleHandler);
            var htmlParser = new HtmlParser(httpClientService, helper);
            var htmlCrawler = new HtmlCrawler(consoleHandler, htmlParser, validator);
            var xmlCrawler = new XmlCrawler(consoleHandler, helper, validator, httpClientService);
            var crawler = new Crawler.Logic.Crawlers.Crawler(responseTimeService, htmlCrawler, xmlCrawler);
            var console = new ConsoleProcessor(consoleHandler, validator, crawler);

            await console.ExecuteAsync();
        }
    }
}