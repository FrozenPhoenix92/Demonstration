using UIKit;

namespace Samples.iOS
{
    public class ListTableItem
    {
        public ListTableItem()
        {
            CellStyle = UITableViewCellStyle.Default;
            CellAccessory = UITableViewCellAccessory.None;
        }

        public ListTableItem(string heading) : this()
        {
            Heading = heading;
        }


        public int Id { get; set; }

        public int GroupId { get; set; }

        public string Heading { get; set; }

        public string SubHeading { get; set; }

        public string ImageName { get; set; }

        public UITableViewCellStyle CellStyle { get; set; }

        public UITableViewCellAccessory CellAccessory { get; set; }
    }
}
