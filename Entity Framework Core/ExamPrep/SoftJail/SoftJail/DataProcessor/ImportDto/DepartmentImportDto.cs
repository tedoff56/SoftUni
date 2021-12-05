﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class DepartmentImportDto
    {
        public DepartmentImportDto()
        {
            this.Cells = new List<CellImportDto>();
        }
        
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Name { get; set; }

        public ICollection<CellImportDto> Cells { get; set; }

    }
}