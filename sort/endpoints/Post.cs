namespace Sort;


/// <summary>
/// Class <c>NumberList</c>
/// </summary>
/// <param name="item">Holds the list of numbers passed by the user - singleton pattern </param>
 public class NumberList
{

    public List<int> Numbers { get; set; }
}

public static class Post {

    public static async Task ListOfIntegers(HttpContext context)

        {
            // TODO: Should validate input

            // *** BOILER PLATE: https://learn.microsoft.com/fr-fr/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-8.0
            var form = await context.Request.ReadFormAsync();
            var numbersString = form["numbers"].ToString();
            var numberList = new NumberList
            {
                Numbers = numbersString.Split(',').Select(int.Parse).ToList()
            };

            if (numberList?.Numbers == null || !numberList.Numbers.Any())
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Invalid input");
                return;
            }
        

            Console.WriteLine("Input Numbers: " + string.Join(", ", numberList.Numbers));
            Util.BubbleSort(numberList.Numbers);
            Util.SaveToCSV(numberList);
            Console.WriteLine("Sorted Numbers: " + string.Join(", ", numberList.Numbers));



            var response = new { SortedNumbers = numberList.Numbers };
            await context.Response.WriteAsJsonAsync(response);
            /// ***


        }
} 