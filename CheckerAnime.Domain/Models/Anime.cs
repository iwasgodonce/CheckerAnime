namespace CheckerAnime.Domain.Models
{
    public class Anime : Entity
    {
        public string Name { get; set; }

        public Anime(string name)
        {
            Name = name;
        }
    }
}
