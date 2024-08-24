namespace Models
{

    public class Pacijent : Korisnik 
    {
        [StringLength(13)]
        public required DateTime DatumRodjenja{get;set;}
        public string KucnaAdresa{get;set;}
        public string Alergije{get;set;}
        public string HronicneBolesti{get;set;}
    }
}