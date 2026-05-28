using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace Peliculas
{
    public class Pelicula
    {
        public string ImdbID { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public int Year { get; set; } = 0;
        public double ImdbRating { get; set; } = 0.0;
        public string Genre { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;

        public Pelicula() { }

        public Pelicula(string imdbID, string title, int year, double imdbRating, string genre, string director)
        {
            ImdbID = imdbID;
            Title = title;
            Year = year;
            ImdbRating = imdbRating;
            Genre = genre;
            Director = director;
        }

        public override string ToString()
        {
            return $"{Title} ({Year}) - IMDb Rating: {ImdbRating}, Genre: {Genre}, Director: {Director}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Pelicula pelicula &&
                   ImdbID == pelicula.ImdbID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ImdbID);
        }
    }
}
