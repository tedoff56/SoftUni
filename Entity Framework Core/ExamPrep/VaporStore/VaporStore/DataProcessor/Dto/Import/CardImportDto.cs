using System.ComponentModel.DataAnnotations;
using VaporStore.Common;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class CardImportDto
    {
        [Required]
        [RegularExpression(@"^\d{4}\s\d{4}\s\d{4}\s\d{4}$")]
        public string Number { get; set; }

        [Required]
        [MaxLength(CardConstants.CARD_CVC_MAX_LENGTH)]
        [RegularExpression(@"^\d{3}$")]
        public string Cvc { get; set; }

        [Required]
        public CardType? Type { get; set; }
    }
}