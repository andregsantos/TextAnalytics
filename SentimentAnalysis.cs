using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;

namespace AnaliseSentimentos
{
    public static class SentimentAnalysis
    {
        private static string Classification(double? score)
        {
            double v = score.HasValue ? score.Value : 0.0;

            if (v > 0.5)
                return "Sentimento bom";
            else if (v <= 0.5)
                return "Sentimento Ruim";

            return "";
        }

        public static async Task RunAsync(string endpoint, string key, string text)
        {
            var credentials = new ApiKeyServiceClientCredentials(key);

            var client = new TextAnalyticsClient(credentials)
            {
                Endpoint = endpoint
            };

            var inputDocuments = new MultiLanguageBatchInput(
            new List<MultiLanguageInput>
            {
                new MultiLanguageInput(Guid.NewGuid().ToString(), text, "pt")
            });

            var result = await client.SentimentBatchAsync(inputDocuments);

            foreach (var document in result.Documents)
            {
                Console.WriteLine($"Seu sentimento é {Classification(document.Score)}");
            }

            Console.WriteLine();
        }
    }
}
