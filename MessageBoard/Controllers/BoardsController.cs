using System.Collections.Generic;
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
  public class BoardsController : ControllerBase
  {
    private MessageBoardContext _db;

    public BoardsController(MessageBoardContext db)
    {
      _db = db;
    }

    [Authorize(Roles = Role.Admin)]
    [HttpGet]
    public ActionResult<IEnumerable<Board>> Get(string name)
    {
      var query = _db.Boards.AsQueryable();

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }
      return query.ToList();
    }

    [Authorize(Roles = Role.Admin)]
    [HttpPost]
    public void Post([FromBody] Board board)
    {
      _db.Boards.Add(board);
      _db.SaveChanges();
    }

    [Authorize(Roles = Role.Admin)]
    [HttpGet("{id}")]
    public ActionResult<Board> Get(int id)
    {
      Board thisBoard = _db.Boards
      .Include(board => board.Posts)
      .ThenInclude(post => post.Messages)
      .FirstOrDefault(entry => entry.BoardId == id);
      return thisBoard;
    }

    [Authorize(Roles = Role.Admin)]
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Board board)
    {
      board.BoardId = id;
      _db.Entry(board).State = EntityState.Modified;
      _db.SaveChanges();
    }

    [Authorize(Roles = Role.Admin)]
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var boardToDelete = _db.Boards.FirstOrDefault(entry => entry.BoardId == id);
      _db.Boards.Remove(boardToDelete);
      _db.SaveChanges();
    }
  }
}