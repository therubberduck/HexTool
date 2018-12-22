using HexTool.IconFactory;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using SkiaSharp.Views.Desktop;
using SkiaSharp.Views.WPF;
using HexGridControl;
using SkiaSharp;

namespace HexTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Factory f = new Factory();

        public MainWindow()
        {
            InitializeComponent();

            IEnumerable<GridItem> items = GetGridItems();
            hxMap.ItemsSource = items;

            hxMap.SelectionChanged += HxMap_SelectionChanged;
        }

        private void HxMap_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
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
                            item.Background = "Images/BPlains.png";
                            item.Vegetation = "Images/VGrassland.png";
                            break;
                        case 1:
                            item.Background = "Images/BForestHills.png";
                            item.Terrain = "Images/THills.png";
                            item.Vegetation = "Images/VForest.png";
                            break;
                        case 2:
                            item.Background = "Images/BDesert.png";
                            if(item.X%2 == 0 && item.Y%2 == 0)
                            {
                                item.Feature = "Images/IcMonument.png";
                            }
                            break;
                    }
                    item.Image = f.Create(item);
                    items.Add(item);
                }
            }
            return items;
        }
    }
}
