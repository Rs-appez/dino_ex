using Dino.Web.Domain.Commands;
using Dino.Web.Domain.Entities;
using Dino.Web.Domain.Queries;
using Dino.Web.Domain.Repositories;

namespace Dino.Web.Domain.Services;
public class DinoService : IDinoRepository
{

    private static List<Dinosus> _dinos = new List<Dinosus>();
    private int _nextId = 1;

    public bool Execute(CreateDinoCommand command)
    {
        _dinos.Add(new Dinosus
        (
             _nextId++,
            command.Espece,
            command.Poids,
            command.Taille
        ));
        return true;
    }

    public bool Execute(DeleteDinoCommand command)
    {
        var dino = _dinos.FirstOrDefault(d => d.Id == command.Id);
        if (dino != null)
        {
            _dinos.Remove(dino);
            return true;
        }
        return false;
    }

    public bool Execute(UpdateDinoCommand command)
    {
        var dino = _dinos.FirstOrDefault(d => d.Id == command.Id);
        if (dino != null)
        {
            dino.Poids = command.Poids;
            dino.Taille = command.Taille;
            return true;
        }
        return false;
    }

    public IEnumerable<Dinosus> Execute(GetAllDinoQuery query)
    {
        return _dinos;
    }

    public Dinosus? Execute(GetDinoByIdQuery query)
    {
        return _dinos.FirstOrDefault(d => d.Id == query.Id);
    }
}
