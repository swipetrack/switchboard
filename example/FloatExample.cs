using Switchboard;
using UnityEngine;
using ILogger = Switchboard.ILogger;

namespace SwitchboardExample
{
	public class FloatExample : MonoBehaviour
	{
		private StringMaker Text = StringMaker.Shared;
		private ILogger Logger;

		private void OnEnable()
		{
			IInjector injector = InjectorLocator.GetInjector();
			Logger ??= injector?.Get<ILogger>();
		}

		private void Start()
		{
			float floatValue;
			double doubleValue;

			Logger?.LogInformation(Text.Clear() + "Floating-point numbers:"
				+ "\n    The float.ToString() method cannot render more than 7 significant digits, except when the \"G9\" format specifier is used."
				+ "\n    The double.ToString() method cannot render more than 15 significant digits, except when the \"G17\" format specifier is used."
				+ "\n    There are many floating-point numbers that can never be accurately represented by using ToString()."
				+ "\n    Here are some examples of numbers that cannot be rendered with ToString()."
				+ "\n    However, the Switchboard ConvertToText() and StringMaker.Append() methods can render these values accurately in any format you choose.");

			floatValue = 1.4f;
			Logger?.LogInformation(Text.Clear() + "1.4"
				+ "\n    float.ToString(): " + floatValue.ToString()
				+ "\n    float.ConvertToText(): " + floatValue);

			floatValue = 48103632896.0f;
			Logger?.LogInformation(Text.Clear() + "48103632896.0"
				+ "\n    float.ToString(): " + floatValue.ToString()
				+ "\n    float.ConvertToText(): " + floatValue);

			floatValue = 0.0001220703125f;
			Logger?.LogInformation(Text.Clear() + "0.0001220703125"
				+ "\n    float.ToString(): " + floatValue.ToString()
				+ "\n    float.ConvertToText(): " + floatValue);

			floatValue = 0.000000000000000000000000006462348535570528709932880406796584793482907116413116455078125f;
			Logger?.LogInformation(Text.Clear() + "0.000000000000000000000000006462348535570528709932880406796584793482907116413116455078125"
				+ "\n    float.ToString(): " + floatValue.ToString()
				+ "\n    float.ConvertToText(): " + floatValue);

			floatValue = 48103632896.0f;
			Logger?.LogInformation(Text.Clear() + "48103632896.0"
				+ "\n    float.ToString(\"############\"): " + floatValue.ToString("############")
				+ "\n    float.ConvertToText(): " + floatValue);

			floatValue = 0.0000019073486328125f;
			Logger?.LogInformation(Text.Clear() + "0.0000019073486328125"
				+ "\n    float.ToString(\"0.####################\"): " + floatValue.ToString("0.####################")
				+ "\n    float.ConvertToText(): " + floatValue);

			doubleValue = 5192296858534827628530496329220096.0;
			Logger?.LogInformation(Text.Clear() + "5192296858534827628530496329220096.0"
				+ "\n    double.ToString(): " + doubleValue.ToString()
				+ "\n    double.ConvertToText(): " + doubleValue);

			doubleValue = 0.000000007450580596923828125;
			Logger?.LogInformation(Text.Clear() + "0.000000007450580596923828125"
				+ "\n    double.ToString(): " + doubleValue.ToString()
				+ "\n    double.ConvertToText(): " + doubleValue);

			doubleValue = 6456360425798342656.0;
			Logger?.LogInformation(Text.Clear() + "6456360425798342656.0"
				+ "\n    double.ToString(\"####################\"): " + doubleValue.ToString("####################")
				+ "\n    double.ConvertToText(): " + doubleValue);

			doubleValue = 0.000000000000000444089209850062616169452667236328125;
			Logger?.LogInformation(Text.Clear() + "0.000000000000000444089209850062616169452667236328125"
				+ "\n    double.ToString(\"0.####################################################\"): " + doubleValue.ToString("0.####################################################")
				+ "\n    double.ConvertToText(): " + doubleValue);

			Text.Clear();
		}
	}
}
