using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Backend.Models;

public class Post
{
    public int PostId { get; set; }

    [Required]
    public required string Title { get; set; }

    [Required]
    public required string Content { get; set; }

    [Required]
    public int UserId { get; set; }
}
