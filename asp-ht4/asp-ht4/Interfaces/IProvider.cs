using asp_ht4.Models;

namespace asp_ht4.Interfaces
{
    public interface IProvider
    {
        void Create(Flora flora);

        Flora Read(int id);

        void Update(Flora flora);

        void Delete(int id);
    }
}
