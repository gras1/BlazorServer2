using System.Net.Http;

namespace BlazorServer2.Data
{
    public class GitHubHttpRequestMessageCreator : IGitHubHttpRequestMessageCreator
    {
        public HttpRequestMessage Create(string pathToGitHub)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, pathToGitHub);
            httpRequestMessage.Headers.Add("Accept", "application/vnd.github.v3+json");
            httpRequestMessage.Headers.Add("User-Agent", "UserViewer");
            return httpRequestMessage;
        }
    }
}
