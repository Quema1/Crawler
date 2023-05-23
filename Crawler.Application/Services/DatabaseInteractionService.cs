﻿using Crawler.Domain.Entities;
using Crawler.Application.Interfaces;

namespace Crawler.Application.Services
{
    public class DatabaseInteractionService
    {
        private readonly IFoundUrlRepository _foundUrlRepository;
        private readonly IInitialUrlRepository _initialUrlRepository;
        private readonly Application.Crawlers.Crawler _crawler;

        public DatabaseInteractionService(
            IFoundUrlRepository foundUrlRepository,
            IInitialUrlRepository initialUrlRepository,
            Application.Crawlers.Crawler crawler)
        {
            _foundUrlRepository = foundUrlRepository;
            _initialUrlRepository = initialUrlRepository;
            _crawler = crawler;
        }

        public async Task<int> AddUrlsAsync(string baseUrl)
        {
            baseUrl = baseUrl.TrimEnd('/');

            var result = await _crawler.StartCrawlerAsync(baseUrl);

            var initialUrl = await _initialUrlRepository.AddInitialUrlAsync(baseUrl);

            return await _foundUrlRepository.AddFoundUrlsAsync(initialUrl, result);
        }

        public async Task<IEnumerable<InitialUrl>> GetInitialUrlsAsync()
        {
            return await _initialUrlRepository.GetInitialUrlsAsync();
        }

        public async Task<IEnumerable<FoundUrl>> GetUrlsByInitialUrlIdAsync(int id)
        {
            return await _foundUrlRepository.GetUrlsByInitialUrlIdAsync(id);
        }
    }
}