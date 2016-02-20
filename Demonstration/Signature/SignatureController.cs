using Foundation;
using SignaturePad;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace App1.Signature
{
	partial class SignatureController : UIViewController
	{
		public SignatureController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var signature = new SignaturePadView(View.Frame);
            View.AddSubview(signature);
        }

        public override bool PrefersStatusBarHidden()
        {
            return true;
        }
    }
}
