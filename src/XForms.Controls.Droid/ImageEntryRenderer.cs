using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V4.Content;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using XForms.Controls;
using XForms.Controls.Droid;

[assembly: ExportRenderer(typeof(ImageEntry), typeof(ImageEntryRenderer))]
namespace XForms.Controls.Droid
{
	/// <summary>
	/// https://gist.github.com/Char0394/6279a63c6d44ae180efc4e74e16a5b95
	/// </summary>
	public class ImageEntryRenderer : EntryRenderer
	{
		ImageEntry element;
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null || e.NewElement == null)
				return;

			element = (ImageEntry)Element;

			var editText = Control;
			if (!string.IsNullOrEmpty(element.Image))
			{
				switch (element.ImageAlignment)
				{
					case ImageAlignment.Left:
						editText.SetCompoundDrawablesWithIntrinsicBounds(GetDrawable(element.Image), null, null, null);
						break;
					case ImageAlignment.Right:
						editText.SetCompoundDrawablesWithIntrinsicBounds(null, null, GetDrawable(element.Image), null);
						break;
				}
			}
			editText.CompoundDrawablePadding = 25;
			Control.Background.SetColorFilter(element.LineColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
		}

		private BitmapDrawable GetDrawable(string imageEntryImage)
		{
			int resID = Resources.GetIdentifier(imageEntryImage, "drawable", Context.PackageName);
			var drawable = ContextCompat.GetDrawable(Context, resID);
			var bitmap = ((BitmapDrawable)drawable).Bitmap;

			return new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(bitmap, element.ImageWidth * 2, element.ImageHeight * 2, true));
		}
	}
}