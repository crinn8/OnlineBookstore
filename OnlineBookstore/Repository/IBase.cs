namespace OnlineBookstore.Repository
{
    public interface IBase<T>
    {
        public Task<T?> Get(int? id);

        public Task<List<T>> GetAll();

        public Task<bool> Add(T objectToAdd);

        public Task<bool> Update(T objectToUpdate, int id);

        public Task<bool> Delete(int? id);

        public Task<bool> Exists(int id);
    }
}
