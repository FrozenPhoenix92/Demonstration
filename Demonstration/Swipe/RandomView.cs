using CoreGraphics;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace App1.Swipe
{
    public class RandomView : UIView
    {
        Random _random = new Random();

        public RandomView(CGRect bounds)
        {
            Frame = bounds;

            var label = new UILabel(new CGRect(5, 250, Frame.Width, 150));
            label.Text = "Описание блюда";

            var image = UIImage.FromBundle("Images/Swipe/rolls.jpg");
            var imageView = new UIImageView(image);
            imageView.Frame = new CGRect(0, 0, 300, 300);
            //imageView.Center = new CGPoint(Frame.Width / 2, 180 + imageView.Frame.Height / 2);

            AddSubviews(label, imageView);
        }

        private string RandomText()
        {
            var result = "";
            for (var index = 0; index <= 400; index++)
            {
                result += (char)_random.Next(65, 122);
            }
            return result;
        }
    }
}
