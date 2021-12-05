using System;
using System.ComponentModel.DataAnnotations;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class GameImportDto
    {
        [Required]
        public string Name { get; set; }
        
        [Range(0, (double)decimal.MaxValue)]
        public decimal Price { get; set; }
        
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        public string Developer { get; set; }

        [Required]
        public string Genre { get; set; }
        
        [MinLength(1)]
        public string[] Tags { get; set; }
        
        
    }
}