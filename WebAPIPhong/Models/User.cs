using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WebAPIPhong.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
    }
}