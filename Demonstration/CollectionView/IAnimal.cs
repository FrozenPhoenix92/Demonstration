using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace App1.CollectionView
{
    public interface IAnimal
    {
        string Name { get; }

        UIImage Image { get; }
    }
}
