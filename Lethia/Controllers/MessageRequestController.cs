using Microsoft.AspNetCore.Mvc;
using Lethia.Models;
using System.Linq;
using System.Collections.Generic;

namespace Lethia.Controllers
{
    [Route("api/[controller]")]
    public class MessageRequestController : Controller
    {
        private readonly MessageRequestContext _context;

        public MessageRequestController(MessageRequestContext context)
        {
            _context = context;

            if (_context.MessageRequests.Count() == 0)
            {
                _context.MessageRequests.Add(new MessageRequest { Name = "DummyRequest" });
                _context.SaveChanges();
            }
        }

        //[HttpGet]
        //public IEnumerable<MessageRequest> GetAll()
        //{
        //    return _context.MessageRequests.ToList();
        //}

        //[HttpGet("{id}", Name = "GetMessageRequest")]
        //public IActionResult GetById(long id)
        //{
        //    var item = _context.MessageRequests.FirstOrDefault(t => t.Id == id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }
        //    return new ObjectResult(item);
        //}

        [HttpPost]
        public IActionResult Create([FromBody] MessageRequest item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            Program.MessageQueue.AddNewReadMessageRequest(item);
            _context.MessageRequests.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetMessageRequest", new { id = item.Id }, item);
        }

        //[HttpPut("{id}")]
        //public IActionResult Update(long id, [FromBody] MessageRequest item)
        //{
        //    if (item == null || item.Id != id)
        //    {
        //        return BadRequest();
        //    }

        //    var todo = _context.MessageRequests.FirstOrDefault(t => t.Id == id);
        //    if (todo == null)
        //    {
        //        return NotFound();
        //    }

        //    todo.IsComplete = item.IsComplete;
        //    todo.Name = item.Name;

        //    _context.MessageRequests.Update(todo);
        //    _context.SaveChanges();
        //    return new NoContentResult();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(long id)
        //{
        //    var todo = _context.MessageRequests.FirstOrDefault(t => t.Id == id);
        //    if (todo == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.MessageRequests.Remove(todo);
        //    _context.SaveChanges();
        //    return new NoContentResult();
        //}
    }
}