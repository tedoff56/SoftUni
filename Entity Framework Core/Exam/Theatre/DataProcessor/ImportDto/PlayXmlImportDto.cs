﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Theatre.Data.Models.Enums;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class PlayXmlImportDto
    {
        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public string Title { get; set; }
        
        [Required]
        public string Duration { get; set; }

        [Range(0, 10.0)]
        public float Rating { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        [MaxLength(700)]
        public string Description { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Screenwriter { get; set; }
    }
}