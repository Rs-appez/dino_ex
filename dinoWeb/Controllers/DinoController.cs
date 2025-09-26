using Dino.Web.Domain.Commands;
using Dino.Web.Domain.Entities;
using Dino.Web.Domain.Queries;
using Dino.Web.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Dino.Web.Controllers;
public class DinoController : Controller
{
    private readonly IDinoRepository _dinoService;
    public DinoController(IDinoRepository dinoService)
    {
        _dinoService = dinoService;
    }
    // GET: DinoControllers
    public ActionResult Index()
    {
        List<Dinosus> dinos = _dinoService.Execute(new GetAllDinoQuery()).ToList();
        return View(dinos);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Dinosus dino)
    {
        try
        {
            Console.WriteLine("Creating dino: " + dino.Espece + ", " + dino.Poids + ", " + dino.Taille);
            _dinoService.Execute(new CreateDinoCommand(dino.Espece, dino.Poids, dino.Taille));
            return RedirectToAction(nameof(Index));
        }
        catch ( Exception ex)
        {
            Console.WriteLine(ex.Message);
            return View();
        }
    }

}
