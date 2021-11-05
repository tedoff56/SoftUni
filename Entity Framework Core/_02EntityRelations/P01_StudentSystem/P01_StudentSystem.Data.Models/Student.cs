using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public Student()
        {
            this.StudentCourses = new HashSet<StudentCourse>();
            this.Homeworks = new HashSet<Homework>();
        }
        
        [Key]
        public int StudentIt { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        [Column(TypeName = "CHAR(10)")]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegisteredOn { get; set; }

        public DateTime Birthday { get; set; }
        
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}