namespace Models
{
    public class Photo
    {
        [Key]
        public int ID{get;set;}
        public string Url{get;set;}
        public string PublicId{get;set;}
        public ClanKlinike ClanKlinike{get;set;}
        public int ClanKlinikeId{get;set;}
    }
}