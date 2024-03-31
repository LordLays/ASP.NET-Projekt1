namespace WebApplication1.Repository
{
    public interface ITravelAgencyRepository<T> where T : class
    {
        void AddItem(T item);
        void DeleteItem(int id);
        T GetById(int id);
        IQueryable<T> GetQueryable();
        void UpdateItem(T item);
    }
}
