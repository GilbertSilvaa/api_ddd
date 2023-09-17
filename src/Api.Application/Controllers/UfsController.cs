using System.Net;
using Api.Domain.Interfaces.Services.Uf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UfsController : ControllerBase
{
  private readonly IUfService _service;

  public UfsController(IUfService service)
  {
    _service = service;
  }

  [Authorize("Bearer")]
  [HttpGet]
  public async Task<ActionResult> GetAll()
  {
    if (!ModelState.IsValid) return BadRequest(ModelState);

    try
    {
      var response = await _service.GetAll();

      return Ok(response);
    }
    catch (ArgumentException ae)
    {
      return StatusCode((int)HttpStatusCode.InternalServerError, ae.Message);
    }
  }

  [Authorize("Bearer")]
  [HttpGet]
  [Route("{id}")]
  public async Task<ActionResult> Get(Guid id)
  {
    if (!ModelState.IsValid) return BadRequest(ModelState);

    try
    {
      var response = await _service.Get(id);

      return Ok(response);
    }
    catch (ArgumentException ae)
    {
      return StatusCode((int)HttpStatusCode.InternalServerError, ae.Message);
    }
  }
}
