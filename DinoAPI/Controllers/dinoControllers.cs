using Dino.Common.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BEntities = Dino.BLL.Entities;
using AEntities = Dino.API.Entities;
using Dino.API.Mappers;

namespace DinoAPI.Controllers;

[Route("api/dino")]
[ApiController]
public class dinoControllers : ControllerBase
{
    private readonly IDinoRepository<BEntities.Dino> _dinoService;

    public dinoControllers(IDinoRepository<BEntities.Dino> dinoService)
    {
        _dinoService = dinoService;
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        BEntities.Dino? dino = _dinoService.Get(id);
        if (dino == null)
        {
            return NotFound();
        }
        return Ok(dino);

    }

    [HttpGet]
    public IActionResult GetAll()
    {
        IEnumerable<BEntities.Dino> dinos = _dinoService.Get();
        return Ok(dinos);
    }

    [HttpPost]
    public IActionResult Create(AEntities.Dino dino)
    {
        if (dino == null)
        {
            return BadRequest();
        }
        BEntities.Dino createdDino = _dinoService.Create(dino.ToBLL());
        return Ok(createdDino);
    }

    [HttpPut]
    public IActionResult Update( AEntities.DinoToUpdate dino)
    {
        if (dino == null) return BadRequest();

        BEntities.Dino? oldDino = _dinoService.Get(dino.Id);
        if (oldDino == null) return NotFound();

        BEntities.Dino updatedDino = _dinoService.Update(oldDino.UpdateBLL(dino));

        return Ok(updatedDino);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _dinoService.Delete(id);
        return NoContent();
    }
}
