using System;

namespace AnaliseSentimentos
{
    public class Program
    {
        static void Main(string[] args)
        {
            string endpoint = "https://textanalytics333268.cognitiveservices.azure.com/";
            string subscriptionKey = "5e1397eb34584a54bf503bafd9eb6675";

            Console.WriteLine("Entre com o texto a ser análisado:");

            string text = Console.ReadLine();

            SentimentAnalysis.RunAsync(endpoint, subscriptionKey, text).Wait();

            Console.ReadKey();
        }
    }
}
