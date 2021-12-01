using System.Globalization;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using VaporStore.Data.Models;
using VaporStore.DataProcessor.Dto.Import;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data;

	public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			GameImportDto[] games = JsonConvert.DeserializeObject<GameImportDto[]>(jsonString);

			StringBuilder sb = new StringBuilder();

			List<Game> gamesDb = new List<Game>();

			List<Developer> devs = new List<Developer>();
			List<Genre> genres = new List<Genre>();
			List<Tag> tags = new List<Tag>();
			
			foreach (var gameDto in games)
			{
				if (!IsValid(gameDto))
				{
					sb.AppendLine("Invalid Data");
					continue;
				}
				
				if (!DateTime.TryParse(
					gameDto.ReleaseDate,
					CultureInfo.InvariantCulture,
					DateTimeStyles.None,
					out DateTime dateTimeResult))
				{
					sb.AppendLine("Invalid Data");
					continue;
				}
				
				Game game = new Game()
				{
					Name = gameDto.Name,
					Price = gameDto.Price,
					ReleaseDate = dateTimeResult
				};

				Developer developer = devs.FirstOrDefault(d => d.Name == gameDto.Developer);
				if(developer is null)
				{
					developer = new Developer() { Name = gameDto.Developer };
					devs.Add(developer);
				}
				game.Developer = developer;
				
				Genre genre = genres.FirstOrDefault(g => g.Name == gameDto.Genre);
				if (genre is null)
				{
					genre = new Genre() { Name = gameDto.Genre };
					genres.Add(genre);
				}
				game.Genre = genre;


				foreach (var tagDto in gameDto.Tags)
				{
					Tag tag = tags.FirstOrDefault(t => t.Name == tagDto);
					if (tag is null)
					{
						tag = new Tag() { Name = tagDto };
						tags.Add(tag);
					}

					game.GameTags.Add(new GameTag(){Tag = tag});
				}
				
				gamesDb.Add(game);
				
				sb.AppendLine($"Added {game.Name} ({game.Genre}) with {game.GameTags.Count} tags");
			}
			
			context.Games.AddRange(gamesDb);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			throw new NotImplementedException();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			throw new NotImplementedException();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}