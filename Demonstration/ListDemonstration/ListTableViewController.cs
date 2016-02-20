
using System;
using System.Drawing;

using Foundation;
using UIKit;
using System.IO;
using Samples.iOS;
using System.Collections.Generic;
using Samples.Shared.SQLite;
using System.Linq;

namespace App1.ListDemonstration
{
    partial class ListTableViewController : UITableViewController
    {
        private UnitOfWork _unitOfWork;

        private const string DbName = "database.db3";


        public ListTableViewController() : base() { }

        public ListTableViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            InitList();
        }

        public override bool PrefersStatusBarHidden()
        {
            return true;
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return 230;
        }


        private void InitList()
        {
            var path = GetDatabasePath(DbName);
            //File.Delete(path);
            if (File.Exists(path))
            {
                _unitOfWork = new UnitOfWork(new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS(), path);
            }
            else
            {
                _unitOfWork = new UnitOfWork(new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS(), path);
                FillDatabase();
            }
            
            InitTableView();
        }

        /// <summary>
        /// ��������� ������ � ������ � ����������� ��� ������� ���.
        /// </summary>
	    private void InitTableView()
        {
            // ������� ���
            TableView.SeparatorColor = UIColor.Black;
            TableView.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine;
            TableView.RowHeight = 230;
            // ������ �������� �������
            /*TableView.SeparatorEffect =
                UIBlurEffect.FromStyle(UIBlurEffectStyle.Dark);*/
            // ������ ��������� �������
            /*var effect = UIBlurEffect.FromStyle(UIBlurEffectStyle.Light);
            TableView.SeparatorEffect = UIVibrancyEffect.FromBlurEffect(effect);
            TableView.SeparatorInset.InsetRect(new CGRect(4, 4, 150, 2));*/

            //�������� ������
            var sections = _unitOfWork.Sections.GetAll();
            var words = _unitOfWork.Words.GetAll();
            TableView.Source = new ListTableSource(ConvertData(sections, words), this);
        }

        private string GetDatabasePath(string databaseName)
        {
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(folder, databaseName);
        }

        private List<ListTableItemGroup> ConvertData(IEnumerable<Section> sections,
            IEnumerable<Word> words)
        {
            var result = new List<ListTableItemGroup>();
            foreach (var section in sections)
            {
                var wordsOfSection = words.Where(elem => elem.SectionId == section.Id).ToList();
                var listTableItemGroup = new ListTableItemGroup
                {
                    Id = Convert.ToInt32(section.Id),
                    Title = Convert.ToString(section.Name),
                    Footer = wordsOfSection.Count + " ���������",
                    Items = wordsOfSection.Select(elem => new ListTableItem
                    {
                        Id = Convert.ToInt32(elem.Id),
                        GroupId = Convert.ToInt32(elem.SectionId),
                        Heading = Convert.ToString(elem.Value),
                        CellStyle = UITableViewCellStyle.Subtitle,
                        SubHeading = Convert.ToString(elem.SubHeading),
                        ImageName = Convert.ToString(elem.ImageName)
                    }).ToList()
                };
                result.Add(listTableItemGroup);
            }
            return result;
        }

        private void FillDatabase()
        {
            #region ������ 1, 2
            var sections = new List<Section>
	        {
	            new Section { Name = "������ 1", Id=1 },
                new Section { Name = "������ 2", Id=2 }
	        };
	        var words = new List<Word>
	        {
	            new Word
	            {
	                SectionId = 1,
                    Value = "��������",
                    SubHeading = "������ �������",
                    ImageName = "Bulbs.jpg"
	            },
                new Word
                {
                    SectionId = 1,
                    Value = "��������� �����",
                    SubHeading = "��� �� ������������",
                    ImageName = "Flower Buds.jpg"
                },
                new Word
                {
                    SectionId = 1,
                    Value = "������",
                    SubHeading = "������� � �������",
                    ImageName = "Fruits.jpg"
                },
                new Word
                {
                    SectionId = 2,
                    Value = "����",
                    SubHeading = "�������� ����",
                    ImageName = "Legumes.jpg"
                },
                new Word
                {
                    SectionId = 2,
                    Value = "������",
                    SubHeading = "����� ������� ����",
                    ImageName = "Tubers.jpg"
                },
                new Word
                {
                    SectionId = 2,
                    Value = "�����",
                    SubHeading = "������ �� �����",
                    ImageName = "Vegetables.jpg"
                }
            };
            #endregion

            #region ������ 3
            sections.Add(new Section { Name = "������ 3", Id=3 });
            words.AddRange(new List<Word>
            {
                new Word
                {
                    SectionId = 3,
                    Value = "��������",
                    SubHeading = "������ �������",
                    ImageName = "Bulbs.jpg"
                },
                new Word
                {
                    SectionId = 3,
                    Value = "��������� �����",
                    SubHeading = "��� �� ������������",
                    ImageName = "Flower Buds.jpg"
                },
                new Word
                {
                    SectionId = 3,
                    Value = "������",
                    SubHeading = "������� � �������",
                    ImageName = "Fruits.jpg"
                },
                new Word
                {
                    SectionId = 3,
                    Value = "����",
                    SubHeading = "�������� ����",
                    ImageName = "Legumes.jpg"
                },
                new Word
                {
                    SectionId = 3,
                    Value = "������",
                    SubHeading = "����� ������� ����",
                    ImageName = "Tubers.jpg"
                },
                new Word
                {
                    SectionId = 3,
                    Value = "�����",
                    SubHeading = "������ �� �����",
                    ImageName = "Vegetables.jpg"
                }
            });
            #endregion

            #region ������ 4
            sections.Add(new Section { Name = "������ 4", Id = 4 });
            for (var index = 1; index <= 150; index++)
            {
                words.Add(new Word
                {
                    SectionId = 4,
                    Value = "����� �" + index,
                    SubHeading = "������������ �" + index,
                    ImageName = "Bulbs.jpg"
                });
            }
            #endregion

            #region ������ 5
            sections.Add(new Section { Name = "������ 5", Id = 5 });
            for (var index = 1; index <= 150; index++)
            {
                words.Add(new Word
                {
                    SectionId = 5,
                    Value = "����� �" + index,
                    SubHeading = "������������ �" + index,
                    ImageName = "Fruits.jpg"
                });
            }
            #endregion

            foreach (var section in sections)
            {
                _unitOfWork.Sections.Create(section);
            }
            foreach (var word in words)
            {
                _unitOfWork.Words.Create(word);
            }
        }
    }
}