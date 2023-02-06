using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendinhaApi.Models;

namespace VendinhaApi.Data.Map
{
	public class ClienteMap : IEntityTypeConfiguration<Cliente>
	{
		public void Configure(EntityTypeBuilder<Cliente> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Nome).IsRequired();
			builder.Property(x => x.CPF).IsRequired();
			builder.Property(x => x.DataNascimento).IsRequired();
		}
	}
}
