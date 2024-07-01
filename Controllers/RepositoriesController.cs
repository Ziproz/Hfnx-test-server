using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using FnxTest.Models.Responses;
using Microsoft.AspNetCore.Authorization;

namespace FnxTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RepositoriesController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<RepositoriesController> _logger;

        public RepositoriesController(IHttpClientFactory httpClientFactory, ILogger<RepositoriesController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchRepositories(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return BadRequest("Query is required");
            }

            var httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; AcmeInc/1.0)");

            var response = await httpClient.GetAsync($"https://api.github.com/search/repositories?q={query}");

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Failed to fetch data from GitHub API: {ReasonPhrase}", response.ReasonPhrase);
                return StatusCode((int)response.StatusCode, response.ReasonPhrase);
            }

            var content = await response.Content.ReadAsStringAsync();
            _logger.LogInformation("GitHub API response: {Content}", content);

            var gitHubResponse = JsonConvert.DeserializeObject<GitHubResponse>(content);
            if (gitHubResponse?.Items == null)
            {
                _logger.LogError("Unexpected response format");
                return StatusCode(500, "Unexpected response format");
            }

            return Ok(gitHubResponse.Items);
        }
    }
}


