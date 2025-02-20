using Demo_IoC_Pattern.Model;
using Demo_IoC_Pattern;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace  Demo_IoC_Pattern

{
    public class XMLMovieReader : IMoviesReader
    {
        static string url = @"Data\";
        static XDocument films = XDocument.Load(url + "MoviesDB.xml");

        static List<Movie> movies = new List<Movie>();

        public List<Movie> ReadMovies()
        {
            var movieCollection = (from f in films.Descendants("Movie")
                                   select new Movie
                                   {
                                       ID = f.Element("ID").Value,
                                       Title = f.Element("Title").Value,
                                       OscarNominations = f.Element("OscarNominations").Value,
                                       OscarWins = f.Element("OscarWins").Value
                                   }).ToList();

            return movieCollection;
        }
    }
}