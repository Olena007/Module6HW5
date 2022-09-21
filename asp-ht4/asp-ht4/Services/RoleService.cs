using asp_ht4.Models;

namespace asp_ht4.Services
{
    public class RoleService
    {
        private readonly List<Role> _role;

        public RoleService()
        {
            _role = new List<Role>();

            _role.Add(new Role { Id=1, Name="user"});
            _role.Add(new Role { Id = 2, Name = "admin" });
        }

        public IEnumerable<Role> GetAll()
        {
            return _role;
        }
    }
}
