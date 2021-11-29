using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VaporStore.Common;
using VaporStore.Data.Models.Enums;

namespace VaporStore.Data.Models
{
    public class Card
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        [MaxLength(CardConstants.CARD_CVC_MAX_LENGTH)]
        public string Cvc { get; set; }

        [Required]
        public CardType Type { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        [Required]
        public virtual User User { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
        
    }
}