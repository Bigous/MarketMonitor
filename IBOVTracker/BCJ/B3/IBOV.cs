using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BCJ.B3
{
	/// <summary>
	/// Loads and hold the IBOV's composition information directly from B3 web site.
	/// </summary>
	public class IBOV : IDisposable
	{
		private double theoreticalQuantity;
		private double reductor;
		private DateTime fromWhen;
		private readonly DataTable dt;

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

		public DataTable Data
		{
			get => dt;
		}

		/// <summary>
		/// The constructor is private for security reasons. If you have an IBOV object outside this class, it's always populated.
		/// </summary>
		private IBOV()
		{
			dt = new DataTable();
		}

		/// <summary>
		/// Loads all the IBOV composition information and generates an IBOV object.
		/// </summary>
		/// <returns>Ans IBOV object</returns>
		public async static Task<IBOV> LoadIBOV()
		{
			IBOV ibl = new();
			using (var httpClient = new HttpClient())
			{
				string content = await httpClient.GetStringAsync(url);
				byte[] csv = Convert.FromBase64String(content);
				var sr = new StreamReader(new MemoryStream(csv));
				string information = sr.ReadLine() ?? "";

				string from = Regex.Match(information, regexFrom).Groups[1].Value;

				ibl.fromWhen = DateTime.Parse(from, CultureInfo.InvariantCulture);

				string[] headers = (sr.ReadLine() ?? "").Split(",");

				foreach (string header in headers)
				{
					ibl.dt.Columns.Add(header, header switch
					{
						"Theoretical Quantity" => typeof(double),
						"Part. (%)" => typeof(double),
						_ => typeof(string)
					});
				}
				while (!sr.EndOfStream)
				{
					string[] row = Regex.Split( (sr.ReadLine() ?? ""), ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

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
						DataRow dr = ibl.dt.NewRow();
						for (int i = 0; i < headers.Length && i < row.Length; i++)
						{
							dr[i] = headers[i] switch
							{
								"Theoretical Quantity" => double.Parse(row[i], CultureInfo.InvariantCulture),
								"Part. (%)" => double.Parse(row[i], CultureInfo.InvariantCulture),
								_ => row[i]
							};
						}
						ibl.dt.Rows.Add(dr);
					}
				}
			}
			return ibl;
		}

		#region IDisposable
		private bool isDisposed = false;
		public void Dispose()
		{
			lock (this)
			{
				if (isDisposed) return;
				isDisposed = true;
			}
			dt.Dispose();
			GC.SuppressFinalize(this);
		}
		#endregion
	}
}