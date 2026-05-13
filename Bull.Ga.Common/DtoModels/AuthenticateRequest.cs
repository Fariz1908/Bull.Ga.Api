using System.ComponentModel.DataAnnotations;

namespace Bull.Ga.Common.DtoModels
{
    public class AuthenticateRequest
    {
        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string AppSource { get; set; } = string.Empty;
    }
}
