using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorServer2.Data
{
    public class GitHubUserSearchService : IGitHubUserSearchService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IGitHubHttpRequestMessageCreator _gitHubHttpRequestMessageCreator;

        public GitHubUserSearchService(IHttpClientFactory clientFactory,
            IGitHubHttpRequestMessageCreator gitHubHttpRequestMessageCreator)
        {
            _clientFactory = clientFactory;
            _gitHubHttpRequestMessageCreator = gitHubHttpRequestMessageCreator;
        }

        public async Task<GitHubUser> GetGitHubUser(string username)
        {
            GitHubUser gitHubUser = null;

            var gitHubUserRequest = _gitHubHttpRequestMessageCreator.Create($"https://api.github.com/users/{username}");

            var httpClient = _clientFactory.CreateClient();
            var gitHubUserResponse = await httpClient.SendAsync(gitHubUserRequest);

            if (gitHubUserResponse.IsSuccessStatusCode)
            {
                using var gitHubUserResponseStream = await gitHubUserResponse.Content.ReadAsStreamAsync();
                gitHubUser = await JsonSerializer.DeserializeAsync<GitHubUser>(gitHubUserResponseStream);
                gitHubUser.UserFound = true;

                var gitHubReposRequest = _gitHubHttpRequestMessageCreator.Create(gitHubUser.repos_url);

                var gitHubReposResponse = await httpClient.SendAsync(gitHubReposRequest);

                if (gitHubReposResponse.IsSuccessStatusCode)
                {
                    using var GitHubReposResponseStream = await gitHubReposResponse.Content.ReadAsStreamAsync();
                    gitHubUser.GitHubRepos = await JsonSerializer.DeserializeAsync<GitHubRepo[]>(GitHubReposResponseStream);
                }
            }
            else if (gitHubUserResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                gitHubUser = new GitHubUser { UserFound = false };
            }
            else
            {
                gitHubUser = new GitHubUser
                {
                    UserFound = false,
                    ErrorMessage = "An error occured"
                };
            }

            return gitHubUser;
        }
    }
}
