using Domain.Entities;

namespace Application.Common.Interface.Authentication
{
    public interface IJwtTokenGenerators
    {
        string GenerateToken(User user);
    }
}