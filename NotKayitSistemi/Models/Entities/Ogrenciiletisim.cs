using System.ComponentModel.DataAnnotations;


namespace NotKayitSistemi.Models.Entities
{
   
    public class  OgrenciIletisim
    {
        [Key]
        public long Id { get; set; }   // Birincil anahtar

        [Required]
        public long OgrenciTmlId { get; set; }  // FK

        [MaxLength(100)]
        [Required(ErrorMessage = "Email zorunludur.")]
        [RegularExpression(@"^.*@.*$", ErrorMessage = "Email adresi @ içermelidir.")]
        public string Email { get; set; }
        // VARCHAR(100)

        public long? Telefon { get; set; }     // BIGINT

      


        // Navigation (OgrenciTml entity'in varsa)
        public OgrenciTml? OgrenciTml { get; set; }
    }

}

