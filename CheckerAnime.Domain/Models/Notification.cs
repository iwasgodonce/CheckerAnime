using System.ComponentModel.DataAnnotations.Schema;

namespace CheckerAnime.Domain.Models
{
    public class Notification : Entity
    {
        public int VoiceAnimeId { get; set; }
        [ForeignKey("VoiceAnimeId")]
        public VoiceAnime VoiceAnime { get; set; }

        public string Series { get; set; }

        public Notification(int voiceAnimeId, string series)
        {
            VoiceAnimeId = voiceAnimeId;
            Series = series;
        }
    }
}
