using CsvHelper;
using CsvHelper.Configuration;
using lab11.Models;
using System.Globalization;
using System.IO;

// ...

public class DataParser
{
    public List<StockData> ParseCsvData(string csvFilePath, string ticker)
    {
        using (var reader = new StreamReader(csvFilePath))
        {
            var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ","
            };

            using (var csv = new CsvReader(reader, csvConfiguration))
            {
                var records = csv.GetRecords<StockDataCsv>().ToList();
                var stockData = new List<StockData>() {};
                foreach (var record in records)
                {
                    stockData.Add(new StockData(ticker, record));
                }
                return stockData;
            }
        }
    }

}