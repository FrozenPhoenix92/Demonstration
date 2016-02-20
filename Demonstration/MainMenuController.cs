using App1.CollectionView;
using App1.Controls;
using App1.ListDemonstration;
using App1.ScratchTicketView;
using App1.Tabs;
using App1.Swipe;
using FlyoutNavigation;
using Foundation;
using MonoTouch.Dialog;
using System;
using System.CodeDom.Compiler;
using UIKit;
using App1.Signature;
using System.Linq;

namespace App1
{
    partial class MainMenuController : UIViewController
    {
        private string[] _menuItems = {
            "Демонстрация списка",
            "Демонстрация стандартных компонентов",
            "Демонстрация вкладок",
            "Демонстрация смахивания вкладок",
            "Демонстрация пользовательского компонента",
            "Демонстрация росписи",
            "Демонстрация CollectionView",
        };

        public MainMenuController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var navigation = new FlyoutNavigationController();
            navigation.Position = FlyOutNavigationPosition.Left;
            navigation.View.Frame = UIScreen.MainScreen.Bounds;
            View.AddSubview(navigation.View);
            AddChildViewController(navigation);
            navigation.NavigationRoot = new RootElement("Навигация") {
                new Section ("Меню") {
                    _menuItems.Select(elem => new StringElement(elem) as Element)
                }
            };
            var controllers = new UIViewController[]
            {
                new UINavigationController(Storyboard.InstantiateViewController("ListTableViewController") as ListTableViewController),
                new UINavigationController(Storyboard.InstantiateViewController("ControlsViewController") as ControlsViewController),
                new UINavigationController(Storyboard.InstantiateViewController("TabController") as TabController),
                new UINavigationController(Storyboard.InstantiateViewController("SwipeController") as SwipeController),
                new UINavigationController(Storyboard.InstantiateViewController("ScratchTicketViewController") as ScratchTicketViewController),
                new UINavigationController(Storyboard.InstantiateViewController("SignatureController") as SignatureController),
                new UINavigationController(Storyboard.InstantiateViewController("CollectionViewController") as CollectionViewController),
            };
            foreach (UINavigationController item in controllers)
            {
                item.NavigationBarHidden = true;
            }

            navigation.ViewControllers = controllers;
        }

        public override bool PrefersStatusBarHidden()
        {
            return true;
        }
    }
}
