using System.Collections.Generic;

namespace Samples.iOS
{
    public class ListTableItemGroup
    {
        public ListTableItemGroup()
        {
            Items = new List<ListTableItem>();
        }


        public int Id { get; set; }

        public string Title { get; set; }

        public string Footer { get; set; }

        public List<ListTableItem> Items { get; set; }
    }
}
