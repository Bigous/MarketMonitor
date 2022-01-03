using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BCJ.B3
{
	public class IBOVItemModel : NotifyedModel
	{
		private string _Code;
		private string _Stock;
		private string _Type;
		private double _TheoreticalQuantity;
		private double _Part;

		public string Code { get => _Code; set { _Code = value; RaisePropertyChanged(); } }
		public string Stock { get => _Stock; set { _Stock = value; RaisePropertyChanged(); } }
		public string Type { get => _Type; set { _Type = value; RaisePropertyChanged(); } }
		public double TheoreticalQuantity { get => _TheoreticalQuantity; set { _TheoreticalQuantity = value; RaisePropertyChanged(); } }
		public double Part
		{
			get => _Part; set
			{
				_Part = value;
				RaisePropertyChanged(nameof(Part));
			}
		}

		public IBOVItemModel(string code = "", string stock = "", string type = "", double theoreticalQuantity = 0.0, double part = 0.0) : base()
		{
			_Code = code;
			_Stock = stock;
			_Type = type;
			_TheoreticalQuantity = theoreticalQuantity;
			_Part = part;
		}

		public IBOVItemModel(IBOVItemModel other) : this(other.Code, other.Stock, other.Type, other.TheoreticalQuantity, other.Part)
		{
		}
	}
}
