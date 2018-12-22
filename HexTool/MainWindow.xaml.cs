using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HexTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            IEnumerable<GridItem> items = GetGridItems();
            hxMap.ItemsSource = items;

            hxMap.SelectionChanged += HxMap_SelectionChanged;
        }

        private void HxMap_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            (e.AddedItems[e.AddedItems.Count-1] as GridItem).Image = "Images/BDesert.png";
        }

        private IEnumerable<GridItem> GetGridItems()
        {
            List<GridItem> items = new List<GridItem>();
            Random r = new Random();
            for (int i = 0; i < 40; i++)
            {
                for(int j = 0; j < 40; j++)
                {
                    GridItem item = new GridItem { X = i, Y = j };
                    int t = r.Next(3);
                    switch(t)
                    {
                        case 0:
                            item.Image = "Images/BPlains.png";
                            break;
                        case 1:
                            item.Image = "Images/BForestHills.png";
                            break;
                        case 2:
                            item.Image = "Images/BDesert.png";
                            break;
                    }
                    items.Add(item);
                }
            }
            return items;
        }
    }
}
