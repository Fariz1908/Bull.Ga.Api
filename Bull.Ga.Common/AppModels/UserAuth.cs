using System.Text.Json.Serialization;

namespace Bull.Ga.Common.AppModels
{
    public class UserAuth
    {
        public string UserId { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string AppSource { get; set; } = string.Empty;
        public bool IsPermitToLogin { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; } = string.Empty;
    }
}
