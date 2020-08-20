using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MessageBoard.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace MessageBoard.Controllers
{
  [Authorize(Roles = Role.Admin)]
  [Route("api/[controller]")]
  [ApiController]
  public class MessagesController : ControllerBase
  {
    private MessageBoardContext _db;

    public MessagesController(MessageBoardContext db)
    {
      _db = db;
    }

    [Authorize(Roles = Role.Admin)]
    [HttpGet]
    public ActionResult<IEnumerable<Message>> Get() // DateTime date
    {
      // var query = _db.Messages.AsQueryable();
      
      // if (date != null)
      // {
      //   query = query.Where(entry => entry.DatePosted == date);
      // }

      // return query.ToList();
      return _db.Messages.ToList();
    }

    [Authorize(Roles = Role.Admin)]
    [HttpPost]
    public void Post([FromBody] Message message)
    {
      _db.Messages.Add(message);
      _db.SaveChanges();
    }

    [Authorize(Roles = Role.Admin)]
    [HttpGet("{id}")]
    public ActionResult<Message> Get(int id)
    {
      return _db.Messages.FirstOrDefault(entry => entry.MessageId == id);
    }

    [Authorize(Roles = Role.Admin)]
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Message message)
    {
      message.MessageId = id;
      _db.Entry(message).State = EntityState.Modified;
      _db.SaveChanges();
    }

    [Authorize(Roles = Role.Admin)]
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var messageToDelete = _db.Messages.FirstOrDefault(entry => entry.MessageId == id);
      _db.Messages.Remove(messageToDelete);
      _db.SaveChanges();
    }
  }
}