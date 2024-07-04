using Newtonsoft.Json;
using System.Net.Http;

namespace FnxTest.Services
{
    public class RepositoriesService : IRepositoriesService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;
        private readonly HttpClient _client;
        private readonly ILogger<RepositoriesService> _logger;

        public RepositoriesService(IConfiguration config, IHttpClientFactory httpClientFactory, ILogger<RepositoriesService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("User-Agent", "request");
           _logger = logger;
        }

        public async Task<List<Repository>> GetRepositories(string query)
        {
            var httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; AcmeInc/1.0)");
            var apiUrl = _config["GitHub:ApiUrl"];

            var response = await httpClient.GetAsync($"{apiUrl}/search/repositories?q={query}");
            var content = await response.Content.ReadAsStringAsync();
            _logger.LogInformation("GitHub API response: {Content}", content);

            var gitHubResponse = JsonConvert.DeserializeObject<GitHubResponse>(content);
            if (gitHubResponse?.Items == null)
            {
                _logger.LogError("Unexpected response format");
            }
            return gitHubResponse.Items; 
        }
    }
}
