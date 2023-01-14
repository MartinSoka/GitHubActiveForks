namespace GitHubForks.Data
{
    public class Fork
    {
        public string url { get; set; }
        public long id { get; set; }
        public Owner owner { get; set; }
        public string name { get; set; }
        public DateTime pushed_at { get; set; }
        public int stargazers_count { get; set; }
        public int open_issues_count { get; set; }
    }

    public class Owner
    {
        public string avatar_url { get; set; }
        public int id { get; set; }
    }
}
