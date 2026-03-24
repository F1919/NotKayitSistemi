using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotKayitSistemi.Models.Entities
{
    public class NotTml
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long OgrenciTmlId { get; set; }

        [Required]
        public long DersId { get; set; }

        [Required]
        public long NotKodTmlId { get; set; }

        [Required]
        public double Deger { get; set; }

        // Navigation nullable olmalı
        public OgrenciTml? OgrenciTml { get; set; }

        [ForeignKey(nameof(DersId))]
        public DersTml? DersTml { get; set; }

        public NotKodTml? NotKodTml { get; set; }
    }
}
