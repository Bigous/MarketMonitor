using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BCJ.B3
{
	public class IBovStocks
	{
		private double theoreticalQuantity;
		private double reductor;
		private DateTime fromWhen;
		public List<IBOVItemModel> Stocks = new List<IBOVItemModel>();

		private static readonly string url = "https://sistemaswebb3-listados.b3.com.br/indexProxy/indexCall/GetDownloadPortfolioDay/eyJpbmRleCI6IklCT1YiLCJsYW5ndWFnZSI6ImVuLXVzIn0=";
		private static readonly string regexFrom = ".+(\\d\\d/\\d\\d/\\d\\d)";

		public double TheoreticalQuantity
		{
			get => theoreticalQuantity;
		}
		public double Reductor
		{
			get => reductor;
		}

		public DateTime FromWhen
		{
			get => fromWhen;
		}

		private IBovStocks() { }

		/// <summary>
		/// Loads all the IBOV composition information and generates an IBOV object.
		/// </summary>
		/// <returns>Ans IBOV object</returns>
		public async static Task<IBovStocks> LoadIBOVStocks()
		{
			IBovStocks ibl = new();
			using (var httpClient = new HttpClient())
			{
				string content = await httpClient.GetStringAsync(url);
				byte[] csv = Convert.FromBase64String(content);
				var sr = new StreamReader(new MemoryStream(csv));
				string information = sr.ReadLine() ?? "";

				string from = Regex.Match(information, regexFrom).Groups[1].Value;

				ibl.fromWhen = DateTime.Parse(from, CultureInfo.InvariantCulture);

				string[] headers = (sr.ReadLine() ?? "").Split(",");

				while (!sr.EndOfStream)
				{
					string[] row = Regex.Split((sr.ReadLine() ?? ""), ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

					if (row[0] == "Reductor")
					{
						ibl.reductor = double.Parse(row[3], CultureInfo.InvariantCulture);
					}
					else if (row[0] == "Total Theorethical Quantity")
					{
						ibl.theoreticalQuantity = double.Parse(row[3], CultureInfo.InvariantCulture);
					}
					else
					{
						IBOVItemModel stock = new IBOVItemModel();
						for (int i = 0; i < headers.Length; i++)
						{
							switch (headers[i])
							{
								case "Theoretical Quantity":
									stock.TheoreticalQuantity = double.Parse(row[i], CultureInfo.InvariantCulture);
									break;
								case "Part. (%)":
									stock.Part = double.Parse(row[i], CultureInfo.InvariantCulture);
									break;
								case "Type":
									stock.Type = row[i];
									break;
								case "Stock":
									stock.Stock = row[i];
									break;
								case "Code":
									stock.Code = row[i];
									break;
							}
						}
						ibl.Stocks.Add(stock);
					}
				}
			}
			return ibl;
		}
	}
}
