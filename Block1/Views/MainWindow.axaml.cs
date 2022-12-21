using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Block1.Models;

namespace Block1.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DisplayInputString(string inputString, ColorName stringColor)
        {
            var printString = this.Find<Label>("PrintString");
            printString.Content = inputString;
            printString.Foreground = new SolidColorBrush(Color.Parse(stringColor.ToString()));
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        { 
            ComboBox colorBox = this.Find<ComboBox>("ColorBox");
            ColorName getColorByName = Enum.Parse<ColorName>((string) this.Find<ComboBox>("ColorBox").SelectedItem);
            DisplayInputString(this.Find<TextBox>("GetString").Text, getColorByName);
        }
    }
}