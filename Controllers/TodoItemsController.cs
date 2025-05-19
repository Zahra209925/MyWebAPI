using Microsoft.AspNetCore.Mvc;
using Serilog;

[ApiController]
[Route("api/[controller]")]
public class TodoItemsController : ControllerBase
{
	[HttpGet]
	public IActionResult Get()
	{
		Log.Information("GET request received at /api/todoitems");
		return Ok(new { Message = "TodoItems fetched successfully" });
	}

	[HttpPost]
	public IActionResult Post([FromBody] object todoItem)
	{
		if (todoItem == null)
		{
			Log.Error("POST request failed: TodoItem is null");
			return BadRequest("TodoItem cannot be null");
		}

		Log.Information("POST request received at /api/todoitems");
		return Ok(new { Message = "TodoItem created successfully" });
	}
}
