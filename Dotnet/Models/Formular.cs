namespace Models
{

    public class Formular
    {
        [Key]
        public int ID{get;set;}
        [MaxLength(30)]
        public required string Ime{get;set;}
        [MaxLength(30)]
        public required string Prezime{get;set;}
        [MaxLength(30)]
        public required string Email{get;set;}
        [MaxLength(15)]
        public required string BrojTelefona{get;set;}
        public required DateTime DatumRodjenja{get;set;}
        public DateTime datumPregleda{get;set;}
        public bool Scheduled {get;set;}
        [JsonIgnore]
        public Recepcija Recepcija{get;set;}
        public ClanKlinike Doktor{get;set;}
        public Pacijent Pacijent{get;set;}
    }
}   