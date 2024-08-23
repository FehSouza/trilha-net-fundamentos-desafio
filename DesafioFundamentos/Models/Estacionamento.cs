namespace DesafioFundamentos.Models
{
	public class Estacionamento
	{
		private decimal precoInicial = 0;
		private decimal precoPorHora = 0;
		private List<string> veiculos = new List<string>();

		public Estacionamento(decimal precoInicial, decimal precoPorHora)
		{
			this.precoInicial = precoInicial;
			this.precoPorHora = precoPorHora;
		}

		public void AdicionarVeiculo()
		{
			Console.WriteLine("Digite a placa do veículo para estacionar:");
			string placa = Console.ReadLine();
			bool digitouPlaca = placa.Length != 0;
			bool existePlaca = veiculos.Any(x => x.ToUpper() == placa.ToUpper());

			if (!digitouPlaca) Console.WriteLine("Veículo não estacionado... A placa digitada não possui um valor válido!");

			if (digitouPlaca && existePlaca) Console.WriteLine("Esse veículo já está estacionado aqui!");

			if (digitouPlaca && !existePlaca)
			{
				veiculos.Add(placa);
				Console.WriteLine("Veículo estacionado!");
			}
		}

		public void RemoverVeiculo()
		{
			bool temVeiculos = veiculos.Any();

			if (temVeiculos)
			{
				Console.WriteLine("Digite a placa do veículo para remover:");
				string placa = Console.ReadLine();
				bool digitouPlaca = placa.Length != 0;
				int indexPlaca = veiculos.FindIndex(veiculo => veiculo.ToUpper() == placa.ToUpper());

				if (!digitouPlaca) Console.WriteLine("Veículo não estacionado... A placa digitada não possui um valor válido!");

				if (digitouPlaca && indexPlaca != -1)
				{
					Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
					_ = double.TryParse(Console.ReadLine().Replace(".", ","), out double horasDigitada);

					int horas = Convert.ToInt32(Math.Ceiling(horasDigitada));
					decimal valorTotal = precoInicial + precoPorHora * horas;

					veiculos.RemoveAt(indexPlaca);
					Console.WriteLine($"O preço inicial cadastrado foi R$ {precoInicial.ToString("0.00")}\n" +
						$"O preço por hora cadastrado foi R$ {precoPorHora.ToString("0.00")}\n" +
						$"O veículo ficou estacionado por {horasDigitada} horas, e para o cálculo do preço foram consideradas {horas} horas\n" +
						$"O veículo {placa} foi removido e o preço total foi de R$ {valorTotal.ToString("0.00")}");
				}

				if (digitouPlaca && indexPlaca == -1) Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
			}

			if (!temVeiculos) Console.WriteLine("Não há veículos estacionados.");
		}

		public void ListarVeiculos()
		{
			bool temVeiculos = veiculos.Any();

			// Verifica se há veículos no estacionamento
			if (temVeiculos)
			{
				Console.WriteLine("Os veículos estacionados são:");
				foreach (string veiculo in veiculos) Console.WriteLine(veiculo);
			}

			if (!temVeiculos) Console.WriteLine("Não há veículos estacionados.");
		}
	}
}
