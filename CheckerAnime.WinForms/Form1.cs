using CheckerAnime.Domain;
using CheckerAnime.Domain.Models;
using HtmlAgilityPack;
using Microsoft.VisualBasic.Devices;
using System.Net;
using System.Net.Mail;
using static System.Net.WebRequestMethods;

namespace CheckerAnime.WinForms
{
    public partial class Form1 : Form
    {
        private readonly CheckerAnimeContext _context;
        public Form1()
        {
            InitializeComponent();
            _context = new CheckerAnimeContext();
            InitAnime();
            InitVoiceStudio();
        }

        private void InitAnime()
        {
            listBoxAnime.Items.Clear();

            var animeNames = _context.Animes.Select(x => x.Name).ToArray();
            listBoxAnime.Items.AddRange(animeNames);
        }

        private void InitVoiceStudio()                                                                     
        {
            listBoxVoices.Items.Clear();

            var voiceStudios = _context.VoiceStudios.Select(x => x.Name).ToArray();
            listBoxVoices.Items.AddRange(voiceStudios);
        }

        private void AddAnime_Click(object sender, EventArgs e)
        {
            string animeName = textBoxAnime.Text;
            var anime = _context.Animes.FirstOrDefault(a => a.Name == animeName);

            if (anime != null)
            {
                MessageBox.Show("Аниме с таким названием уже добавлено");
                return;
            }

            var addedAnime = new Anime(animeName);
            _context.Animes.Add(addedAnime);
            _context.SaveChanges();

            foreach (var voiceStudio in _context.VoiceStudios)
            {
                _context.VoiceAnimes.Add(new VoiceAnime(addedAnime.Id, voiceStudio.Id));
            }
            _context.SaveChanges();

            textBoxAnime.Text = string.Empty;
            InitAnime();
        }

