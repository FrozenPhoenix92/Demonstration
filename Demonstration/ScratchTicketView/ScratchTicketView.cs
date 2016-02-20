
using System;
using System.Drawing;

using Foundation;
using UIKit;
using CoreGraphics;
using System.ComponentModel;

namespace App1.ScratchTicketView
{
    [Register("ScratchTicketView"), DesignTimeVisible(true)]
    public partial class ScratchTicketView : UIView
    {
        private CGPath _path;
        private CGPoint _initialPoint;
        private CGPoint _latestPoint;
        private bool _startNewPath = false;
        private UIImage _image;


        public ScratchTicketView()
        {
            Initialize();
        }

        public ScratchTicketView(IntPtr p) : base(p)
        {
            Initialize();
        }


        [Export("Image"), Browsable(true)]
        public UIImage Image
        {
            get { return _image; }
            set
            {
                _image = value;
                SetNeedsDisplay();
            }
        }

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);

            var touch = touches.AnyObject as UITouch;

            if (touch != null)
            {
                _initialPoint = touch.LocationInView(this);
            }
        }

        public override void TouchesMoved(NSSet touches, UIEvent evt)
        {
            base.TouchesMoved(touches, evt);

            var touch = touches.AnyObject as UITouch;

            if (touch != null)
            {
                _latestPoint = touch.LocationInView(this);
                SetNeedsDisplay();
            }
        }

        public override void TouchesEnded(NSSet touches, UIEvent evt)
        {
            base.TouchesEnded(touches, evt);
            _startNewPath = true;
        }

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);

            using (var g = UIGraphics.GetCurrentContext())
            {
                g.SetFillColor(_image != null
                    ? (UIColor.FromPatternImage(_image).CGColor)
                    : UIColor.LightGray.CGColor);
                g.FillRect(rect);

                if (_initialPoint.IsEmpty) return;
                g.SetLineWidth(20);
                g.SetBlendMode(CGBlendMode.Clear);
                UIColor.Clear.SetColor();

                if (_path.IsEmpty || _startNewPath)
                {
                    _path.AddLines(new[] { _initialPoint, _latestPoint });
                    _startNewPath = false;
                }
                else
                {
                    _path.AddLineToPoint(_latestPoint);
                }

                g.SetLineCap(CGLineCap.Round);
                g.AddPath(_path);
                g.DrawPath(CGPathDrawingMode.Stroke);
            }
        }

        private void Initialize()
        {
            _initialPoint = CGPoint.Empty;
            _latestPoint = CGPoint.Empty;
            BackgroundColor = UIColor.Clear;
            Opaque = false;
            _path = new CGPath();
            SetNeedsDisplay();
        }
    }
}