namespace Peliculas
{
    internal class Program
    {

        static string KEY = "892e624f";
        static int NUMERO_PELICULAS = 5;
        static int IMDB_ID_INICIAL = 1;




        static void CargaInicial()
        {
            UtilidadesImdb.PoblarBaseDatosImdb(IMDB_ID_INICIAL, NUMERO_PELICULAS, KEY);

        }

        static void Main(string[] args)
        {
            CargaInicial();
        }
    }
}
