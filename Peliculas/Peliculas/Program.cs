namespace Peliculas
{
    internal class Program
    {

        static string KEY = "892e624f";
        static int NUMERO_PELICULAS = 100;
        static int IMDB_ID_INICIAL = 16;




        static async Task CargaInicial()
        {
            await UtilidadesImdb.PoblarBaseDatosImdbAsync(IMDB_ID_INICIAL, NUMERO_PELICULAS, KEY);
            Console.WriteLine("Peliculas cargadas correctamente");

        }

        static async Task MejorPeliculaPorGenero()
        {
            Console.WriteLine("Géneros:");
            await UtilidadesImdb.MejorPeliculaPorGeneroAsync();

        }

        static async Task LLamarDirectorConMasPeliculas()
        {
            await UtilidadesImdb.DirectorConMasPeliculas();
        }

        static async Task Main(string[] args)
        {
            //await CargaInicial();
            await MejorPeliculaPorGenero();
            await LLamarDirectorConMasPeliculas();
        }
    }
}
