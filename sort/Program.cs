namespace Sort;

using Microsoft.AspNetCore.Builder;


//TODO:

// public interface IDatabase {}

public interface IInputReader{
    List<int> ReadInput();
}

public class UserInputReader : IInputReader {
    public List<int> ReadInput() {

        return new List<int> { };
        }
    }


public interface IWebApplicationSetup
    {
        void Configure(WebApplicationBuilder builder);

    }

/// <summary>
/// Class <c>Program</c>
/// </summary>
/// <param name="item">Handles setup,configuration and run</param>
public class Program : IWebApplicationSetup{    
    // private readonly UserInputReader _inputReader;




    
    // TODO: Implement to accept stub - better for testing
    public Program()
    {   
        //  _inputReader = new UserInputReader();

    }

    /// <summary>
    /// Method <c>Run</c> is the method logic.
    /// </summary>
    public void Run() 
    {
 
    }

    /// <summary>
    /// Method <c>Configire</c>  is to configure the endpoints. Can be extended.
    /// </summary>
    public void Configure(WebApplicationBuilder builder)
    {
        // boilerplate 
        var app = builder.Build();

         //*** HTML-FORM GENERATED USING CHATGPT
            app.MapGet("/", async context =>
            {
                var html = @"
                <!DOCTYPE html>
                <html lang='en'>
                <head>
                    <meta charset='UTF-8'>
                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                    <title>Enter Numbers</title>
                </head>
                <body>
                    <h1>Enter Numbers to Sort</h1>
                    <form method='post' action='/post'>
                        <label for='numbers'>Numbers (comma-separated):</label><br>
                        <input type='text' id='numbers' name='numbers'><br><br>
                        <input type='submit' value='Submit'>
                    </form>
                </body>
                </html>";
                await context.Response.WriteAsync(html);
            });
        // ***

        //TODO: Allign with post logic
        // GET endpoints
        app.MapGet("/get", async context =>
        {
            var numbers = Util.ReadFromCSV();
            var response = new { NumbersFromCSV = numbers };
            await context.Response.WriteAsJsonAsync(response);
        });

        // POST endpoints
        app.MapPost("/post", Endpoints.Post.ListOfIntegers);


        // Run the web application, start listening for incoming requests
        app.Run();
    }

    /// <summary>
    /// Method <c>Main</c>  is to the entry-point to the application.
    /// </summary>
    public static void Main(string[] args) {

        var builder = WebApplication.CreateBuilder(args);

        // Create an instance of Program and call the Configure method
        var program = new Program();
        program.Configure(builder);
        program.Run();

    }

}