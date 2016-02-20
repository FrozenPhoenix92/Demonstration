using FlyoutNavigation;
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using MonoTouch.Dialog;

namespace App1.FayoutMenu
{
    partial class FayoutMenuController : UIViewController
    {
        public FayoutMenuController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            var navigation = new FlyoutNavigationController
            {
                // Create the navigation menu
                NavigationRoot = new RootElement("Навигация") {
            new Section ("Страницы") {
                new StringElement ("Животные"),
                new StringElement ("Овощи"),
                new StringElement ("Минералы"),
            }
        },
                // Supply view controllers corresponding to menu items:
                ViewControllers = new[] {
            new UIViewController { View = new UILabel { Text = "Животные (смахните вправо)" } },
            new UIViewController { View = new UILabel { Text = "Овощи (смахните вправо)" } },
            new UIViewController { View = new UILabel { Text = "Минералы (смахните вправо)" } },
        },
            };
            // Show the navigation view
            navigation.ToggleMenu();
            View.AddSubview(navigation.View);
        }
    }
}
