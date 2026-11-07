
using System.Globalization;

string salesDirectory = Path.Combine(
    Directory.GetCurrentDirectory(),
    "Sales"
);

string[] salesFiles = Directory.GetFiles(salesDirectory, "*.txt");

decimal totalSales = 0;

Console.WriteLine("========== SALES SUMMARY ==========\n");

foreach (string file in salesFiles)
{
    decimal fileTotal = 0;

    string[] lines = File.ReadAllLines(file);

    foreach (string line in lines)
    {
        if (decimal.TryParse(
            line,
            NumberStyles.Number,
            CultureInfo.InvariantCulture,
            out decimal amount))
        {
            fileTotal += amount;
        }
    }

    totalSales += fileTotal;

    Console.WriteLine(
        $"{Path.GetFileName(file)}: ${fileTotal:F2}"
    );
}

Console.WriteLine("\n----------------------------------");
Console.WriteLine($"TOTAL SALES: ${totalSales:F2}");

string reportPath = Path.Combine(
    salesDirectory,
    "sales_summary.txt"
);

string report = $"Sales Summary\n\n" +
                $"Total Sales: ${totalSales:F2}\n\n" +
                "Details:\n";

foreach (string file in salesFiles)
{
    decimal fileTotal = File.ReadAllLines(file)
        .Select(line =>
            decimal.TryParse(
                line,
                NumberStyles.Number,
                CultureInfo.InvariantCulture,
                out decimal amount)
                ? amount
                : 0)
        .Sum();

    report += $"{Path.GetFileName(file)}: ${fileTotal:F2}\n";
}

File.WriteAllText(reportPath, report);

Console.WriteLine($"\nReport saved at: {reportPath}");
