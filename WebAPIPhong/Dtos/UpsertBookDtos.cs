using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPIPhong.Models;

namespace WebAPIPhong.Dtos
{
    public class UpsertBookDtos
    {
        [Required] public string Tittle { get; set; }
        [Required] public string  Author { get; set; }
        [Required] public int CategoryId { get; set; }
        [Required] public int PageNum { get; set; }
        
    }
}