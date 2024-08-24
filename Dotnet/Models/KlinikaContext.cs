namespace Models
{

    public class KlinikaContext : DbContext
    {
        [Required]
        public DbSet<Korisnik> Korisnici{get;set;}
        [Required]
        public DbSet<ClanKlinike> ClanoviKlinike{get;set;}
        [Required]
        public DbSet<Pacijent> Pacijenti{get;set;}
        [Required]
        public DbSet<Formular> Formulari{get;set;}
        [Required]
        public DbSet<Pregled> Pregledi{get;set;}
        [Required]
        public DbSet<Usluga> Usluge{get;set;}
        [Required]
        public DbSet<Recepcija> Recepcije{get;set;}
        [Required]
        public DbSet<Photo> Slike{get;set;}
        public KlinikaContext(DbContextOptions options) : base(options)
        {

        }

    }
}