using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotKayitSistemi.Models.Entities
{
 
    public class OgrenciDers
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long OgrenciTmlId { get; set; }

        [Required]
        public long DersId { get; set; }

        public DateTime KayitTarihi { get; set; } = DateTime.Now;

        // Navigation nullable olmalı
        public OgrenciTml? OgrenciTml { get; set; }

        [ForeignKey(nameof(DersId))]
        public DersTml? DersTml { get; set; }
    }
}
