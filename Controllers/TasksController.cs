using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_API.Model;

namespace Task_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private static readonly List<TodoItem> _todoItems = [];


        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> Get()
        {
            return Ok(_todoItems);
        }

        [HttpGet("{id}")]
        public ActionResult<TodoItem> Get(int id)
        {
            var todoItem = _todoItems.FirstOrDefault(x => x.ID == id);
            if (todoItem == null)
            {
                return NotFound();
            }
            return Ok(todoItem);
        }

        [HttpPost]
        public ActionResult Post([FromBody] TodoItem item)
        {
            _todoItems.Add(item);
            return CreatedAtAction(nameof(Get), new { id = item.ID }, item);

        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TodoItem item)
        {

            if (id != item.ID)
            {
                return BadRequest();
            }

            var todoItemToUpdate = _todoItems.FirstOrDefault(x => x.ID == id);
            if (todoItemToUpdate == null)
            {
                return NotFound();
            }

            todoItemToUpdate.Title = item.Title;
            todoItemToUpdate.Description = item.Description;
            todoItemToUpdate.IsCompleted = item.IsCompleted;

            return NoContent();
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var itemDelete = _todoItems.FirstOrDefault(x => x.ID == id);
            if (itemDelete == null)
            {
                return NotFound();
            }
            _todoItems.Remove(itemDelete);

            return NoContent();
        }
    }
}
