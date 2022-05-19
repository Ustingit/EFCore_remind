using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore2DBFirst.Configurations
{
	public sealed class ColorReferenceBookConfiguration : IEntityTypeConfiguration<ColorReferenceBook>
	{
		public void Configure(EntityTypeBuilder<ColorReferenceBook> builder)
		{
			builder.HasCheckConstraint("ColorValue", "ColorValue > 0 AND ColorValue < 567675");
		}
	}
}
