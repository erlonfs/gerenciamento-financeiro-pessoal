using System;

namespace SharedKernel.Common
{
	public class Ano : ValueObject<Ano>
	{
		public int Numero { get; private set; }

		public Ano(int numero)
		{
			if (numero.ToString().Length > 4) throw new ArgumentOutOfRangeException(nameof(numero));
			Numero = numero;
		}
	}
}
