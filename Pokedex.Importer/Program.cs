using Dapper;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Data;

try
{
    string connectionString = "Server=192.168.15.6;Database=pokemonV1;User=root;Password=P@ssw0rd";

    for (int i = 1; i <= 1020; i++)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, $"https://pokeapi.co/api/v2/pokemon/{i}/");
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        string content = await response.Content.ReadAsStringAsync();
        dynamic result = JsonConvert.DeserializeObject(content);

        IDbConnection dbConnection = new MySqlConnection(connectionString);

        dbConnection.Open();
        string query = @"INSERT INTO sprite VALUES (null, @Id, @Url, @CreateDate, @UpdateDate, @Enabled)";
        dbConnection.Execute(query, new
        {
            Id = result.id,
            Url = result.sprites.front_default,
            CreateDate = DateTime.Now,
            UpdateDate = DateTime.Now,
            Enabled = true,
        });

        Console.WriteLine($"{result.id} - {result.name} - Inserido com sucesso");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Erro: {ex.Message}");
    throw;
}