
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
        /// Загружает данные в список и настраивает его внешний вид.
        /// </summary>
	    private void InitTableView()
        {
            // Внешний вид
            TableView.SeparatorColor = UIColor.Black;
            TableView.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine;
            TableView.RowHeight = 230;
            // Эффект размытия границы
            /*TableView.SeparatorEffect =
                UIBlurEffect.FromStyle(UIBlurEffectStyle.Dark);*/
            // Эффект резонанса границы
            /*var effect = UIBlurEffect.FromStyle(UIBlurEffectStyle.Light);
            TableView.SeparatorEffect = UIVibrancyEffect.FromBlurEffect(effect);
            TableView.SeparatorInset.InsetRect(new CGRect(4, 4, 150, 2));*/

            //Загрузка данных
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
                    Footer = wordsOfSection.Count + " элементов",
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
            #region Секция 1, 2
            var sections = new List<Section>
	        {
	            new Section { Name = "Секция 1", Id=1 },
                new Section { Name = "Секция 2", Id=2 }
	        };
	        var words = new List<Word>
	        {
	            new Word
	            {
	                SectionId = 1,
                    Value = "Луковицы",
                    SubHeading = "Будешь плакать",
                    ImageName = "Bulbs.jpg"
	            },
                new Word
                {
                    SectionId = 1,
                    Value = "Цветочные почки",
                    SubHeading = "Ещё не распустились",
                    ImageName = "Flower Buds.jpg"
                },
                new Word
                {
                    SectionId = 1,
                    Value = "Фрукты",
                    SubHeading = "Сладкие и вкусные",
                    ImageName = "Fruits.jpg"
                },
                new Word
                {
                    SectionId = 2,
                    Value = "Бобы",
                    SubHeading = "Ненавижу бобы",
                    ImageName = "Legumes.jpg"
                },
                new Word
                {
                    SectionId = 2,
                    Value = "Клубни",
                    SubHeading = "Можно сделать борщ",
                    ImageName = "Tubers.jpg"
                },
                new Word
                {
                    SectionId = 2,
                    Value = "Овощи",
                    SubHeading = "Пустим на салат",
                    ImageName = "Vegetables.jpg"
                }
            };
            #endregion

            #region Секция 3
            sections.Add(new Section { Name = "Секция 3", Id=3 });
            words.AddRange(new List<Word>
            {
                new Word
                {
                    SectionId = 3,
                    Value = "Луковицы",
                    SubHeading = "Будешь плакать",
                    ImageName = "Bulbs.jpg"
                },
                new Word
                {
                    SectionId = 3,
                    Value = "Цветочные почки",
                    SubHeading = "Ещё не распустились",
                    ImageName = "Flower Buds.jpg"
                },
                new Word
                {
                    SectionId = 3,
                    Value = "Фрукты",
                    SubHeading = "Сладкие и вкусные",
                    ImageName = "Fruits.jpg"
                },
                new Word
                {
                    SectionId = 3,
                    Value = "Бобы",
                    SubHeading = "Ненавижу бобы",
                    ImageName = "Legumes.jpg"
                },
                new Word
                {
                    SectionId = 3,
                    Value = "Клубни",
                    SubHeading = "Можно сделать борщ",
                    ImageName = "Tubers.jpg"
                },
                new Word
                {
                    SectionId = 3,
                    Value = "Овощи",
                    SubHeading = "Пустим на салат",
                    ImageName = "Vegetables.jpg"
                }
            });
            #endregion

            #region Секция 4
            sections.Add(new Section { Name = "Секция 4", Id = 4 });
            for (var index = 1; index <= 150; index++)
            {
                words.Add(new Word
                {
                    SectionId = 4,
                    Value = "Слово №" + index,
                    SubHeading = "Подзаголовок №" + index,
                    ImageName = "Bulbs.jpg"
                });
            }
            #endregion

            #region Секция 5
            sections.Add(new Section { Name = "Секция 5", Id = 5 });
            for (var index = 1; index <= 150; index++)
            {
                words.Add(new Word
                {
                    SectionId = 5,
                    Value = "Слово №" + index,
                    SubHeading = "Подзаголовок №" + index,
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