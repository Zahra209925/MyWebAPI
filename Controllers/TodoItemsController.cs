using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MyWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TodoItemsController : ControllerBase
	{
		private readonly TodoContext _context;

		public TodoItemsController(TodoContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
		{
			return await _context.TodoItems.ToListAsync();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
		{
			var todoItem = await _context.TodoItems.FindAsync(id);

			if (todoItem == null)
			{
				return NotFound();
			}

			return todoItem;
		}

		[HttpPost]
		public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
		{
			_context.TodoItems.Add(todoItem);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
		}
	}
}
