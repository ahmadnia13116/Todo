using Kangaro.TodoApp.Contracts.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kangaro.TodoApp.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private static readonly List<ListItemDto> _items = new();

        // POST /create
        [HttpPost("create")]
        public IActionResult Create([FromBody] ListItemDto dto)
        {
            dto.Id = Guid.NewGuid(); // اگر خودت Id داری، حذف کن
            _items.Add(dto);
            return Ok(dto);
        }

        // DELETE /delete/{id}
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            var item = _items.FirstOrDefault(x => x.Id.Equals(id));
            if (item == null)
                return NotFound();

            _items.Remove(item);
            return Ok();
        }

        // GET /get/{id}
        [HttpGet("get/{id}")]
        public ActionResult<ListItemDto> Get(Guid id)
        {
            var item = _items.FirstOrDefault(x => x.Id.Equals(id));
            if (item == null)
                return NotFound();

            return item;
        }

        // GET /getList
        [HttpGet("getList")]
        public ActionResult<IEnumerable<ListItemDto>> GetList()
        {
            return _items;
        }
    }
}
