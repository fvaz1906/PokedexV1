var client = new HttpClient();
var request = new HttpRequestMessage(HttpMethod.Get, "https://pokeapi.co/api/v2/pokemon/1/");
var response = await client.SendAsync(request);
response.EnsureSuccessStatusCode();
Console.WriteLine(await response.Content.ReadAsStringAsync());