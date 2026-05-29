using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.ComponentModel.DataAnnotations; // Para usar [Key] en la propiedad ImdbID

namespace Peliculas
{
    public class Pelicula
    {
        [Key]
        public string ImdbID { get; set; } = string.Empty;

        [Required(ErrorMessage = "El título es obligatorio.")] // Marca el título como obligatorio
        [StringLength(200, ErrorMessage = "El título no puede tener más de 200 caracteres.")] // Restringe la longitud del título a 200 caracteres
        public string Title { get; set; } = string.Empty;

        [Range(1880, 2100, ErrorMessage = "El año debe estar comprendido entre 1880 y 2100.")] // Restringe el año entre 1880 y 2100
        public int Year { get; set; } = 0;
        [Range(0.0, 10.0, ErrorMessage = "El rating de IMDB debe ser un valor entre 0 y 10.")] // Restringe el rating entre 0 y 10
        public double ImdbRating { get; set; } = 0.0;
        [StringLength(100, ErrorMessage = "El género no puede superar los 100 caracteres.")]
        public string Genre { get; set; } = string.Empty;

        [StringLength(150, ErrorMessage = "El nombre del director no puede superar los 150 caracteres.")]
        public string Director { get; set; } = string.Empty;

        [Url(ErrorMessage = "El campo Póster debe ser una URL válida (ejemplo: https://sitio.com/imagen.jpg).")] // Valida que el texto sea una dirección web real
        public string Poster { get; set; } = string.Empty;

        public Pelicula() { }

        public Pelicula(string imdbID, string title, int year, double imdbRating, string genre, string director, string poster)
        {
            ImdbID = imdbID;
            Title = title;
            Year = year;
            ImdbRating = imdbRating;
            Genre = genre;
            Director = director;
            Poster = poster;
            Genre = genre;
            Director = director;
        }

        public override string ToString()
        {
            return $"{ImdbID}: {Title} ({Year}) - IMDb Rating: {ImdbRating}, Genre: {Genre}, Director: {Director}";
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
