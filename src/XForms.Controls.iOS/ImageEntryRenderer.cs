using System.Drawing;
using CoreAnimation;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XForms.Controls;
using XForms.Controls.iOS;

[assembly: ExportRenderer(typeof(ImageEntry), typeof(ImageEntryRenderer))]
namespace XForms.Controls.iOS
{
	/// <summary>
	/// https://gist.github.com/Char0394/f9b92dcd08ceb909b73d6bceb812f78c
	/// </summary>
	public class ImageEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null || e.NewElement == null)
				return;

			var element = (ImageEntry)Element;
			var textField = Control;
			if (!string.IsNullOrEmpty(element.Image))
			{
				switch (element.ImageAlignment)
				{
					case ImageAlignment.Left:
						textField.LeftViewMode = UITextFieldViewMode.Always;
						textField.LeftView = GetImageView(element.Image, element.ImageHeight, element.ImageWidth);
						break;
					case ImageAlignment.Right:
						textField.RightViewMode = UITextFieldViewMode.Always;
						textField.RightView = GetImageView(element.Image, element.ImageHeight, element.ImageWidth);
						break;
				}
			}

			textField.BorderStyle = UITextBorderStyle.None;
			CALayer bottomBorder = new CALayer
			{
				Frame = new CGRect(0.0f, element.HeightRequest - 1, this.Frame.Width, 1.0f),
				BorderWidth = 2.0f,
				BorderColor = element.LineColor.ToCGColor()
			};

			textField.Layer.AddSublayer(bottomBorder);
			textField.Layer.MasksToBounds = true;
		}

		private UIView GetImageView(string imagePath, int height, int width)
		{
			var uiImageView = new UIImageView(UIImage.FromBundle(imagePath))
			{
				Frame = new RectangleF(0, 0, width, height)
			};
			UIView objLeftView = new UIView(new System.Drawing.Rectangle(0, 0, width + 10, height));
			objLeftView.AddSubview(uiImageView);

			return objLeftView;
		}
	}
}