namespace NotKayitSistemi.Models.ViewModels
{
    public class OgrenciTmlViewModel
    {
        public long Id { get; set; }

        public string Ad { get; set; }
        public string Soyad { get; set; }

        public DateTime DogumTarihi { get; set; }

        public string Cinsiyet { get; set; }

        public int Yas
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - DogumTarihi.Year;
                if (DogumTarihi.Date > today.AddYears(-age)) age--;
                return age;
            }
        }
    }
}
