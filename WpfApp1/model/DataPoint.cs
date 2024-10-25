using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_an.model
{
	internal class DataPoint
	{
		public float Value { get; set; }
		public string Label { get; set; }

		public DataPoint(float value, string label)
		{
			Value = value;
			Label = label;
		}
	}
}
