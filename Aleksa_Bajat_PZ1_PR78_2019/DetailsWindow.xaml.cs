using Common;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace Aleksa_Bajat_PZ1_PR78_2019
{
    /// <summary>
    /// Interaction logic for DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        public DetailsWindow(int index)
        {                                        
            InitializeComponent();
            int id = MainWindow.PhoneList[index].ID;
            RtfManipulator.RtfRW(id, RichTextBox, true);
            LabelName.Content = MainWindow.PhoneList[index].PhoneName;            
            PhoneImage.Source = new BitmapImage(new Uri(MainWindow.PhoneList[index].PathToImage));
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
