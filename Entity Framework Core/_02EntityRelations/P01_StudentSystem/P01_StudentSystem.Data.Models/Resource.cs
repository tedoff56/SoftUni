using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using P01_StudentSystem.Data.Models.Enumerations;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        [Key] 
        public int ResourceId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Url { get; set; }

        [Required]
        public ResourceTypeEnum ResourceType { get; set; }

        [Required]
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        

    }
}