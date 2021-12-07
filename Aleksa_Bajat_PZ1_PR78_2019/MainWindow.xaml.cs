using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Common;

namespace Aleksa_Bajat_PZ1_PR78_2019
{
    public partial class MainWindow : Window
    {
        public static BindingList<SamsungPhone> PhoneList { get; set; } //0 - n-1
                                                                           

        public MainWindow()
        {
            PhoneList = DataIO.DeSerializeObject<BindingList<SamsungPhone>>("phonelist.xml");

            if(PhoneList is null)
            {
                PhoneList = new BindingList<SamsungPhone>();
            }
      
          

            DataContext = this;

            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            DataIO.SerializeObject<BindingList<SamsungPhone>>(PhoneList, "phonelist.xml");
            this.Close();
        }

        private void AddNewButton_Click(object sender, RoutedEventArgs e)
        {
            Window addWindow = new AddPhoneWindow();
            addWindow.ShowDialog();            
        }

        private void Details_Click(object sender, RoutedEventArgs e)
        {
            Window DetailsWindow = new DetailsWindow(DataGrid.SelectedIndex);
            DetailsWindow.ShowDialog();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (PhoneList.Count > 0)
            {
                Window EditWindow = new AddPhoneWindow(DataGrid.SelectedIndex);
                EditWindow.ShowDialog();
                DataGrid.Items.Refresh();
            }           
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(PhoneList.Count > 0)
            {
                File.Delete(PhoneList[DataGrid.SelectedIndex].PathToDescription);                
                PhoneList.RemoveAt(DataGrid.SelectedIndex);
                
            }
            
            
           // DataGrid.Items.Refresh();
        }
    }
}
