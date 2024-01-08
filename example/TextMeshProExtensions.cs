using System;
using TMPro;

namespace Switchboard
{
	public static class TextMeshProExtensions
	{
		private static char[] StaticBuffer => _buffer ??= new char[StringMaker.MaxCapacity];
		private static char[] _buffer;

		public static void SetText(this TMP_Text textComponent, StringMaker stringMaker)
		{
			SetText(textComponent, stringMaker, null);
		}

		public static void SetText(this TMP_Text textComponent, StringMaker stringMaker, char[] buffer)
		{
			if(textComponent == null)
				throw new ArgumentNullException(nameof(textComponent));

			if(stringMaker == null)
				throw new ArgumentNullException(nameof(stringMaker));

			buffer ??= StaticBuffer;

			if(buffer.Length < stringMaker.Length)
				throw new ArgumentException($"The {nameof(buffer)} is not long enough.", nameof(buffer));

			if(!stringMaker.Equals(textComponent.text))
			{
				stringMaker.CopyTo(new Span<char>(buffer));
				textComponent.SetCharArray(buffer, 0, stringMaker.Length);
			}
		}
	}
}
