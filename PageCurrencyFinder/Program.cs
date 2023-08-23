using HtmlAgilityPack;
using CsvHelper;
using System.Globalization;
using OpenQA.Selenium;
using System.Net;

namespace PageCurrencyFinder 
{
    public class Program
    {
        // defining a custom class to store the scraped data 

        public static void Main()
        {

            change_values();
            
        }
        public static void change_values()
        {
            WebClient web = new WebClient();
            string html = web.DownloadString("https://www.bestchange.ru/index.php?from=42&to=30");
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            var nodeCollection = doc.DocumentNode.SelectNodes("//*[@id=\"undertable\"]/div[1]/span[1]/span[4]/span");

            if (doc != null)
            {
                foreach (var node in nodeCollection)
                {
                    var ss = node.InnerText; // тут значение
                    Console.WriteLine(ss);
                }
            }
            
        }
    }
}