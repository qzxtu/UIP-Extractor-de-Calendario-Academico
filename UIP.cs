using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Net;
using System.Text;

namespace PDFExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            // La URL del archivo PDF
            string url = "https://uip.edu.pa/wp-content/uploads/2022/12/UIP-WEB-CALENDARIO-ACADEMICO-LIC-TEC-IC-2023.pdf";

            // Descarga el archivo PDF
            WebClient webClient = new();
            byte[] data = webClient.DownloadData(url);

            // Convierte el array de bytes en un stream
            MemoryStream stream = new(data);

            // Abre el stream como un archivo PDF
            PdfReader pdfReader = new(stream);
            PdfReader reader = pdfReader;

            // Obtiene el número de páginas
            int n = reader.NumberOfPages;

            // Crea un StringBuilder para almacenar el texto
            StringBuilder sb = new();

            // Recorre cada página y extrae el texto
            for (int i = 1; i <= n; i++)
            {
                string text = PdfTextExtractor.GetTextFromPage(reader, i);
                sb.Append(text);
            }

            // Cierra el archivo PDF
            reader.Close();

            // Muestra el texto extraído en la consola
            Console.WriteLine(sb.ToString());
        }
    }
}
