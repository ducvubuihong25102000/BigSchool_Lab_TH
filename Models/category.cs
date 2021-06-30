using System.ComponentModel.DataAnnotations;

namespace BigSchool.Models
{
    public class category
    {
        public byte Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}