using System;
using System.Collections.Generic;
using System.Text;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Samples.iOS
{
    /// <summary>
    /// Представляет пункт меню с пользовательской визуализацией.
    /// </summary>
    public sealed class ListCustomVegeCell : UITableViewCell
    {
        private readonly UILabel _headingLabel;
        private readonly UILabel _subheadingLabel;
        private readonly UIImageView _imageView;

        public ListCustomVegeCell(NSString cellId) : base(UITableViewCellStyle.Default, cellId)
        {
            ContentView.Bounds = new CGRect(0, 0, ContentView.Bounds.Width, 230);
            SelectionStyle = UITableViewCellSelectionStyle.Gray;
            ContentView.BackgroundColor = UIColor.FromRGB(255, 255, 255);
            _imageView = new UIImageView();
            _headingLabel = new UILabel
            {
                Font = UIFont.FromName("Cochin-BoldItalic", 22f),
                TextColor = UIColor.FromRGB(127, 51, 0),
                BackgroundColor = UIColor.Clear
            };
            _subheadingLabel = new UILabel
            {
                Font = UIFont.FromName("AmericanTypewriter", 12f),
                TextColor = UIColor.FromRGB(38, 127, 0),
                TextAlignment = UITextAlignment.Left,
                BackgroundColor = UIColor.Clear
            };
            ContentView.AddSubviews(_headingLabel, _subheadingLabel, _imageView);
        }

        public void UpdateCell(string caption, string subtitle, UIImage image)
        {
            _imageView.Image = image;
            _headingLabel.Text = caption;
            _subheadingLabel.Text = subtitle;
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            _headingLabel.Frame = new CGRect(5, 4, ContentView.Bounds.Width - 23, 25);
            _imageView.Frame = new CGRect(ContentView.Bounds.Width - 150, 28, 200, 200);
            _subheadingLabel.Frame = new CGRect(5, 10, 150, 50);
        }
    }
}
