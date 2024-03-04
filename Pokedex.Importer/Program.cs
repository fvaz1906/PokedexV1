using Dapper;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Data;



try
{
    string connectionString = "Server=mysql.oovaz.com.br;Database=oovaz03;User=oovaz03;Password=9eOvJd38l7WcHOPfSV";
    IDbConnection dbConnection = new MySqlConnection(connectionString);
    dbConnection.Open();
    var types = dbConnection.Query("SELECT * FROM pokemon_type");

    //foreach (var item in types)
    //{
    //    Console.WriteLine(item.type);
    //}

    for (int i = 2; i <= 1020; i++)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, $"https://pokeapi.co/api/v2/pokemon/{i}/");
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        string content = await response.Content.ReadAsStringAsync();
        dynamic? result = JsonConvert.DeserializeObject(content);

        foreach (var item in result.types)
        {
            string typeName = item.type.name;
            string query = @"INSERT INTO rel_pokemon_type VALUES (null, @PokemonId, @PokemonTypeId, @CreateDate, @UpdateDate, @Enabled)";
            var type = types.Where(t => t.type == typeName).FirstOrDefault();

            dbConnection.Execute(query, new
            {
                PokemonId = i,
                PokemonTypeId = type.id,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                Enabled = true,
            });

            Console.WriteLine($"Tipo: {item.type.name} - Inserido para Pokemon {i}");
        }

        //Console.WriteLine($"{result.id} - {result.name} - Inserido com sucesso");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Erro: {ex.Message}");
    throw;
}