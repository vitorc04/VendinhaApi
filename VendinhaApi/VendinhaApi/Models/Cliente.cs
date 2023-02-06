using System.ComponentModel.DataAnnotations;

namespace VendinhaApi.Models
{
	public class Cliente
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string CPF { get; set; }
		public DateTime DataNascimento { get; set; }
		public int Idade
		{
			get
			{
				int idade = 0;
				idade = DateTime.Now.Year - DataNascimento.Year;
				if (DateTime.Now.DayOfYear < DataNascimento.DayOfYear)
					idade = idade - 1;
				return idade;
			}
		}
		public string? Email { get; set; }
		public ICollection<Divida> dividas { get;}
	}
}
