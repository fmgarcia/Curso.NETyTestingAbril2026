

using Azure;
using Azure.AI.TextAnalytics;
using Azure.AI.Translation.Text;
using Microsoft.Recognizers.Text;
using Microsoft.Recognizers.Text.DateTime;
using Microsoft.Recognizers.Text.Sequence;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;

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
    AzureKeyCredential credential = new AzureKeyCredential("BRLMxTWaQAUvoKVfFABOPOu6qX923RJm4gWgVdPkSpQTCyi4hQhBJQQJ99CEAC5T7U2XJ3w3AAAaACOGAg0i"); // Reemplaza con tu clave de API de Azure Cognitive Services. Conecta con tu recurso de Azure Cognitive Services
    TextAnalyticsClient client = new TextAnalyticsClient(endpoint, credential);

    string texto = """
    
    Hola, este es un ejemplo de texto para extraer información. 
    Envía tu factura a facturacion@micorreo.es o escribe a info.123@mi-correo.andalucia.es o llama al +34 123 456 789 o al teléfono 987-654-321. 
    También puedes visitar nuestra página web en https://www.ejemplo.com para más información. Tienes hasta el 31 de diciembre a las 23:59 para aprovechar esta oferta. ¡No te lo pierdas!
    Si llega el día 01-01-2027 y no has aprovechado la oferta, lamentablemente perderás la oportunidad. Recuerda que el número de atención al cliente es 900 123 456 y nuestro correo de soporte es correo@soporte.com.
    Yo me llamo Fran García, y el director de este curso es Antonio Sirvent.
    
    """;

    string texto2 = """
        Comunicación Interna - Incidencias de Migración y RR.HH.
        
        El proceso de migración de la semana pasada fue un desastre total, especialmente cuando intentamos contactar con el responsable técnico, que resulta ser Íñigo de la Torre, aunque en el sistema aparece registrado con el correo i.delatorre+soporte@servicios-it.com.es para temas urgentes. Intenté llamarle a su móvil personal, el +34 600112233, pero saltó un contestador diciendo que ahora su contacto de guardia es María Ángeles Núñez, cuyo número es 914-445-566 y su mail de contacto fuera de la oficina es marian.nunez_88@gmail.com. Lo más preocupante es que me pasó por el chat de la oficina su dirección de casa para enviarle el nuevo router, vive en la Calle de los Alcornocales, nº 12, piso 4ºB (C.P. 28005, Madrid), y no estoy seguro de que esa información deba estar en un canal público.

        Por otro lado, la auditoría de seguridad social ha detectado discrepancias en el expediente SS-99/12345678/01 perteneciente a Ágata Martínez-Sifontes. Ella afirma que su cuenta bancaria para el abono de la nómina cambió el mes pasado al IBAN ES9100491500051234567890, pero el sistema sigue intentando enviar el pago de 2.450,75€ a su antigua cuenta. Además, su DNI, que es el 01234567-X, parece haber caducado según la alerta del portal del empleado. Si alguien necesita validar esto de forma manual, su teléfono de contacto directo es el +44 20 7946 0958, ya que actualmente está desplazada en la oficina de Londres por el proyecto global.

        Finalmente, recordad que las credenciales de acceso temporal para el servidor de testing 192.168.1.254 han sido reseteadas por seguridad. La nueva clave maestra es {Temp_2026!_Access} y solo debe usarla el administrador del sistema, Rubén Úrculo. Si tenéis cualquier duda, podéis escribirle a su correo personal r.urculo_test@yahoo.es o localizarle en la extensión interna ext. 2045 durante el horario de mañana. No olvidéis que el tratamiento de estos datos personales bajo la clave ID-ORD-998877 debe cumplir estrictamente con el cifrado de seguridad que estáis desarrollando para evitar fugas de información sensible.Comunicación Interna - Incidencias de Migración y RR.HH.
        El proceso de migración de la semana pasada fue un desastre total, especialmente cuando intentamos contactar con el responsable técnico, que resulta ser Íñigo de la Torre, aunque en el sistema aparece registrado con el correo i.delatorre+soporte@servicios-it.com.es para temas urgentes. Intenté llamarle a su móvil personal, el +34 600112233, pero saltó un contestador diciendo que ahora su contacto de guardia es María Ángeles Núñez, cuyo número es 914-445-566 y su mail de contacto fuera de la oficina es marian.nunez_88@gmail.com. Lo más preocupante es que me pasó por el chat de la oficina su dirección de casa para enviarle el nuevo router, vive en la Calle de los Alcornocales, nº 12, piso 4ºB (C.P. 28005, Madrid), y no estoy seguro de que esa información deba estar en un canal público.

        Por otro lado, la auditoría de seguridad social ha detectado discrepancias en el expediente SS-99/12345678/01 perteneciente a Ágata Martínez-Sifontes. Ella afirma que su cuenta bancaria para el abono de la nómina cambió el mes pasado al IBAN ES9100491500051234567890, pero el sistema sigue intentando enviar el pago de 2.450,75€ a su antigua cuenta. Además, su DNI, que es el 01234567-X, parece haber caducado según la alerta del portal del empleado. Si alguien necesita validar esto de forma manual, su teléfono de contacto directo es el +44 20 7946 0958, ya que actualmente está desplazada en la oficina de Londres por el proyecto global.

        Finalmente, recordad que las credenciales de acceso temporal para el servidor de testing 192.168.1.254 han sido reseteadas por seguridad. La nueva clave maestra es {Temp_2026!_Access} y solo debe usarla el administrador del sistema, Rubén Úrculo. Si tenéis cualquier duda, podéis escribirle a su correo personal r.urculo_test@yahoo.es o localizarle en la extensión interna ext. 2045 durante el horario de mañana. No olvidéis que el tratamiento de estos datos personales bajo la clave ID-ORD-998877 debe cumplir estrictamente con el cifrado de seguridad que estáis desarrollando para evitar fugas de información sensible.
           
        """;

    // Aquí podrías llamar a los métodos de Azure Text Analytics para extraer la información deseada
    // LLamar a la API de Azure Text Analytics para extraer entidades como correos electrónicos, números de teléfono, URLs, etc. PII (Personally Identifiable Information)
    var response = client.RecognizePiiEntities(texto2, "es");
    Console.WriteLine("Detección de Información Personal (Azure):");
    foreach (var entity in response.Value)
    {
        //if (entity.Category == "Person")
        Console.WriteLine($"- {entity.Text} (Tipo: {entity.Category}, Subtipo: {entity.SubCategory}, Confianza: {entity.ConfidenceScore:P0})");
    }

}


