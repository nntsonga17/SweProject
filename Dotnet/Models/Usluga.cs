namespace Models
{

    public class Usluga
    {
        [Key]
        public int ID{get;set;}
        [MaxLength(50)]
        public required string VrstaUsluge{get;set;}
        public required string OpisUsluge{get;set;}
        public required int CenaUsluge{get;set;}
    }
}