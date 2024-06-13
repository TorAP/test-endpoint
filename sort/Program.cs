namespace Sort;

using Microsoft.AspNetCore.Builder;


public interface IDatabase 
{
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
    
    public Program()
    {   
    }

    /// <summary>
    /// Method <c>Run</c> is the method logic .
    /// </summary>
    public void Run() 
    {
 
    }

    /// <summary>
    /// Method <c>Configire</c>  is to configure the endpoints. Can be extended.
    /// </summary>
    public void Configure(WebApplicationBuilder builder)
    {
        //boilerplate 
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

        // GET endpoints
        app.MapGet("/hi", () => "Hello World!");

        //POST endpoints
        app.MapPost("/post", Post.ListOfIntegers);


        // Run the web application, start listening for incoming requests
        app.Run();
    }

    /// <summary>
    /// Method <c>Main</c>  is to the entry-point to the application .
    /// </summary>
    public static void Main(string[] args) {

        var builder = WebApplication.CreateBuilder(args);

        // Create an instance of Program and call the Configure method
        var program = new Program();
        program.Configure(builder);
        program.Run();

    }

}