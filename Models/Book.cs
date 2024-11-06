using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServerBlazorEF.Models;

public class Book
{
    public int BookId { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? AuthorName { get; set; }
    [Required]
    public string? Genre { get; set; }
    [Required]
    public string? DatePublication { get; set; }
    [Required]
    public string? Synopsis { get; set; }
}
