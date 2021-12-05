using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Theatre.Data;
using Theatre.DataProcessor.ExportDto;
using Formatting = Newtonsoft.Json.Formatting;

namespace Theatre.DataProcessor
{
    using System;
 using Theatre.Data.Models;
    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theathres = context.Theatres
                .ToList()
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
                .Select(t => new TheatreJsonExportDto()
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets.Where(t => t.RowNumber >= 1 && t.RowNumber <= 5).Sum(t => t.Price),
                    Tickets = t.Tickets
                        .Where(t => t.RowNumber >= 1 && t.RowNumber <= 5)
                        .Select(t => new TicketJsonExportDto()
                        {
                            Price = t.Price,
                            RowNumber = t.RowNumber
                        })
                        .OrderByDescending(t => t.Price)
                        .ToList()
                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToList();
                
            string result = JsonConvert.SerializeObject(theathres, Formatting.Indented);

            return result;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {

            var plays = context.Plays.ToArray()
                .Where(p => p.Rating <= rating)
                .Select(p => new PlayXmlExportDto()
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c"),
                    Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts
                        .Where(c => c.IsMainCharacter)
                        .Select(c => new ActorXmlExportDto()
                        {
                            FullName = c.FullName,
                            MainCharacter = $"Plays main character in '{c.Play.Title}'."
                        })
                        .OrderByDescending(a => a.FullName)
                        .ToArray()
                })
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ToArray();
            
            XmlSerializer serializer = new XmlSerializer(typeof(PlayXmlExportDto[]), 
                new XmlRootAttribute("Plays"));
            
            var sb = new StringBuilder();
            
            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            
            serializer.Serialize(new StringWriter(sb), plays, xmlNamespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
