using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckerAnime.Domain.Models
{
    public class VoiceAnime : Entity
    {
        public int AnimeId { get; set; }
        [ForeignKey("AnimeId")]
        public Anime Anime { get; set; }

        public int VoiceStudioId { get; set; }
        [ForeignKey("VoiceStudioId")]
        public VoiceStudio VoiceStudio { get; set; }

        public VoiceAnime(int animeId, int voiceStudioId)
        {
            AnimeId = animeId;
            VoiceStudioId = voiceStudioId;
        }
    }
}
