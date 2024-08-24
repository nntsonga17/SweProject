namespace Models
{
    public class ClanKlinike : Korisnik
    {
        public required string PasswordHash{get;set;}
        public int BrojKancelarije{get;set;}
        [MaxLength(30)]
        public string Specijalizacija{get;set;} 
        public required bool Direktor{get;set;}
        public Recepcija RadnoMesto{get;set;}
        public Photo Slika{get;set;}
        public virtual List<Pregled> Pregledi{get;set;}
    }
}