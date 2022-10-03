using WebAPIPhong.Models;

namespace WebAPIPhong.Services.IServices
{
    public interface IJwtUtils
    {
        public string GenerateToken(User user);
        public int? ValidateToken(string token);
    }
}