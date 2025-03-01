using Azure;
using Azure.AI.Service.Text.Options;
using Azure.AI.TextAnalytics;
using Microsoft.Extensions.Logging;

namespace azure.ai.service.text;

public interface IDetectLanguageService
{
    string GetLanguage(string text);
}

public class DetectLanguageService : IDetectLanguageService
{
    private readonly AIServiceOption _options;

    public DetectLanguageService(AIServiceOption options)
    {
        ArgumentNullException.ThrowIfNull(options);

        _options = options;
    }

    public string GetLanguage(string text)
    {
        // Create client using endpoint and key
        AzureKeyCredential credentials = new AzureKeyCredential(_options.Key);
        Uri endpoint = new Uri(_options.Endpoint);
        var client = new TextAnalyticsClient(endpoint, credentials);

        // Call the service to get the detected language
        DetectedLanguage detectedLanguage = client.DetectLanguage(text);
        return detectedLanguage.Name;
    }
}