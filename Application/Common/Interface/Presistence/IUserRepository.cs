using Domain.Entities;

namespace Application.Common.Interface.Presistence
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);

        void AddNewUser(User user);
    }
}