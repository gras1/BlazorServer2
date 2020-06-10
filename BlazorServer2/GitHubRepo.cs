namespace BlazorServer2
{
    public class GitHubRepo
    {
        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public int stargazers_count { get; set; }

        public int watchers_count { get; set; }

        public string html_url { get; set; }
    }
}
