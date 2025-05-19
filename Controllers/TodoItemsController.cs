using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TodoItemsController : ControllerBase
	{
		private static List<TodoItem> _todoItems = new List<TodoItem>
		{
			new TodoItem { Id = 1, Name = "Learn .NET", IsComplete = false },
			new TodoItem { Id = 2, Name = "Build API", IsComplete = false }
		};

		[HttpGet]
		public ActionResult<IEnumerable<TodoItem>> GetTodoItems()
		{
			return _todoItems;
		}

		[HttpGet("{id}")]
		public ActionResult<TodoItem> GetTodoItem(long id)
		{
			var todoItem = _todoItems.FirstOrDefault(t => t.Id == id);

			if (todoItem == null)
			{
				return NotFound();
			}

			return todoItem;
		}
	}
}
