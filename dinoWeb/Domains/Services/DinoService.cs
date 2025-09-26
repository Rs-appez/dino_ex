using Dino.Web.Domain.Commands;
using Dino.Web.Domain.Entities;
using Dino.Web.Domain.Queries;
using Dino.Web.Domain.Repositories;

namespace Dino.Web.Domain.Services;
public class DinoService : IDinoRepository
{

    private string _apiUrl = "http://localhost:5192/api/dino/";

    public bool Execute(CreateDinoCommand command)
    {
        using (HttpClient client = new HttpClient())
        {
            var response = client.PostAsJsonAsync(_apiUrl, command).Result;
            return response.IsSuccessStatusCode;
        }
    }

    public bool Execute(DeleteDinoCommand command)
    {

        using (HttpClient client = new HttpClient())
        {
            var response = client.DeleteAsync(_apiUrl + command.Id).Result;
            Console.WriteLine("command : " + command.Id);

            return response.IsSuccessStatusCode;
        }
    }

    public bool Execute(UpdateDinoCommand command)
    {
        using (HttpClient client = new HttpClient())
        {
            var response = client.PutAsJsonAsync(_apiUrl, command).Result;
            return response.IsSuccessStatusCode;
        }
    }

    public IEnumerable<Dinosus> Execute(GetAllDinoQuery query)
    {
        using (HttpClient client = new HttpClient())
        {
            IEnumerable<Dinosus>? dinos = client.GetFromJsonAsync<IEnumerable<Dinosus>>(_apiUrl).Result;
            return dinos ?? Enumerable.Empty<Dinosus>();
        }
    }

    public Dinosus? Execute(GetDinoByIdQuery query)
    {
        using (HttpClient client = new HttpClient())
        {
            Dinosus? dino = client.GetFromJsonAsync<Dinosus>(_apiUrl + query.Id).Result;
            return dino;
        }
    }
}
