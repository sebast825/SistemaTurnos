namespace SistemaTurnos.Dal.Repository.Interface
{
    public interface IRepository<T> where T : class
    {


        Task<List<T>> GetAll();
        Task<T> GetId(int id);
        Task Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        int GetIdMedicosActivos();
    }
}
