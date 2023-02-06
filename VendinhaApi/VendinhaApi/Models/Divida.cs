using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VendinhaApi.Models
{
	public class Divida
	{
		public int Id { get; set; }
		public decimal Value { get; set; }
		public bool Paid { get; set; }
		public DateTime CreationDate { get; set; }
		public DateTime? PaymentDate { get; set; }
		public int ClienteId { get; set; }

		public virtual Cliente? cliente { get; set; }
	}
}
