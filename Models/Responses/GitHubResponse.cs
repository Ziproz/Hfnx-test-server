using Newtonsoft.Json;

namespace FnxTest.Models.Responses
{
    //public class GitHubResponse
    //{
    //}
    public class Owner
    {
        public string Login { get; set; }
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }
    }

    public class Repository
    {
        public string Name { get; set; }
        public Owner Owner { get; set; }
    }

    public class GitHubResponse
    {
        public List<Repository> Items { get; set; }
    }
}
