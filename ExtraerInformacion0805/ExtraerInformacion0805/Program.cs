

using Microsoft.Recognizers.Text;
using Microsoft.Recognizers.Text.Sequence;
using Microsoft.Recognizers.Text.DateTime;
using Azure;
using Azure.AI.TextAnalytics;

static void EjemploRecognizers()
{
    string texto = """
    
    Hola, este es un ejemplo de texto para extraer información. 
    Envía tu factura a facturacion@micorreo.es o escribe a info.123@mi-correo.andalucia.es o llama al +34 123 456 789 o al teléfono 987-654-321. 
    También puedes visitar nuestra página web en https://www.ejemplo.com para más información. Tienes hasta el 31 de diciembre a las 23:59 para aprovechar esta oferta. ¡No te lo pierdas!
    Si llega el día 01-01-2027 y no has aprovechado la oferta, lamentablemente perderás la oportunidad. Recuerda que el número de atención al cliente es 900 123 456 y nuestro correo de soporte es correo@soporte.com
    
    """;

    string cultura = Culture.Spanish;  // Usamos la cultura española para el reconocimiento

    // Extraer correos electrónicos
    var correos = SequenceRecognizer.RecognizeEmail(texto, cultura);
    Console.WriteLine("Correos electrónicos encontrados:");
    foreach (var email in correos)
    {
        Console.WriteLine($"- {email.Text}");
    }

    // Extraer números de teléfono
    var telefonos = SequenceRecognizer.RecognizePhoneNumber(texto, cultura);
    Console.WriteLine("Números de teléfono encontrados:");
    foreach (var telefono in telefonos)
    {
        Console.WriteLine($"- {telefono.Text}");
    }

    // Extraer URLs
    var urls = SequenceRecognizer.RecognizeURL(texto, cultura);
    Console.WriteLine("URLs encontradas:");
    foreach (var url in urls)
    {
        Console.WriteLine($"- {url.Text}");
    }

    // Extraer fechas y horas
    var fechas = DateTimeRecognizer.RecognizeDateTime(texto, cultura);
    Console.WriteLine("Fechas y horas encontradas:");
    foreach (var fecha in fechas)
    {
        Console.WriteLine($"- {fecha.Text}");
    }
}

static void ReconocimientoAzure()
{
    // Aquí podrías implementar el reconocimiento de información utilizando Azure Cognitive Services
    // Por ejemplo, podrías usar Azure Text Analytics para extraer entidades como correos electrónicos, números de teléfono, URLs, etc.
    // Sin embargo, esto requeriría configurar una cuenta de Azure y obtener las claves de API necesarias.
    Uri endpoint = new Uri("https://reconocimentolenguaje.cognitiveservices.azure.com/"); // Conecta con tu recurso de Azure Cognitive Services 
    AzureKeyCredential credential = new AzureKeyCredential("XXXX"); // Reemplaza con tu clave de API de Azure Cognitive Services. Conecta con tu recurso de Azure Cognitive Services
    TextAnalyticsClient client = new TextAnalyticsClient(endpoint, credential);

    string texto = """
    
    Hola, este es un ejemplo de texto para extraer información. 
    Envía tu factura a facturacion@micorreo.es o escribe a info.123@mi-correo.andalucia.es o llama al +34 123 456 789 o al teléfono 987-654-321. 
    También puedes visitar nuestra página web en https://www.ejemplo.com para más información. Tienes hasta el 31 de diciembre a las 23:59 para aprovechar esta oferta. ¡No te lo pierdas!
    Si llega el día 01-01-2027 y no has aprovechado la oferta, lamentablemente perderás la oportunidad. Recuerda que el número de atención al cliente es 900 123 456 y nuestro correo de soporte es correo@soporte.com
    
    """;


}

//EjemploRecognizers();