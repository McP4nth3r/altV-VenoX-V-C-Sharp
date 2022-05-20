﻿using System;

namespace VenoX.Core._Language_.GoogleTranslateFreeApi
{
	class LanguageIsNotSupportedException: Exception
	{
		public readonly Language Language;

		public LanguageIsNotSupportedException(Language language)
			:base("Language is not supported by GoogleTranslate:")
		{
			Language = language;
		}

		public override string Message => base.Message + " " + Language;
	}
}
