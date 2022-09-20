using asp_ht4.Models;

namespace asp_ht4.Services
{
    public class Provider : Interfaces.IProvider
    {
        public readonly List<Flora> _flora;

        public Provider()
        {
            _flora = new List<Flora>()
            {
                new Flora { Id=1, Name="1", Price=1},
                new Flora { Id=2, Name="2", Price=2},
                new Flora { Id=3, Name="3", Price=3}

            };
        }
        public void Create(Flora flora)
        {
            _flora.Add(flora);
        }

        public void Delete(int id)
        {
            int item = _flora.FindIndex(x => x.Id == id);
            _flora.RemoveAt(item);
        }

        public Flora Read(int id)
        {
            return _flora.FirstOrDefault(x => x.Id == id);

        }

        public void Update(Flora flora)
        {
            int item = _flora.FindIndex(x => x.Id == flora.Id);
            _flora[item] = flora;
        }
    }
}
