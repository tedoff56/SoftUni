using System;

namespace Articles_02
{
    class Article
    {
        
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public string Edit(string newContent)
        {
            Content = newContent;
            return Content;
        }

        public string ChangeAuthor(string newAuthor)
        {
            Author = newAuthor;
            return Author;
        }

        public string Rename(string newTitle)
        {
            Title = newTitle;
            return Title;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            string[] articleData = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Article article = new Article
            {
                Title = articleData[0],
                Content = articleData[1],
                Author = articleData[2]
            };

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(": ");

                string action = tokens[0];
                string newInfo = tokens[1];
                if (action == "Edit")
                {
                    article.Edit(newInfo);
                }
                else if (action == "ChangeAuthor")
                {
                    article.ChangeAuthor(newInfo);
                }
                else if (action == "Rename")
                {
                    article.Rename(newInfo);
                }
            }

            Console.WriteLine(article.ToString());
        }
    }
}