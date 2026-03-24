using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotKayitSistemi.Models.Entities
{
   
    public class OgrenciAdres
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long OgrenciTmlId { get; set; }

        [Required, MaxLength(200)]
        public string Adres { get; set; }

        // Navigation
        public OgrenciTml? OgrenciTml { get; set; }
    }

}

