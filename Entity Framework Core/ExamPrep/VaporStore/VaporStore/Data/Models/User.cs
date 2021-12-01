using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VaporStore.Common;

namespace VaporStore.Data.Models
{
    public class User
    {
        public User()
        {
            this.Cards = new HashSet<Card>();
        }
        
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(UserConstants.USER_USERNAME_MAX_LENGTH)]
        public string Username { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [MaxLength(UserConstants.USER_AGE_MAX_VALUE)]
        public int Age { get; set; }

        public ICollection<Card> Cards { get; set; }
        
        
    }
}