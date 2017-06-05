using Newtonsoft.Json;

namespace AutoSyncer
{
    class Parameter
    {
        public string GitPath { get; set; }

        public string BranchName { get; set; }

        public string RemoteBranchName { get; set; }

        public string ActionPath { get; set; }

        [JsonIgnore]
        public string RepositoryName => RemoteBranchName.Remove(RemoteBranchName.IndexOf('/'));
    }
}
