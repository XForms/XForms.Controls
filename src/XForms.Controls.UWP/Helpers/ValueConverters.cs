using Windows.UI;
using Windows.UI.Xaml.Media;

namespace XForms.Controls.UWP.Helpers
{
	public static class ValueConverters
	{
		public static FontFamily StringToFontFamily(string fontfamilyName)
		{
			return new FontFamily(fontfamilyName);
		}

		public static Color FormsColorToNative(Xamarin.Forms.Color color)
		{
			return Color.FromArgb(
				Convert.ToByte(color.A * 255),
				Convert.ToByte(color.R * 255),
				Convert.ToByte(color.G * 255),
				Convert.ToByte(color.B * 255));
		}
	}
}
