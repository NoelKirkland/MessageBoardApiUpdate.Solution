using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MessageBoard.Models
{
  public class Post
  {
    public Post()
    {
      this.Messages = new HashSet<Message>();
    }
    public int PostId { get; set; }
    public int BoardId { get; set; }
    public string Title { get; set;}
    public DateTime DatePosted { get; set; }
    public ICollection<Message> Messages { get; set; }
  }
}