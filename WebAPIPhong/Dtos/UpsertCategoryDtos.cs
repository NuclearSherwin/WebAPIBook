using System.ComponentModel.DataAnnotations;

namespace WebAPIPhong.Dtos
{
    public class UpsertCategoryDtos
    {
        [Required] public string Name { get; set; }
        [Required] public string Description { get; set; }
    }
}