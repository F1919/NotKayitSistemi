using System.ComponentModel.DataAnnotations;

namespace NotKayitSistemi.Models.Entities
{
    public class OgrenciTml
    {
        [Key]
        public long Id { get; set; }

        [Required, MaxLength(50)]
        public string Ad { get; set; } = null!;

        [Required, MaxLength(50)]
        public string Soyad { get; set; } = null!;

        public DateTime DogumTarihi { get; set; }

        [Required, MaxLength(5)]
        public string Cinsiyet { get; set; } = null!;

        public ICollection<OgrenciIletisim> OgrenciIletisim { get; set; } = new List<OgrenciIletisim>();
        public ICollection<OgrenciAdres> OgrenciAdresler { get; set; }
        = new List<OgrenciAdres>();
         public ICollection<OgrenciDers> OgrenciDersler { get; set; } = new List<OgrenciDers>();
        public ICollection<NotTml> Notlar { get; set; } = new List<NotTml>();
    }
}
