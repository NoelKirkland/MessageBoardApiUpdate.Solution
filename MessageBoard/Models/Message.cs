using System;
using System.ComponentModel.DataAnnotations;

namespace MessageBoard.Models
{
  public class Message
  {
    public int MessageId { get; set; }
    public int PostId { get; set; }
    public string Heading { get; set; }
    public string Body { get; set;}
    public DateTime DatePosted { get; set; }
  }
}