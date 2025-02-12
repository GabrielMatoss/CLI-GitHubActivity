using System.Text.Json;
using CLI.IA.Models;
using CLI.IA.Utils;

Console.WriteLine("Enter the username:");
var nameUser = Console.ReadLine();

HttpClient httpClient = new HttpClient();
httpClient.DefaultRequestHeaders.Add("User-Agent", "ConsoleApp");
string apiUrl = $"https://api.github.com/users/{nameUser}/events";

using HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
ApiVerify.VerifyResponse(response);

if(response.IsSuccessStatusCode)
{
    string responseBodyJson = await response.Content.ReadAsStringAsync();

    try
    {
        var eventObject = JsonSerializer.Deserialize<List<Event>>(responseBodyJson, FormatJson.options);
        
        if (eventObject == null)
            Console.WriteLine("Error deserializing JSON");

        foreach (var eventItem in eventObject?.Take(5)!)
        {
            switch (eventItem.Type)
            {
            case "PushEvent":
                Console.WriteLine($"- Pushed {eventItem.Payload?.Commits?.ToList().Count} to {eventItem.Repo.Name}");
                break;

            case "CreateEvent":
                Console.WriteLine($"- CreateEvent to Repository: {eventItem.Repo.Name}");
                break;

            default:
                Console.WriteLine($"Event type not found: {eventItem.Type}");
                break;
            }
        }
        Console.WriteLine("\n...");
    }
    catch (JsonException ex)
    {
        Console.WriteLine($"Error when deserializing JSON: {ex.Message}");
    }
}