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
            _dinoService.Execute(new CreateDinoCommand(dino));
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return View();
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id)
    {
        try
        {
            _dinoService.Execute(new DeleteDinoCommand(id));
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }

    }

    [HttpGet]
    public ActionResult Edit(int id)
    {
        var dino = _dinoService.Execute(new GetAllDinoQuery()).FirstOrDefault(d => d.Id == id);
        if (dino == null)
        {
            return NotFound();
        }
        return View("Update",dino);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Dinosus dino)
    {
        try
        {
            _dinoService.Execute(new UpdateDinoCommand(dino));
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View("Update");
        }
    }
}
