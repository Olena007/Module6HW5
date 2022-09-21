using asp_ht4.Models;

namespace asp_ht4.Services
{
    public class UserService
    {
        private readonly List<User> _user;

        public UserService(RoleService roleService)
        {
            Role role = roleService.GetAll().FirstOrDefault(r => r.Name == "user");
            _user = new List<User>();
            _user.Add(new User
            {
                Id=1,
                Email="lohvinova@gmail.com",
                Password="1",
                Role= role,
                RoleId=role.Id
            });
        }

        public void Create(User user)
        {
            _user.Add(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _user;
        }
    }
}
