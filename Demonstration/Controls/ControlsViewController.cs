
using System;
using System.Drawing;

using Foundation;
using UIKit;
using System.Threading.Tasks;
using CoreGraphics;

namespace App1.Controls
{
    public partial class ControlsViewController : UIViewController
    {
        public ControlsViewController() : base()
        {
        }

        public ControlsViewController(IntPtr handle) : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var pickerView = new UIPickerView(new CGRect(50, 100, View.Frame.Size.Width - 100, 120));
            pickerView.Model = new PickerModel(new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            View.AddSubview(pickerView);

            ActivityIndicator.Hidden = true;

            Label1.Text = "Новая надпись";
            View.Add(Label1);

            //			new System.Threading.Thread (new System.Threading.ThreadStart (() => {
            //				InvokeOnMainThread (() => {
            //					Label1.Text = "updated in thread";
            //				});
            //			})).Start ();

            Button1.TouchUpInside += (sender, e) => {
                Label1.Text = "Кнопка 1 нажата";

                // SIMPLE ALERT
                //				UIAlertView alert = new UIAlertView ("Title", "The message", null, "OK", null);
                //				alert.Show();

                // TWO BUTTON ALERT
                //				UIAlertView alert = new UIAlertView ("Alert Title", "Choose from two buttons", null, "OK", new string[] {"Cancel"});
                //				alert.Clicked += (s, b) => {
                //					Label1.Text = "Button " + b.ButtonIndex.ToString () + " clicked";
                //					Console.WriteLine ("Button " + b.ButtonIndex.ToString () + " clicked");
                //				};
                //				alert.Show();

                // THREE BUTTON ALERT
                UIAlertView alert = new UIAlertView()
                {
                    Title = "Окно вызвано",
                    Message = "Это окно содержит пользовательские кнопки"
                };
                alert.AddButton("OK");
                alert.AddButton("Пользовательская кнопка");
                alert.AddButton("Отмена");
                alert.Show();

                TextField.ResignFirstResponder();
                TextView.ResignFirstResponder();
            };

            // SLIDER
            Slider.MinValue = -1;
            Slider.MaxValue = 2;
            Slider.Value = 0.5f;

            // customize
            //			Slider.MinimumTrackTintColor = UIColor.Gray;
            //			Slider.MaximumTrackTintColor = UIColor.Green;

            // BOOLEAN
            Switch.On = true;

            //DISMISS KEYBOARD ON RETURN BUTTON PRESS.
            TextField.ShouldReturn += (textField) => {
                textField.ResignFirstResponder();
                return true;
            };

            // LAYOUT OPTIONS
            Label1.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
            TextField.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
        }

        partial void slider1_valueChanged(UISlider sender)
        {
            Label2.Text = ((UISlider)sender).Value.ToString();
        }

        //
        // Async/Await example
        //
        async partial void button3_TouchUpInside(UIButton sender)
        {
            TextField.ResignFirstResponder();
            TextView.ResignFirstResponder();

            ActivityIndicator.Hidden = false;
            ActivityIndicator.StartAnimating();

            Label1.Text = "Асинхронный метод запущен";

            await Task.Delay(1000);

            Label1.Text = "1 секунда прошла";

            await Task.Delay(2000);

            Label1.Text = "Ещё 2 секунды прошло";

            await Task.Delay(1000);

            new UIAlertView("Асинхронный метод выполнен", "Этот метод содержит логику асинхронного выполнения",
                null, "Отмена", null)
                .Show();

            ActivityIndicator.Hidden = true;
            ActivityIndicator.StopAnimating();

            Label1.Text = "Асинхронный метод завершён";
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        #endregion
    }
}