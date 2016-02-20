using Foundation;
using Samples.iOS;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using UIKit;

namespace App1
{
    partial class MenuTableViewController : UITableViewController
    {
        private readonly List<MainMenuRow> _items = new List<MainMenuRow>
        {
            new MainMenuRow { Id = "ListDemonstration", Text = "Демонстрация списка" },
            new MainMenuRow { Id = "ScratchTicketView", Text = "Демонстрация пользовательского компонента" },
            new MainMenuRow { Id = "Controls", Text = "Демонстрация стандартных компонентов" },
            new MainMenuRow { Id = "CollectionView", Text = "Демонстрация CollectionView" },
            new MainMenuRow { Id = "TabView", Text = "Демонстрация вкладок" },
            new MainMenuRow { Id = "FayoutMenu", Text = "Демонстрация бокового меню" }
        };


        public MenuTableViewController(IntPtr handle) : base(handle)
        {
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TableView.Source = new MenuTableSource(_items, this);
        }
    }
}
