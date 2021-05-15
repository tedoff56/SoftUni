using System;
using System.Collections.Generic;
using System.Linq;

namespace Articles2_03
{
    class Article
    {
        
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        
        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();
            
            for (int i = 0; i < n; i++)
            {
                string[] articleData = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                Article article = new Article()
                {
                    Title = articleData[0],
                    Content = articleData[1],
                    Author =  articleData[2]
                };
                articles.Add(article);
            }

            List<Article> sortedArticles = new List<Article>();
            string orderBy = Console.ReadLine();
            if (orderBy == "title")
            {
                sortedArticles = articles
                    .OrderBy(a => a.Title)
                    .ToList();
            }
            else if (orderBy == "content")
            {
                sortedArticles = articles
                    .OrderBy(a => a.Content)
                    .ToList();
            }
            else if (orderBy == "author")
            {
                sortedArticles = articles
                    .OrderBy(a => a.Author)
                    .ToList();
            }

            
            foreach (var article in sortedArticles)
            {
                Console.WriteLine(article.ToString());
            }
            
        }
    }
}