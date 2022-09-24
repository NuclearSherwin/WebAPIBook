using System.ComponentModel.DataAnnotations;

namespace WebAPIPhong.Models
{
    public class Book
    {
        [Key] public int Id { get; set; }
        [Required] public string Tittle { get; set; }
        [Required] public string  Author { get; set; }
        [Required] public string Category { get; set; }
        [Required] public int PageNum { get; set; }
    }
}