namespace Models
{

    public class Pregled
    {
        [Key]
        public int ID{get;set;}
        public DateTime DatumVreme{get;set;}
        public required string Dijagnoza{get;set;}
        [JsonIgnore]
        public ClanKlinike Doktor{get;set;}
        [JsonIgnore]
        public Pacijent Pacijent{get;set;}
    }
}