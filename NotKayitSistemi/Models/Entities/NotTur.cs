using System.ComponentModel.DataAnnotations;

namespace NotKayitSistemi.Models.Entities
{
    public class NotKodTml
    {
        [Key]
        public long Id { get; set; }

        [Required, MaxLength(50)]
        public string Tur { get; set; } = null!;

        public ICollection<NotTml> Notlar { get; set; } = new List<NotTml>();
    }
}
