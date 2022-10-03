using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIPhong.Dtos.UserDtos;
using WebAPIPhong.Models;

namespace WebAPIPhong.Services.IServices
{
    public interface IUserService
    {
        Task<AuthenticationResponse> Authenticate(AuthenticationRequest model);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task Register(RegisterRequest model);
        Task Update(int id, UpdateRequest model);
        Task Delete(int id);
    }
}