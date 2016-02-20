using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace App1.CollectionView
{
    public class Monkey : IAnimal
    {
        public Monkey()
        {
        }

        public string Name
        {
            get
            {
                return "Monkey";
            }
        }

        public UIImage Image
        {
            get
            {
                return UIImage.FromBundle("Images/CollectionView/monkey.png");
            }
        }

    }
}
