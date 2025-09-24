namespace Dino.Common.Repositories;


public interface IDinoRepository<TDino> where TDino : class
{
    TDino? Get(int id);
    IEnumerable<TDino> Get();
    TDino Create(TDino entity);
    TDino Update(TDino entity);
    void Delete(int id);
}
