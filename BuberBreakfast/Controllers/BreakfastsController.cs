using BuberBreakfast.Contracts.Breakfast;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers;

[ApiController]
[Route("[controller]")] // framework will automatcall replace the word controller
// with name of class -> Breakfasts
public class BreakfastsController : ControllerBase
{
  [HttpPost()]
  public IActionResult CreateBreakfast(CreateBreakfastRequest request)
  {
    return Ok(request);
  }

  [HttpGet("{id:guid}")]
  public IActionResult GetBreakfast(Guid id)
  {
    return Ok(id);
  }

  [HttpPut("{id:guid}")]
  public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
  {
    return Ok(request);
  }

  [HttpDelete("{id:guid}")]
  public IActionResult DeleteBreakfast(Guid id)
  {
    return Ok(id);
  }
}
