using Microsoft.Extensions.Configuration;

namespace Dino.DAL.Services;

public abstract class BaseService
{

    protected readonly string _connectionString;

    public BaseService(IConfiguration configuration, string connectionStringName)
    {
        _connectionString = configuration.GetConnectionString(connectionStringName);
    }


}
