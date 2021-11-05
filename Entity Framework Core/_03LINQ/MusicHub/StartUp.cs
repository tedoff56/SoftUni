using System.Globalization;
using System.Linq;
using System.Text;

namespace MusicHub
{
    using System;

    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = 
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albumsResult = context.Albums
                .ToArray()
                .Where(a => a.ProducerId == producerId)
                .OrderByDescending(a => a.Price)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                        .ToArray()
                        .Select(s => new
                        {
                            SongName = s.Name,
                            Price = s.Price.ToString("F2"),
                            Writer = s.Writer.Name
                        })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.Writer),
                    TotalPrice = a.Price.ToString("F2")
                })
                .ToArray();


            StringBuilder sb = new StringBuilder();
            
            foreach (var album in albumsResult)
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine($"-Songs:");

                int i = 1;
                foreach (var song in album.Songs)
                {
                    sb.AppendLine($"---#{i++}");
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.Price}");
                    sb.AppendLine($"---Writer: {song.Writer}");
                }

                sb.AppendLine($"-AlbumPrice: {album.TotalPrice}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .ToArray()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    s.Name,
                    PerformerFullName = s.SongPerformers
                        .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                        .FirstOrDefault(),
                    WriterName = s.Writer.Name,
                    s.Album.Producer,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.Name)
                .ThenBy(s => s.WriterName)
                .ThenBy(s => s.PerformerFullName)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            int i = 1;
            foreach (var song in songs)
            {
                sb
                    .AppendLine($"-Song #{i++}")
                    .AppendLine($"---SongName: {song.Name}")
                    .AppendLine($"---Writer: {song.WriterName}")
                    .AppendLine($"---Performer: {song.PerformerFullName}")
                    .AppendLine($"---AlbumProducer: {song.Producer.Name}")
                    .AppendLine($"---Duration: {song.Duration}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
