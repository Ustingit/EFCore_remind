using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore2DBFirst
{
	[Table("Colours")]
	public class ColorReferenceBook
	{
		[Key] // analog modelBuilder.Entity<ColorReferenceBook>().HasKey(u => u.ColorNumber);
		public int ColorNumber { get; set; }

		[Required]
		public int ColorValue { get; set; }
	}
}