static async Task TraductorLenguajes()
{
    string texto = """
        Hola, este es un ejemplo de texto para extraer información. 
        Envía tu factura a facturacion@micorreo.es o escribe a info.123@mi-correo.andalucia.es o llama al +34 123 456 789 o al teléfono 987-654-321. 
        También puedes visitar nuestra página web en https://www.ejemplo.com para más información. Tienes hasta el 31 de diciembre a las 23:59 para aprovechar esta oferta. ¡No te lo pierdas!
        Si llega el día 01-01-2027 y no has aprovechado la oferta, lamentablemente perderás la oportunidad. Recuerda que el número de atención al cliente es 900 123 456 y nuestro correo de soporte es correo@soporte.com.
        Yo me llamo Fran García, y el director de este curso es Antonio Sirvent.
        """;

    // 1. Configuración de la conexión
    string key = "66uiPPwj1qPhzuN9X93GmhuR0cTj5fPS45lXO3MdbQhTglWv0BLhJQQJ99CEAC5T7U2XJ3w3AAAbACOGNj0S"; // Recuerda poner tu clave real
    string region = "francecentral";
    string endpoint = "https://api.cognitive.microsofttranslator.com";

    // Indicamos a qué idiomas queremos traducir (en = inglés, de = alemán)
    string route = "/translate?api-version=3.0&to=en&to=de";

    // 2. Preparamos el cuerpo de la petición (JSON)
    object[] body = new object[] { new { Text = texto } };
    string requestBody = JsonSerializer.Serialize(body);

    // 3. Hacemos la llamada HTTP
    using (HttpClient client = new HttpClient())
    using (HttpRequestMessage request = new HttpRequestMessage())
    {
        request.Method = HttpMethod.Post;
        request.RequestUri = new Uri(endpoint + route);
        request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        // Cabeceras de seguridad de Azure
        request.Headers.Add("Ocp-Apim-Subscription-Key", key);
        request.Headers.Add("Ocp-Apim-Subscription-Region", region);

        Console.WriteLine("Enviando texto a Azure...");
        HttpResponseMessage response = await client.SendAsync(request);
        string result = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine($"\n[ERROR DE AZURE] Código {response.StatusCode}: {result}");
            return;
        }

        // 4. Procesamos la respuesta JSON nativamente
        using (JsonDocument doc = JsonDocument.Parse(result))
        {
            // Azure devuelve un array, iteramos sobre el primer elemento
            foreach (JsonElement elemento in doc.RootElement.EnumerateArray())
            {
                // Extraer idioma detectado
                if (elemento.TryGetProperty("detectedLanguage", out JsonElement detectedLang))
                {
                    string idioma = detectedLang.GetProperty("language").GetString();
                    double puntuacion = detectedLang.GetProperty("score").GetDouble();
                    Console.WriteLine($"\nIdioma detectado automáticamente: {idioma} (Confianza: {puntuacion:P0})");
                }

                // Extraer traducciones
                if (elemento.TryGetProperty("translations", out JsonElement traducciones))
                {
                    foreach (JsonElement t in traducciones.EnumerateArray())
                    {
                        string destino = t.GetProperty("to").GetString();
                        string textoTraducido = t.GetProperty("text").GetString();

                        Console.WriteLine("\n--------------------------------------------------");
                        Console.WriteLine($" TRADUCCIÓN AL: {destino.ToUpper()}");
                        Console.WriteLine("--------------------------------------------------");
                        Console.WriteLine(textoTraducido);
                    }
                }
            }
        }
    }
}

//EjemploRecognizers();
//ReconocimientoAzure();
await TraductorLenguajes();