using Newtonsoft.Json;
using System.Net.Http.Headers;


namespace GitHubForks.Data
{
    public class GitHubService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GitHubService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<Fork>> GetForksAsync(string url)
        {
            var client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("gitHubForks", "1.0"));
            var response = await client.GetAsync(url).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"The response from the server was not successfull, reason: {response.ReasonPhrase}");
            }
            var json = await response.Content.ReadAsStringAsync();
            var forks = JsonConvert.DeserializeObject<List<Fork>>(json);

            return forks;

        }
    }
}

