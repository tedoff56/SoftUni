﻿using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using BookShop.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace BookShop
{
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();


            Console.WriteLine(CountBooks(db, 12));
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int numberOfBooks = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return numberOfBooks;
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var result = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    AuthorName = $"{b.Author.FirstName} {b.Author.LastName}"
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in result)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorName})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var result = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var title in result)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }

        //TODO: check for last test errors
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var result = context
                .Authors
                .Where(a => a.FirstName.EndsWith(input))
                .OrderBy(a => a.FirstName)
                .Select(a => $"{a.FirstName} {a.LastName}")
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var author in result)
            {
                sb.AppendLine(author);
            }

            return sb.ToString().TrimEnd();
        }

        //TODO: check for errors
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var result = context.Books
                .Where(b => b.ReleaseDate.Value < DateTime.Parse(date))
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    EditionType = b.EditionType.ToString(),
                    Price = '$' + b.Price.ToString("F2")
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in result)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - {book.Price}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var result = context.Books
                .Where(b => b.BookCategories
                    .Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var title in result)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var result = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var title in result)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    b.Title,
                    Price = '$' + b.Price.ToString("F2")
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.Price}");
            }
            
            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenEditionBooks = context
                .Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var bookTitle in goldenEditionBooks)
            {
                sb.AppendLine(bookTitle);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var booksTitles = context.Books
                .Where(b => b.AgeRestriction == Enum.Parse<AgeRestriction>(command, true))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var bookTitle in booksTitles)
            {
                sb.AppendLine(bookTitle);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
