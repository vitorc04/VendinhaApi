using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using VendinhaApi.Models;

namespace VendinhaApi.Data.Map
{
	public class DividaMap : IEntityTypeConfiguration<Divida>
	{
		public void Configure(EntityTypeBuilder<Divida> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Value).IsRequired();
			builder.Property(x => x.Paid).IsRequired();
			builder.Property(x => x.CreationDate).IsRequired();
			builder.Property(x => x.PaymentDate);
			builder.Property(x => x.ClienteId).IsRequired();

			builder.HasOne(x => x.cliente);


		}
	}
}
