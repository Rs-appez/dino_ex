using Dino.Cqs.Queries;
using Dino.Web.Domain.Entities;

namespace Dino.Web.Domain.Queries;
public class GetDinoByIdQuery : IQueryDefinition<Dinosus>
{
    public int Id { get; }

    public GetDinoByIdQuery(int id)
    {
        Id = id;
    }

}
