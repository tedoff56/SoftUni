using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VaporStore.Common;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class UserImportDto
    {
        
        [Required]
        [RegularExpression(@"^[A-Z][a-z]*\s[A-Z][a-z]*$")]
        public string FullName { get; set; }

        [Required]
        [MinLength(UserConstants.USER_USERNAME_MIN_LENGTH)]
        [MaxLength(UserConstants.USER_USERNAME_MAX_LENGTH)]
        public string Username { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Range(UserConstants.USER_AGE_MIN_VALUE, UserConstants.USER_AGE_MAX_VALUE)]
        public int Age { get; set; }

        public CardImportDto[] Cards { get; set; }
    }
}