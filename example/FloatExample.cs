using System;
using Switchboard;
using UnityEngine;
using ILogger = Switchboard.ILogger;

namespace SwitchboardExample
{
	public class FloatExample : MonoBehaviour
	{
		private ILogger Logger;

		private void OnEnable()
		{
			// Get Logger
			IInjector injector = null;
			Logger ??= (injector = InjectorLocator.GetInjector())?.Get<ILogger>();
			if(Logger == null)
			{
				Debug.LogError("No Logger!");
				enabled = false;
				return;
			}
		}

		private void Start()
		{
			StringMaker stringMaker = StringMaker.ThreadStaticInstance;
			float floatValue;
			double doubleValue;

			Logger.LogInformation("The float.ToString() method cannot render more than 7 significant digits, except when the \"G9\" format specifier is used. The double.ToString() method cannot render more than 15 significant digits, except when the \"G17\" format spefifier is used. There are many floating-point numbers that can never be accurately represented by using ToString(). Here are some examples of numbers that cannot be rendered with ToString(). However, the Switchboard ConvertToText() and StringMaker.Append() methods can render these values accurately in any format you choose.");

			floatValue = 1.4f;

			stringMaker.Length = 0;
			stringMaker.Append("float.ToString(): ").Append(floatValue.ToString())
				.Append("\nfloat.ConvertToText(): ").Append(floatValue);
			Logger.LogInformation(stringMaker);

			floatValue = 48103632896.0f;

			stringMaker.Length = 0;
			stringMaker.Append("float.ToString(): ").Append(floatValue.ToString())
				.Append("\nfloat.ConvertToText(): ").Append(floatValue);
			Logger.LogInformation(stringMaker);

			floatValue = 0.0001220703125f;

			stringMaker.Length = 0;
			stringMaker.Append("float.ToString(): ").Append(floatValue.ToString())
				.Append("\nfloat.ConvertToText(): ").Append(floatValue);
			Logger.LogInformation(stringMaker);

			floatValue = 0.000000000000000000000000006462348535570528709932880406796584793482907116413116455078125f;

			stringMaker.Length = 0;
			stringMaker.Append("float.ToString(): ").Append(floatValue.ToString())
				.Append("\nfloat.ConvertToText(): ").Append(floatValue);
			Logger.LogInformation(stringMaker);

			floatValue = 48103632896.0f;

			stringMaker.Length = 0;
			stringMaker.Append("float.ToString(\"############\"): ").Append(floatValue.ToString("############"))
				.Append("\nfloat.ConvertToText(): ").Append(floatValue);
			Logger.LogInformation(stringMaker);

			floatValue = 0.0000019073486328125f;

			stringMaker.Length = 0;
			stringMaker.Append("float.ToString(\"0.####################\"): ").Append(floatValue.ToString("0.####################"))
				.Append("\nfloat.ConvertToText(): ").Append(floatValue);
			Logger.LogInformation(stringMaker);

			doubleValue = 5192296858534827628530496329220096.0;

			stringMaker.Length = 0;
			stringMaker.Append("double.ToString(): ").Append(doubleValue.ToString())
				.Append("\ndouble.ConvertToText(): ").Append(doubleValue);
			Logger.LogInformation(stringMaker);

			doubleValue = 0.000000007450580596923828125;

			stringMaker.Length = 0;
			stringMaker.Append("double.ToString(): ").Append(doubleValue.ToString())
				.Append("\ndouble.ConvertToText(): ").Append(doubleValue);
			Logger.LogInformation(stringMaker);

			doubleValue = 6456360425798342656.0;

			stringMaker.Length = 0;
			stringMaker.Append("double.ToString(\"####################\"): ").Append(doubleValue.ToString("####################"))
				.Append("\ndouble.ConvertToText(): ").Append(doubleValue);
			Logger.LogInformation(stringMaker);

			doubleValue = 0.000000000000000444089209850062616169452667236328125;

			stringMaker.Length = 0;
			stringMaker.Append("double.ToString(\"0.####################################################\"): ").Append(doubleValue.ToString("0.####################################################"))
				.Append("\ndouble.ConvertToText(): ").Append(doubleValue);
			Logger.LogInformation(stringMaker);

			stringMaker.Clear();
		}
	}
}
