using Backend.Models;

namespace Backend.Repositories;

public interface IUserService
{
    User CreateUser(User user);
    string SignIn(string email, string password);
}