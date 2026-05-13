namespace Bull.Ga.Common.AppModels
{
    public class AppSettings
    {
        public string Secret { get; set; } = string.Empty;
        public bool SkipAuthorization { get; set; } = false;
        public string SourceFilePath { get; set; } = string.Empty;
        public List<string> AllowedIps { get; set; } = [];
        public List<string> AllowedSubnets { get; set; } = [];
    }
}
