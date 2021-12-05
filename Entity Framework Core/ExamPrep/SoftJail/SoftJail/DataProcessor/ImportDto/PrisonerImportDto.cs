﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SoftJail.Data.Models;

namespace SoftJail.DataProcessor.ImportDto
{
    public class PrisonerImportDto
    {
        public PrisonerImportDto()
        {
            this.Mails = new List<MailImportDto>();
        }
        
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string FullName { get; set; }

        [Required]
        [RegularExpression(@"^The\s[A-Z]{1}[a-z]*$")]
        public string Nickname { get; set; }
        
        [Range(18, 65)]
        public int Age { get; set; }
        
        [Required]
        public string IncarcerationDate { get; set; }
        
        public string ReleaseDate { get; set; }

        [Range(0, (double)decimal.MaxValue)]
        public decimal? Bail { get; set; }
        
        public int CellId { get; set; }

        public ICollection<MailImportDto> Mails { get; set; }
    }
}