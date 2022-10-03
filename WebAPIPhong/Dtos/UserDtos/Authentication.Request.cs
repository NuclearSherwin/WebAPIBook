using System.ComponentModel.DataAnnotations;

namespace WebAPIPhong.Dtos.UserDtos
{
    public class AuthenticationRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}