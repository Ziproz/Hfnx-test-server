using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace GitHubRepoSearchAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RepositoriesController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RepositoriesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
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
                return StatusCode((int)response.StatusCode, response.ReasonPhrase);
            }

            var content = await response.Content.ReadAsStringAsync();
            var json = JObject.Parse(content);

            return Ok(json["items"]);
        }
    }
}
