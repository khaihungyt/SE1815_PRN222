using System;
using System.Linq;
using Demo_IoC_Pattern.Model;
using Demo_IoC_Pattern;

namespace Demo_IoC_Pattern
{
    public class ReaderFactory
    {
        public IMoviesReader IMovieReader { get; }

        public ReaderFactory(string fileType)
        {
            switch (fileType)
            {
                case "XML":
                    IMovieReader = new XMLMovieReader();
                    break;
                case "JSON":
                    IMovieReader = new JSONMovieReader();
                    break;
                default:
                    break;
            }
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "IoC Pattern";
            Console.WriteLine("Please, select the file type to read (1) XML, (2) JSON: ");
            string ans = Console.ReadLine();

            string fileType = (ans == "1") ? "XML" : "JSON";
            ReaderFactory readerFactory = new ReaderFactory(fileType);
            string typeSelected = readerFactory.IMovieReader.GetType().Name;

            List<Movie> movieCollection = readerFactory.IMovieReader.ReadMovies();

            Console.WriteLine($"Movie Titles ({typeSelected})");
            Console.WriteLine("------------------");

            foreach (var movie in movieCollection)
            {
                Console.WriteLine($"{movie.ID}, {movie.Title}, {movie.OscarNominations}, {movie.OscarWins}");
            }

            Console.ReadLine();
        }
    }
}