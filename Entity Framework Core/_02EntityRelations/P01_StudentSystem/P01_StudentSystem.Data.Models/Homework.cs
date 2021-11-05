﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using P01_StudentSystem.Data.Models.Enumerations;

namespace P01_StudentSystem.Data.Models
{
    public class Homework
    {
        [Key]
        public IPHostEntry HomeworkId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(200)")]
        public string Content { get; set; }

        [Required]
        public ContentTypeEnum ContentType { get; set; }
        
        [Required] 
        public DateTime SubmissionTime { get; set; }

        [Required]
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        
        [Required]
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}