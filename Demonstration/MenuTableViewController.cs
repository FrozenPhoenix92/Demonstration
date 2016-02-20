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
            new MainMenuRow { Id = "ListDemonstration", Text = "������������ ������" },
            new MainMenuRow { Id = "ScratchTicketView", Text = "������������ ����������������� ����������" },
            new MainMenuRow { Id = "Controls", Text = "������������ ����������� �����������" },
            new MainMenuRow { Id = "CollectionView", Text = "������������ CollectionView" },
            new MainMenuRow { Id = "TabView", Text = "������������ �������" },
            new MainMenuRow { Id = "FayoutMenu", Text = "������������ �������� ����" }
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
