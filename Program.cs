using CsvHelper;
using HtmlAgilityPack;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Collections.Generic;


HtmlWeb web = new HtmlWeb();
HtmlDocument doc = web.Load("https://www.mercadolivre.com.br/ofertas");
var HeaderNames = doc.DocumentNode.SelectNodes("//div[@class='promotion-item__description']");

var titles = new List<Row>();

foreach (var item in HeaderNames)
{     
    var price = item.SelectSingleNode("//div[@class='promotion-item__price-block']");
    var desc = item.SelectSingleNode("//p[@class='promotion-item__title']");
    titles.Add(new Row { Title = desc.InnerText,Prince = price.InnerText });

}

using (var writer = new StreamWriter("C:/Users/Guilherme/Downloads/example.csv"))
using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
{
csv.WriteRecords(titles);
}