using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MessageBoard.Models
{
  public class Board
  {
    public Board()
    {
      this.Posts = new HashSet<Post>(); 
    }
    public int BoardId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual ICollection<Post> Posts { get; set; }
  }
}