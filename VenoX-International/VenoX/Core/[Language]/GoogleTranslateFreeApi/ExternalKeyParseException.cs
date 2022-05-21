using System;

namespace VenoX.Core._Language_.GoogleTranslateFreeApi
{
	class ExternalKeyParseException : Exception
	{
		public ExternalKeyParseException()
			:this("External key parse failed") { }

		public ExternalKeyParseException(string message)
			:base(message) { }
	}
}
