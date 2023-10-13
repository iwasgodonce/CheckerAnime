namespace CheckerAnime.Domain.Models
{
    public class VoiceStudio : Entity
    {
        public string Name { get; set; }

        public VoiceStudio(string name)
        {
            Name = name;
        }
    }
}
