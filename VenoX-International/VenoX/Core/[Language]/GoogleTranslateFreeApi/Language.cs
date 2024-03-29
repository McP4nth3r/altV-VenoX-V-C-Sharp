﻿using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace VenoX.Core._Language_.GoogleTranslateFreeApi
{
	[DataContract]
	public partial class Language
	{
		/// <summary>
		/// Language name ( doesn't affect anything )
		/// </summary>
		[DataMember]
		public string FullName { get; }

		/// <summary>
		/// ISO639  table: <see href="http://stnsoft.com/Muxman/mxp/ISO_639.html"/>
		/// </summary>
		[DataMember]
		public string Iso639 { get; }

		static Language()
		{
			Auto = new Language("Automatic", "auto");

			var languages = typeof(Language).GetRuntimeProperties().Where(i => i.IsDefined(typeof(LanguageAttribute)));

			foreach (PropertyInfo language in languages)
			{
				LanguageAttribute languageAttribute = language.GetCustomAttribute<LanguageAttribute>();

				language.SetValue(null, new Language(languageAttribute.FullName, languageAttribute.Iso639));
			}
		}

		/// <summary>
		/// Creates new Language
		/// </summary>
		/// <param name="fullName">Language full name (set what do you want) </param>
		/// <param name="iso639">ISO639 value</param>
		public Language(string fullName, string iso639)
		{
			FullName = fullName;
			Iso639 = iso639;
		}

		protected bool Equals(Language other)
		{
			return string.Equals(Iso639, other.Iso639, StringComparison.OrdinalIgnoreCase);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != GetType()) return false;
			
			return Equals((Language) obj);
		}

		public override int GetHashCode()
		{
			return StringComparer.OrdinalIgnoreCase.GetHashCode(Iso639);
		}

		public override string ToString()
		{
			return $"FullName: {FullName}, ISO639: {Iso639}";
		}
	}
}
