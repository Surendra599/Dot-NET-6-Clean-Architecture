using Application.Common.Interface.Presistence;
using Domain.Entities;
using Infrastructure.DataBase;


namespace Infrastructure.Presistence
{
    public class UserRepository : IUserRepository
    {

        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //  private static List<User> _users = new();

        public void AddNewUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            //_users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Email == email);
            //  _dbContext.SaveChanges();
            return user;

            //return _users.SingleOrDefault(x => x.Email == email);
        }
    }
}