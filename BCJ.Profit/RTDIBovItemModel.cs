using BCJ.B3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCJ.Profit
{
	public class RTDIBovItemModel : IBOVItemModel
	{
		private double _PrecoTeorico = 0.0;
		private double _Cotacao = 0.0;
		private double _Fechamento = 0.0;
		private double _VariacaoTeorica = 0.0;
		private double _Variacao = 0.0;

		public double PrecoTeorico { get => _PrecoTeorico; set { _PrecoTeorico = value; RaisePropertyChanged(); } }
		public double Cotacao { get => _Cotacao; set { _Cotacao = value; RaisePropertyChanged(); } }
		public double Fechamento { get => _Fechamento; set { _Fechamento = value; RaisePropertyChanged(); } }
		public double VariacaoTeorica { get => _VariacaoTeorica; set { _VariacaoTeorica = value; RaisePropertyChanged(); } }
		public double Variacao { get => _Variacao; set { _Variacao = value; RaisePropertyChanged(); } }

		public RTDIBovItemModel(string code, string stock, string type, double theoreticalQuantity, double part) : base(code, stock, type, theoreticalQuantity, part)
		{
		}

		public RTDIBovItemModel(IBOVItemModel other) : base(other)
		{
		}
	}
}
