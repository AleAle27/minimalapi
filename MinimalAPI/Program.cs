
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();


// INDEX SIN PARÁMETROS

app.MapGet("/", () => "Hello World!");



// PÁGINA "hola", REQUIERE DE LA VARIABLE "nombre" EN LA URL PARA FUNCIONAR
//SINO, DEVUELVE -> BadHttpRequestException
// EJEMPLO URL https://localhost:7228/hola?nombre=Moises

app.MapGet("/hola", (string nombre) => $"Hola {nombre}");



// PÁGINA "hola" CON PARÁMETROS EN URL
//PUEDE SER UNO O VARIOS
// EJEMPLO URL https://localhost:7228/hola2/Isaac/Gutierrez

app.MapGet("/hola2/{nombre}/{apellido}", (string nombre, string apellido) => $"Hola {nombre} {apellido}");



// USANDO MÉTODOS ASINCRONOS PARA OBTENER Y DEVOLVER UNA RESPUESTA JSON
// EJEMPLO URL ttps://localhost:7228/response

app.MapGet("/response", async () =>
{
    HttpClient client = new();
    var response = await client.GetAsync("https://jsonplaceholder.typicode.com/todos/");

    response.EnsureSuccessStatusCode();

    string responseBody = await response.Content.ReadAsStringAsync();
    return responseBody;
});

app.Run();
