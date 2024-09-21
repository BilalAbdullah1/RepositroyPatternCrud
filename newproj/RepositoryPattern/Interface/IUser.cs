using newproj.Models;

namespace newproj.RepositoryPattern.Interface
{
    public interface IUsers
    {
        Task<IEnumerable<Users>> GetUsersAsync();
        Task<int> UserCreate(Users Usr, IFormFile image);
        Task<Users> GetUserById(int id);
        Task<int> UserUpdate(Users usr , IFormFile image);
        Task<Users> GetUserDeleteById(int id);
    }
}
