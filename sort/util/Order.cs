namespace Sort;
/// <summary>
/// Class <c>Util</c>
/// </summary>
/// <param name="item">Utility class - singleton pattern</param>
public static class Util{
    public static void BubbleSort(List<int> numbers)
        {
        int n = numbers.Count;
        bool swapped;

        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;

            // sort unsorted 'portion': n - i - 1
            for (int j = 0; j < n - i - 1; j++)
            {
                // curr > next
                if (numbers[j] > numbers[j + 1])
                {
                    // swap current and next
                    int temp = numbers[j];
                    numbers[j] = numbers[j + 1];
                    numbers[j + 1] = temp;
                    swapped = true;
                }
            }

            // no sorting needed - early exit
            if (!swapped)
                break;
        }
    }

    public static void QuickSort() {
        // TODO: Implement quicksort

    }
    public static void SaveToCSV(NumberList numberList) {
            // TODO: add to database instead and support other formats
            
            var csvFilePath = "data/sorted_numbers.csv";
            // check if file exists and append
            using (var writer = new StreamWriter(csvFilePath, append: true))
            
            {
                writer.WriteLine(string.Join(",", numberList.Numbers));
            }
    }

    public static List<int> ReadFromCSV(){
        
        var csvFilePath = "data/sorted_numbers.csv";
        // TODO: Move out to csv paths are the same
    
        if (!File.Exists(csvFilePath))
        {
        Console.WriteLine("File does not exist.");
        return new List<int>();
        }

        /// using LINQ *** FROM https://learn.microsoft.com/en-us/dotnet/csharp/linq/how-to-query-files-and-directories
        return File.ReadAllLines(csvFilePath)
                .SelectMany(line => line.Split(','))
                    .Where(value => int.TryParse(value, out _))
                    .Select(int.Parse)
                .ToList();
                
        /// ***


    }




}