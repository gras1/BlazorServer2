namespace BlazorServer2
{
    public class GitHubUser
    {
        public int id { get; set; }

        public string login { get; set; }

        public string avatar_url { get; set; }

        public string name { get; set; }

        public int followers { get; set; }

        public string location { get; set; }

        public string repos_url { get; set; }

        public GitHubRepo[] GitHubRepos { get; set; }

        public string ErrorMessage { get; set; }

        public bool UserFound { get; set; }
    }
}
