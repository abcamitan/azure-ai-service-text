using Microsoft.Extensions.Logging;

namespace azure.ai.service.text;
public class UserInput
{
    private readonly IDetectLanguageService _service;
    private readonly ILogger _logger;

    public UserInput(IDetectLanguageService service, ILogger<UserInput> logger)
    {
        ArgumentNullException.ThrowIfNull(service);
        ArgumentNullException.ThrowIfNull(logger);

        _service = service;
        _logger = logger;
    }

    public void Run()
    {
        try
        {
            // Get user input (until they enter "quit")
            string userText = "";
            while (userText.ToLower() != "quit")
            {
                Console.WriteLine("\nEnter some text ('quit' to stop)");
                userText = Console.ReadLine()!;
                if (userText!.ToLower() != "quit")
                {
                    _logger.LogInformation("User entered: {userText} ", userText);
                    // Call function to detect language
                    string language = _service.GetLanguage(userText);
                    Console.WriteLine("Language: " + language);
                }

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            _logger.LogError(ex, "Error in UserInput.Run");
        }
    }
}