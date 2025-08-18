using System.ComponentModel.DataAnnotations;

namespace TaskManager.API.Dtos
{
    public class UserRegisterDto
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;
    }
}