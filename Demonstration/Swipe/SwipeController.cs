using CoreGraphics;
using Foundation;
using Softweb.Xamarin.Controls.iOS;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace App1.Swipe
{
	partial class SwipeController : UIViewController, ICardViewDataSource
    {
        private static readonly Random random = new Random();

        //Returns a random byte
        private Func<byte> r = () => (Guid.NewGuid()).ToByteArray()[random.Next(0, 15)];

        public CardView DemoCardView { get; set; }

        public SwipeController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            DemoCardView = new CardView();
        }

        public override void ViewWillLayoutSubviews()
        {
            base.ViewWillLayoutSubviews();
            DemoCardView.Center = new CGPoint(View.Center.X, View.Center.Y - 10f);
            DemoCardView.Bounds = new CGRect(0f, 0f, View.Bounds.Width - 20f, View.Bounds.Height - 100f);
            View.AddSubview(DemoCardView);
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            DemoCardView.DataSource = this;
        }

        public override bool PrefersStatusBarHidden()
        {
            return true;
        }

        public UIView NextCardForCardView(CardView cardView)
        {
            //Create a card with a random background color
            var card = new RandomView(DemoCardView.Bounds)
            {
                BackgroundColor = UIColor.FromRGB(200, 200, 200),
            };

            //Rasterize card for more efficient animation
            card.Layer.ShouldRasterize = true;

            return card;
        }
    }
}
