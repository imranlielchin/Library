using BookProject.Models;

namespace BookProject.Infrastrukturlar
{
    public interface IManager<T>
    {
        void Add(T item);
        void Edit(T item);
        void Remove(T item);
        T GetById(int id);

        T[] FindByName(string name);
        
    }
}
