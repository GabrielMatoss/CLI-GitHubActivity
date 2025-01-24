

using System.Text.Json;
using System.Text.Json.Nodes;

Console.WriteLine("Digite o nome do usuário:");
var nameUser = Console.ReadLine();

HttpClient httpClient = new HttpClient();
httpClient.DefaultRequestHeaders.Add("User-Agent", "ConsoleApp");
string apiUrl = $"https://api.github.com/users/{nameUser}/events";
Console.WriteLine(apiUrl);
try
{
   HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
    if(response.IsSuccessStatusCode)
    {
      string responseBodyJson = await response.Content.ReadAsStringAsync();
        string formattedJson = FormatJson(responseBodyJson);
        Console.WriteLine("\nResposta da API formatada:");
        //Console.WriteLine(formattedJson);
        foreach(var testes in JsonNode.Parse(formattedJson)!.AsArray())
        {
            Console.WriteLine(testes["type"]);
            var commits = testes["payload"]["commits"].AsArray();
                Console.WriteLine($"Número de commits: {commits.Count}");
        }
    }
    else
    {
        Console.WriteLine($"Erro: {response.StatusCode} - {response.ReasonPhrase}");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Erro ao tentar consumir a API: {ex.Message}");
}

static string FormatJson(string json)
{
    try
    {
        JsonNode parsedJson = JsonNode.Parse(json)!; // Parseia o JSON
        //var teste = JsonSerializer.Serialize(json);
        return parsedJson!.ToJsonString(new JsonSerializerOptions
        {
            WriteIndented = true // Indenta o JSON
        });
    }
    catch
    {
        return json; // Caso dê erro, retorna o JSON original
    }
}