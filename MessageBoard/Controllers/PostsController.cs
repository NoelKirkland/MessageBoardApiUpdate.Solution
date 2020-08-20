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
  public class PostsController : ControllerBase
  {
    private MessageBoardContext _db;

    public PostsController(MessageBoardContext db)
    {
      _db = db;
    }

  [Authorize(Roles = Role.Admin)]
  [HttpGet]
  public ActionResult<IEnumerable<Post>> Get(string name)
  {
    var query = _db.Posts.AsQueryable();

    if (name != null)
    {
      query = query.Where(entry => entry.Title == name);
    }
    return query.ToList();
  }

  [Authorize(Roles = Role.Admin)]
  [HttpPost]
  public void Post([FromBody] Post post)
  {
    _db.Posts.Add(post);
    _db.SaveChanges();
  }

  [Authorize(Roles = Role.Admin)]
  [HttpGet("{id}")]
  public ActionResult<Post> Get(int id)
  {
    Post thisPost = _db.Posts
    .Include(post => post.Messages)
    .FirstOrDefault(post => post.PostId == id);
    return thisPost;
  }

  [Authorize(Roles = Role.Admin)]
  [HttpPut("{id}")]
  public void Put(int id, [FromBody] Post post)
  {
    post.PostId = id;
    _db.Entry(post).State = EntityState.Modified;
    _db.SaveChanges();
  }

  [Authorize(Roles = Role.Admin)]
  [HttpDelete("{id}")]
  public void Delete(int id)
  {
    var postToDelete = _db.Posts.FirstOrDefault(entry => entry.PostId == id);
    _db.Posts.Remove(postToDelete);
    _db.SaveChanges();
  }
  }
}