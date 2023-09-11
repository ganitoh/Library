namespace Library.Persistance.Intarfaces
{
    internal interface IRepository<TEnity> where TEnity : class
    {
        bool Add(TEnity entity);
        TEnity? Get(int id);
        IEnumerable<TEnity>? GetAll();
        bool Update(TEnity entity);
        bool Delete(TEnity entity);
    }
}
