namespace Models
{

    public class Recepcija
    {
        [Key]
        public int ID{get;set;}
        public required string Adresa{get;set;}
        public virtual List<ClanKlinike> Lekari{get;set;}
    }
}