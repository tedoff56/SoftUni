using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Theatre.Data.Models;
using Theatre.Data.Models.Enums;
using Theatre.DataProcessor.ImportDto;

namespace Theatre.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Theatre.Data;
    using Theatre.Data.Models;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PlayXmlImportDto[]), new XmlRootAttribute("Plays"));
            
            PlayXmlImportDto[] plays = (PlayXmlImportDto[])
                serializer.Deserialize(new StringReader(xmlString));

            List<Play> playsDb = new List<Play>();
            
            var result = new StringBuilder();

            foreach (var play in plays)
            {
                if (!IsValid(play))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                if (!TimeSpan.TryParseExact(play.Duration, "c", CultureInfo.CurrentCulture, out TimeSpan duration))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                if (duration.Hours < 1)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }
                
                if(!Enum.TryParse(play.Genre, out Genre genre))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                Play playDb = new Play()
                {
                    Title = play.Title,
                    Duration = duration,
                    Rating = play.Rating,
                    Genre = genre,
                    Description = play.Description,
                    Screenwriter = play.Screenwriter
                };

                playsDb.Add(playDb);
                result.AppendLine(string.Format(
                    SuccessfulImportPlay,
                    playDb.Title,
                    playDb.Genre.ToString(),
                    playDb.Rating));

            }

            context.AddRange(playsDb);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CastXmlImportDto[]), new XmlRootAttribute("Casts"));
            
            CastXmlImportDto[] casts = (CastXmlImportDto[])
                serializer.Deserialize(new StringReader(xmlString));

            List<Cast> castsDb = new List<Cast>();
            
            var result = new StringBuilder();

            foreach (CastXmlImportDto cast in casts)
            {
                if (!IsValid(cast))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                Cast castDb = new Cast()
                {
                    FullName = cast.FullName,
                    IsMainCharacter = cast.IsMainCharacter,
                    PhoneNumber = cast.PhoneNumber,
                    PlayId = cast.PlayId
                };
                
                castsDb.Add(castDb);
                result.AppendLine(string.Format(
                    SuccessfulImportActor,
                    castDb.FullName, 
                    castDb.IsMainCharacter ? "main" : "lesser"));
            }

            context.AddRange(castsDb);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
           TheatreJsonImportDto[] theatres = 
                JsonConvert.DeserializeObject<TheatreJsonImportDto[]>(jsonString);
           
            var result = new StringBuilder();
           
            List<Theatre> theatresDb = new List<Theatre>();
            
            foreach (TheatreJsonImportDto theatre in theatres)
            {
                if(!IsValid(theatre) || string.IsNullOrWhiteSpace(theatre.Name))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                Theatre theatreDb = new Theatre()
                {
                    Name = theatre.Name,
                    NumberOfHalls = theatre.NumberOfHalls,
                    Director = theatre.Director,
                };
                
                foreach (var ticket in theatre.Tickets)
                {

                    if(!IsValid(ticket))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }
                    
                    Ticket ticketDb = new Ticket()
                    {
                        Price = ticket.Price,
                        RowNumber = ticket.RowNumber,
                        PlayId = ticket.PlayId
                    };

                    theatreDb.Tickets.Add(ticketDb);

                }
                
            
                theatresDb.Add(theatreDb);
                result.AppendLine(string.Format(
                    SuccessfulImportTheatre,
                    theatreDb.Name,
                    theatreDb.Tickets.Count
                ));
            }
            
            context.Theatres.AddRange(theatresDb);
            context.SaveChanges();
            
            return result.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
