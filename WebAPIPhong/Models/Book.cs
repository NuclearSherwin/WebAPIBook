using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIPhong.Models
{
    public class Book
    {
        [Key] public int Id { get; set; }
        [Required] public string Tittle { get; set; }
        [Required] public string  Author { get; set; }
        [Required] public int CategoryId { get; set; }
        [Required] public int PageNum { get; set; }
        
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}