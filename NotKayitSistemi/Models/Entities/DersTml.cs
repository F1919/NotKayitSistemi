using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotKayitSistemi.Models.Entities
{
    public class DersTml
    {
        [Key]
        public long Id { get; set; }

        [Required, MaxLength(100)]
        public string DersAd { get; set; } = null!;

        [Required]
        public long DersAlanKodId { get; set; }

        public short KrediSayisi { get; set; }

        [ForeignKey(nameof(DersAlanKodId))]
        public DersAlanKodTml? DersAlanKodTml { get; set; }

        public ICollection<OgrenciDers> OgrenciDersler { get; set; } = new List<OgrenciDers>();
        public ICollection<NotTml> Notlar { get; set; } = new List<NotTml>();
    }
}
