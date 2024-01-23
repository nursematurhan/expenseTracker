using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace ExpenseTracker.Controllers
{
    public class ExchangeController : Controller
    {

        public IActionResult Index()
        {
            string link = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(link);

            var responseData = new ResponseData();
            responseData.Data = new List<ResponseDataRate>();

            var currencies = xmlDoc.SelectNodes("Tarih_Date/Currency");

            foreach (XmlNode currencyNode in currencies)
            {
                var currencyCode = currencyNode.Attributes["Kod"].Value;

                // Sadece belirli döviz kodlarını filtrele
                if (currencyCode == "USD" || currencyCode == "EUR" || currencyCode == "GBP")
                {
                    var rate = new ResponseDataRate();
                    rate.Code = currencyCode;
                    // Bu düğümün değeri boş değilse ve sayısal bir formatta ise
                    if (!string.IsNullOrWhiteSpace(currencyNode.SelectSingleNode("BanknoteBuying").InnerText) &&
                        decimal.TryParse(currencyNode.SelectSingleNode("BanknoteBuying").InnerText.Replace(".", ","), out decimal buyingRate))
                    {
                        rate.BuyingRate = buyingRate;
                    }
                    else
                    {
                        rate.BuyingRate = 0; // Veya başka bir varsayılan değer
                    }

                    if (!string.IsNullOrWhiteSpace(currencyNode.SelectSingleNode("BanknoteSelling").InnerText) &&
                        decimal.TryParse(currencyNode.SelectSingleNode("BanknoteSelling").InnerText.Replace(".", ","), out decimal sellingRate))
                    {
                        rate.SellingRate = sellingRate;
                    }
                    else
                    {
                        rate.SellingRate = 0; // Veya başka bir varsayılan değer
                    }

                    responseData.Data.Add(rate);
                }
            }

            return View(responseData);
        }



    }
}
