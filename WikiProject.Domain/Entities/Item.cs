using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace WikiProject.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public required string Name { get; set; }
        public string? Description { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }

        [Display(Name = "Image Url")]
        public string? ImageUrl { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set;}
    }
}
