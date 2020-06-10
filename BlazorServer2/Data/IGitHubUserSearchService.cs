using System.Threading.Tasks;

namespace BlazorServer2.Data
{
    public interface IGitHubUserSearchService
    {
        Task<GitHubUser> GetGitHubUser(string username);
    }
}