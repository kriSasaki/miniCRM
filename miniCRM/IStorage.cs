namespace miniCRM
{
    public interface IStorage<T>
    {
        Task SaveAsync(List<T> items);
        List<T> Load();
    }
}