        private void buttonVoiceAdd_Click(object sender, EventArgs e)
        {
            string voiceName = textBoxVoice.Text;
            var voice = _context.VoiceStudios.FirstOrDefault(a => a.Name == voiceName);

            if (voice != null)
            {
                MessageBox.Show("Студия с таким названием уже добавлена");
                return;
            }

            var addedVoice = new VoiceStudio(voiceName);
            _context.VoiceStudios.Add(addedVoice);
            _context.SaveChanges();

            foreach (var anime in _context.Animes)
            {
                _context.VoiceAnimes.Add(new VoiceAnime(anime.Id, addedVoice.Id));
            }
            _context.SaveChanges();

            textBoxVoice.Text = string.Empty;
            InitVoiceStudio();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "https://animego.org/";
            HttpClient client = new HttpClient();

            string html = client.GetStringAsync(url).Result;
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(html);

            var fromEmail = "ska20121991@gmail.com";
            var fromPassword = "aohfdhqqyzdtdxve";

            using var smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(fromEmail, fromPassword);

            HtmlNode todayAnime = htmlDoc.GetElementbyId("slide-toggle-1");
            foreach(  var nodeTodayAnime in todayAnime.ChildNodes)
            {
                string titleAnime = nodeTodayAnime.Descendants().First(a => a.HasClass("last-update-title")).InnerText;
                var anime = _context.Animes.FirstOrDefault(a => a.Name == titleAnime);
                if (anime == null) continue;                                

                string voiceName = nodeTodayAnime.Descendants().First(a => a.HasClass("text-gray-dark-6")).InnerText;
                if (voiceName.StartsWith("(") && voiceName.EndsWith(")"))
                {
                    voiceName = voiceName.Substring(1, voiceName.Length - 2);
                }
                var voice = _context.VoiceStudios.FirstOrDefault(a => a.Name == voiceName);
                if (voice == null) continue;

                string seriesAnime = nodeTodayAnime.Descendants().First(a => a.HasClass("text-truncate")).InnerText;
                var voiceAnime = _context.VoiceAnimes.First(va => va.AnimeId == anime.Id && va.VoiceStudioId == voice.Id);

                var style = nodeTodayAnime.Descendants().First(a => a.HasClass("img-square")).GetAttributeValue<string>("style", "");
                var image = style.Substring(style.IndexOf("(") + 1).Replace("120x120", "500x700");
                image = image.Substring(0, image.Length - 2);

                var onclick = nodeTodayAnime.GetAttributeValue<string>("onclick", "");
                var link = onclick.Substring(onclick.IndexOf("'")+1);
                link = $"https://animego.org{link.Substring(0, link.Length - 1)}";

                if (_context.Notifications.Any(n => n.VoiceAnimeId == voiceAnime.Id && n.Series == seriesAnime)) continue;

                try
                {
                    var messageBody = $@"<!DOCTYPE html>
<html lang=""en"">
	<head>
		<meta charset=""UTF-8"" />
		<meta
			http-equiv=""X-UA-Compatible""
			content=""IE=edge""
		/>
		<meta
			name=""viewport""
			content=""width=device-width, initial-scale=1.0""
		/>
		<title>Document</title>
		<style>
			.card {{
				box-shadow: 0 0 15px rgba(0, 0, 0, 0.2);
				width: 250px;
				padding: 15px;
			}}
			.card * {{
				font-family: ""Segoe UI"", Tahoma, Geneva, Verdana, sans-serif;
				box-sizing: border-box;
			}}
			.content {{
			}}
			img {{
				height: 350px;
				width: 100%;
				margin-bottom: 15px;
				object-fit: cover;
			}}
			h2 {{
				text-align: center;
				text-decoration: underline;
				color: black;
			}}
			.seria,
			.studio {{
				display: block;
				margin: 0 auto;
				font-size: 16px;
				text-align: center;
			}}
			.studio {{
				font-weight: bold;
			}}
			.card a {{
				padding: 15px;
				background-color: rgb(2, 57, 57);
				border: 1px solid rgb(2, 57, 57);
				color: white;
				border-radius: 16px;
				text-decoration: none;
				width: 100%;
				font-weight: bold;
				transition: all linear 200ms;
				display: block;
				text-align: center;
				margin-top: 15px;
			}}
			.card a:hover {{
				background-color: transparent;
				color: rgb(2, 57, 57);
			}}
		</style>
	</head>
	<body>
		<div class=""card"">
			<img
				src=""{image}""
				alt=""""
			/>
			<div class=""content"">
				<h2>{anime.Name}</h2>
				<div class=""info"">
					<span class=""seria"">{seriesAnime}</span>
					<span class=""studio"">{voice.Name}</span>
				</div>
				<a href=""{link}"">Хочу Посмотреть</a>
			</div>
		</div>
	</body>
</html>
";
                    var message = new MailMessage(fromEmail, "ska201291@gmail.com", "Вышел новый тайтл!", messageBody);
                    message.IsBodyHtml = true;
                    smtpClient.Send(message);

                    _context.Notifications.Add(new Notification(voiceAnime.Id, seriesAnime));
                    _context.SaveChanges();
                }
                catch { };
            }
        }

        private void buttonAnimeRemove_Click(object sender, EventArgs e)                                      
        {
            var selectedAnime = listBoxAnime.SelectedItem;
            if (selectedAnime == null)
            {
                MessageBox.Show("Вы не выбрали аниме для удаления");
                return;
            }

            var dbSelectedAnime = _context.Animes.First(a => a.Name == selectedAnime);

            var voicesAnimes = _context.VoiceAnimes.Where(va => va.AnimeId == dbSelectedAnime.Id).ToList();
            foreach (var voiceAnime in voicesAnimes)  
            {          
                _context.VoiceAnimes.Remove(voiceAnime);
            }
            _context.Animes.Remove(dbSelectedAnime);
            _context.SaveChanges();

            InitAnime();
        }

        private void buttonVoiceRemove_Click(object sender, EventArgs e)                                           
        {
            var selectedVoice = listBoxVoices.SelectedItem;
            if (selectedVoice == null)
            {
                MessageBox.Show("Вы не выбрали студию озвучки для удаления");
                return;
            }

            var dbSelectedVoice = _context.VoiceStudios.First(a => a.Name == selectedVoice);

            var voicesAnimes = _context.VoiceAnimes.Where(va => va.VoiceStudioId == dbSelectedVoice.Id).ToList();
            foreach (var voiceAnime in voicesAnimes)
            { 
                _context.VoiceAnimes.Remove(voiceAnime);
            }
            _context.VoiceStudios.Remove(dbSelectedVoice);
            _context.SaveChanges();

            InitVoiceStudio();
        }
    }
}