using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToDoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {

        // private static List<ToDoList> todos = new List<ToDoList>
        //  {
        //   new ToDoList { id = Guid.NewGuid(), title="Read Team Human", dueDate = DateTime.Now, doneDate = DateTime.Now
        // }
        // };

        private readonly DataContext _context;

        public ToDoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        // public async Task<IActionResult> Get()
        public async Task<ActionResult<List<ToDoList>>> Get()
        {
            // return Ok(todos);
            return Ok(await _context.ToDos.ToListAsync());
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoList>> Get(Guid id)

        {
            // var todo = todos.Find(t => t.id == id);
            var todo = await _context.ToDos.FindAsync(id);
            if (todo == null)
                return BadRequest("ToDo not found");
            return Ok(todo);
        }
        [HttpPost]
        public async Task<ActionResult<List<ToDoList>>> AddToDo(ToDoList todo)
        {

            _context.ToDos.Add(todo);
            await _context.SaveChangesAsync();

            return Ok(await _context.ToDos.ToListAsync());


            //todos.Add(todo);
            //return Ok(todos);
        }
        [HttpPut]
        public async Task<ActionResult<List<ToDoList>>> UpdateToDo(ToDoList request)
        {
            //var todo = todos.Find(t => t.id == request.id);
            //if (todo == null)
            // return BadRequest("ToDo not found");

            var dbtodo = await _context.ToDos.FindAsync(request.id);
            if (dbtodo == null)
                return BadRequest("ToDo not found");

            dbtodo.title = request.title;
            dbtodo.updatedDate = request.updatedDate;
            dbtodo.dueDate = request.dueDate;          
            dbtodo.done = request.done;      

            await _context.SaveChangesAsync();

            return Ok(await _context.ToDos.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ToDoList>>> Delete(Guid id)

        {


            var dbtodo = await _context.ToDos.FindAsync(id);
            if (dbtodo == null)
                return BadRequest("ToDo not found");

            _context.ToDos.Remove(dbtodo);

            await _context.SaveChangesAsync();
            return Ok(await _context.ToDos.ToListAsync());
        }


        // var todo = todos.Find(t => t.id == id);
        // if (todo == null)
        // return BadRequest("ToDo not found");
        // todos.Remove(todo);
        // return Ok(todos);
    }
}

