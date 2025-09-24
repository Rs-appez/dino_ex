using Dino.Common.Repositories;
using Dino.BLL.Mappers;
using Entities = Dino.BLL.Entities;

namespace Dino.BLL.Services;

public class DinoService : IDinoRepository<Entities.Dino>
{
    private readonly IDinoRepository<DAL.Entities.Dino> _dinoService;

    public DinoService(IDinoRepository<DAL.Entities.Dino> dinoService)
    {
        _dinoService = dinoService;
    }

    public Entities.Dino? Get(int id)
    {
        return _dinoService.Get(id)?.ToBll();
    }

    public IEnumerable<Entities.Dino> Get()
    {
        return _dinoService.Get().Select(d => d.ToBll());
    }

    public Entities.Dino Create(Entities.Dino dino)
    {
        return _dinoService.Create(dino.ToDal()).ToBll();
    }

    public Entities.Dino Update(Entities.Dino dino)
    {
        return _dinoService.Update(dino.ToDal()).ToBll();
    }

    public void Delete(int id)
    {
        _dinoService.Delete(id);
    }
}
