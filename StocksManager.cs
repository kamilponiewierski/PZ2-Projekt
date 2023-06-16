using lab11.Models;

public class StocksManager
{
    public List<Stock> stocks;

    public List<StockData> stockData;
    public StocksManager()
    {
        this.stocks = new List<Stock> {
            new Stock("PKO", "Powszechna Kasa Oszczędności Bank Polski SA", "WSE"),
            new Stock("PKN", "Polski Koncern Naftowy ORLEN SA", "WSE"),
            new Stock("ETFBW20LV.PL", "Beta ETF WIG20lev", "WSE"),
            new Stock("KER", "Kernel Holding SA", "WSE"),
            new Stock("ZEP", "Zespół Elektrowni Pątnów-Adamów-Konin SA", "WSE"),
            new Stock("MNS", "Mennica Skarbowa SA", "NewConnect"),
            new Stock("ZMT", "Zamet Industry SA", "WSE"),
            new Stock("LWB", "Lubelski Węgiel Bogdanka SA", "WSE"),
            new Stock("ASB", "ASBISc Enterprises PLC", "WSE"),
            };

        var parser = new DataParser();
        this.stockData = new List<StockData>() { };
        foreach (var stock in stocks)
        {
            string csvStockName = stock.Ticker.Replace('.', '_').ToLower();
            var data = parser.ParseCsvData($".\\DataSource\\{csvStockName}_d.csv", stock.Ticker);
            stockData.AddRange(data);
        }
    }
}

