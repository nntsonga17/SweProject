namespace Web
{
    public class EmailDTO
    {
        public string To;
        public string Subject;
        public string Body;

        public EmailDTO(string email, string ime, string datum)
        {
                To = email;
                Subject = "Zakazan pregled!";
                Body = $"Poštovani {ime}, zakazan Vam je pregled {datum}! Čekamo Vas! Vaša Poliklinika.";
        }
        public EmailDTO(string email,string ime,string dijagnoza,string datum)
        {
            To = email;
            Subject = "Dijagnoza: ";
            Body = $"Poštovani {ime}, stigla je dijagnoza za Vaš pregled {datum}: {dijagnoza}";
        }
    }
}