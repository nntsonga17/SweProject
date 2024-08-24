namespace Models
{


    public class Korisnik
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
    }
}