using System.Net.Http;

namespace BlazorServer2.Data
{
    public interface IGitHubHttpRequestMessageCreator
    {
        HttpRequestMessage Create(string pathToGitHub);
    }
}