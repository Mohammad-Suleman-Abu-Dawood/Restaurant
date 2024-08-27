namespace Restaurant.Models.Repositories
{
    public interface IRepository<T>
    {
        void Add(T Entity);
        void Update(int Id, T Entity);
        void Delete(int Id, T Entity);
        void Active(int Id);
        List<T> View();
        T Find(int Id);
        List<T> ViewClient();

    }
}
