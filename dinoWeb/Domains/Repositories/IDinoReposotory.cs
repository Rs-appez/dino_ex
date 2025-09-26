using Dino.Web.Domain.Entities;
using Dino.Web.Domain.Commands;
using Dino.Web.Domain.Queries;
using Dino.Cqs.Commands;
using Dino.Cqs.Queries;

namespace Dino.Web.Domain.Repositories;
public interface IDinoRepository :
                ICommandHandler<CreateDinoCommand>,
                ICommandHandler<DeleteDinoCommand>,
                ICommandHandler<UpdateDinoCommand>,
                IQueryHandler<GetAllDinoQuery, IEnumerable<Dinosus>>,
                IQueryHandler<GetDinoByIdQuery, Dinosus>
{
}
