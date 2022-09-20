namespace asp_ht4.Models
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<User> User { get; set; }

        public Role()
        {
            User = new List<User>();
        }
    }
}
