using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace App1.Controls
{
    public class PickerModel : UIPickerViewModel
    {
        private string[] _items;

        public PickerModel(string[] items)
        {
            _items = items;
        }

        public override nint GetComponentCount(UIPickerView picker)
        {
            return 1;
        }

        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return _items.Length;
        }

        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            return _items[row];
        }
    }
}
