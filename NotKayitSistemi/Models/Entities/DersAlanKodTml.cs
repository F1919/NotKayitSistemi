using System.ComponentModel.DataAnnotations;

namespace NotKayitSistemi.Models.Entities
{
    public class DersAlanKodTml
    {
        [Key]
        public long Id { get; set; }

        [Required, MaxLength(50)]
        public string Tur { get; set; } = null!;

        // Navigation
        public ICollection<DersTml> Dersler { get; set; } = new List<DersTml>();
    }
}
