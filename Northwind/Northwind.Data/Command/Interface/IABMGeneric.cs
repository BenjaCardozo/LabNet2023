namespace Northwind.Data.Command.Interface
{
    public interface IABMGeneric<T>
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
