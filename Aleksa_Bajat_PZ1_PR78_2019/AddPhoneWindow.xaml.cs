using Microsoft.Win32;
using System;
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
using System.Windows.Shapes;
using Common;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Aleksa_Bajat_PZ1_PR78_2019
{
    public partial class AddPhoneWindow : Window
    {
        string _path = "";
        bool _noEdit = true;
        int idx = -1;
        bool _imageChange = false;
        bool _init = false;
        int _wordCounter = 0;
        

        public AddPhoneWindow()
        {
            InitializeComponent();
            Initializer();
            _init = true;
        }

        public AddPhoneWindow(int index)
        {
            InitializeComponent();
            Initializer();
            _init = true;
            int id = MainWindow.PhoneList[index].ID;
            RtfManipulator.RtfRW(id, RichTextBox,true);
            idx = index;

            ButtonAdd.Content = "Edit Phone";
            PhoneName.Text = MainWindow.PhoneList[idx].PhoneName;
            DateTimePicker.SelectedDate = MainWindow.PhoneList[idx].ReleaseDate;
            AndroidVersions.SelectedItem = MainWindow.PhoneList[idx].AndroidVersion;
            PhoneImage.Source = new BitmapImage(new Uri(MainWindow.PhoneList[idx].PathToImage));

            _noEdit = false;                    
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Select a picture";
            fileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";

            if (fileDialog.ShowDialog() == true)
            {
                PhoneImage.Source = new BitmapImage(new Uri(fileDialog.FileName));
                _path = fileDialog.FileName;
                _imageChange = true;
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {                             
                if (_noEdit) { 

                    int id;

                    if (MainWindow.PhoneList.Count > 0)
                    {
                        id = MainWindow.PhoneList[MainWindow.PhoneList.Count - 1].ID + 1;
                    }
                    else
                    {
                        id = 0;
                    }


                    string pathr = RtfManipulator.RtfRW(id, RichTextBox, false);

                    MainWindow.PhoneList.Add(new SamsungPhone(PhoneName.Text, pathr, (DateTime)DateTimePicker.SelectedDate, (double)AndroidVersions.SelectedValue, _path,id));                    
                }                            
                else
                {
                    MainWindow.PhoneList[idx].PhoneName = PhoneName.Text;                    
                    MainWindow.PhoneList[idx].ReleaseDate = (DateTime)DateTimePicker.SelectedDate; 
                    MainWindow.PhoneList[idx].AndroidVersion = (double)AndroidVersions.SelectedValue;

                    int id = MainWindow.PhoneList[idx].ID;

                    if (_imageChange)
                    {
                        MainWindow.PhoneList[idx].PathToImage = _path;
                    }
                    RtfManipulator.RtfRW(id, RichTextBox, false);
                }

                this.Close();
            }                      
        }

        private bool Validate()
        {
            bool _pass = true;           

            if (PhoneName.Text.Trim() == "")
            {
                LabelErrorName.Content = "Error: Phone name is empty.";
                _pass = false;
            }
            else
                LabelErrorName.Content = "";
 

            if(DateTimePicker.SelectedDate is null)
            {
                LabelErrorDate.Content = "Error: Date is empty.";
                _pass = false;
            }                          
            else            
                LabelErrorDate.Content = "";

                      
            if (_wordCounter == 0)
            {
                LabelErrorDescription.Content = "Error: Description is empty.";
                _pass = false;
            }
            else
                LabelErrorDescription.Content = "";
                               
            if (AndroidVersions.SelectedValue is null)
            {
                LabelErrorVersion.Content = "Error: Version is empty.";
                _pass = false;
            }
            else
                LabelErrorVersion.Content = "";

            if (PhoneImage.Source == null)
            {
                LabelErrorImage.Content = "Error: No Image";
                _pass = false;
            }
            else
                LabelErrorImage.Content = "";

            return _pass;
        }

        private void ComboBoxFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ComboBoxFontFamily.SelectedItem != null && !RichTextBox.Selection.IsEmpty)
            {
                RichTextBox.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, ComboBoxFontFamily.SelectedItem);              
            }
        }

        private void ComboBoxFontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxFontSize.SelectedItem != null && !RichTextBox.Selection.IsEmpty)
            {
                RichTextBox.Selection.ApplyPropertyValue(Inline.FontSizeProperty, ComboBoxFontSize.SelectedItem);
            }
        }

        private void ComboBoxColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxColor.SelectedItem != null && !RichTextBox.Selection.IsEmpty)
            {
               // ComboBoxColor.Background = (SolidColorBrush)new BrushConverter().ConvertFrom(ComboBoxColor.SelectedItem);
               RichTextBox.Selection.ApplyPropertyValue(Inline.ForegroundProperty, (SolidColorBrush)new BrushConverter().ConvertFrom(ComboBoxColor.SelectedItem));
            }
        }

        private void RichTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = RichTextBox.Selection.GetPropertyValue(Inline.FontWeightProperty);
            ButtonBold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));

            temp = RichTextBox.Selection.GetPropertyValue(Inline.FontStyleProperty);
            ButtonItalic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));

            temp = RichTextBox.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            ButtonUnderline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

            temp = RichTextBox.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            ComboBoxFontFamily.SelectedItem = temp;

            temp = RichTextBox.Selection.GetPropertyValue(Inline.FontSizeProperty);
            ComboBoxFontSize.SelectedItem = temp;

            temp = RichTextBox.Selection.GetPropertyValue(Inline.ForegroundProperty);
            try
            {
                System.Drawing.Color _color = System.Drawing.ColorTranslator.FromHtml(((SolidColorBrush)temp).ToString());
                string _colorName = ColorTransformer(_color.ToArgb());

                ComboBoxColor.SelectedItem = _colorName;
            }
            catch
            {
                
            }
            
         
        }


        void Initializer()
        {
            AndroidVersions.ItemsSource = new List<double> { 1.0, 1.1, 1.5, 1.6, 2.0, 2.2, 2.3, 3.0, 4.0, 4.1, 4.4, 5.0, 6.0, 7.0, 8.0, 9, 10, 11, 12 };
            ComboBoxFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            ComboBoxFontSize.ItemsSource = new List<double> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 };
            ComboBoxColor.ItemsSource = new List<string> { "AliceBlue", "AntiqueWhite", "Aqua", "Aquamarine", "Azure", "Beige", "Bisque", "Black", "BlanchedAlmond", "Blue", "BlueViolet", "Brown", "BurlyWood", "CadetBlue", "Chartreuse",
                "Chocolate", "Coral", "CornflowerBlue", "Cornsilk", "Crimson", "Cyan", "DarkBlue", "DarkCyan", "DarkGoldenrod",
                "DarkGray", "DarkGreen", "DarkKhaki", "DarkMagenta", "DarkOliveGreen", "DarkOrange", "DarkOrchid",
                "DarkRed", "DarkSalmon", "DarkSeaGreen", "DarkSlateBlue", "DarkSlateGray", "DarkTurquoise", "DarkViolet",
                "DeepPink", "DeepSkyBlue", "DimGray", "DodgerBlue", "Firebrick", "FloralWhite", "ForestGreen", "Fuchsia", 
                "Gainsboro", "GhostWhite", "Gold", "Goldenrod", "Gray", "Green", "GreenYellow", "Honeydew", "HotPink", "IndianRed",
                "Indigo", "Ivory", "Khaki", "Lavender", "LavenderBlush", "LawnGreen", "LemonChiffon", "LightBlue", "LightCoral", 
                "LightCyan", "LightGoldenrodYellow", "LightGray", "LightGreen", "LightPink", "LightSalmon", "LightSeaGreen", 
                "LightSkyBlue", "LightSlateGray", "LightSteelBlue", "LightYellow", "Lime", "LimeGreen", "Linen", "Magenta", "Maroon", 
                "MediumAquamarine", "MediumBlue", "MediumOrchid", "MediumPurple", "MediumSeaGreen", "MediumSlateBlue", "MediumSpringGreen",
                "MediumTurquoise", "MediumVioletRed", "MidnightBlue", "MintCream", "MistyRose", "Moccasin", "NavajoWhite", "Navy", "OldLace",
                "Olive", "OliveDrab", "Orange", "OrangeRed", "Orchid", "PaleGoldenrod", "PaleGreen", "PaleTurquoise", "PaleVioletRed", "PapayaWhip",
                "PeachPuff", "Peru", "Pink", "Plum", "PowderBlue", "Purple", "Red", "RosyBrown", "RoyalBlue", "SaddleBrown", "Salmon", "SandyBrown", 
                "SeaGreen", "SeaShell", "Sienna", "Silver", "SkyBlue", "SlateBlue", "SlateGray", "Snow", "SpringGreen", "SteelBlue", "Tan", "Teal", 
                "Thistle", "Tomato", "Turquoise", "Violet", "Wheat", "White", "WhiteSmoke", "Yellow", "YellowGreen" };

            
        }     

        string ColorTransformer(int rgb)
        {

            System.Drawing.Color _color;

            Array _colorList = Enum.GetValues(typeof(KnownColor));
            foreach (KnownColor c in _colorList)
            {
                _color = System.Drawing.Color.FromKnownColor(c);
                if (rgb == _color.ToArgb() && !_color.IsSystemColor) 
                {
                    return _color.Name;
                }
            }
            return "";

        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextRange textRange = new TextRange(RichTextBox.Document.ContentStart, RichTextBox.Document.ContentEnd);
            if (_init)
            {
                _wordCounter = Regex.Matches(textRange.Text, @"[\S]+").Count;
                WordCount.Text = "Word count: " + _wordCounter.ToString();
            }
            
        }

    }    
}
