using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Block3.Models;

namespace Block3.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_OnClick(object? sender, RoutedEventArgs e)
        {
            DateTime firstDate = DateTime.Parse(this.Find<TextBox>("GetFirstDate").Text);
            DateTime secondDate = DateTime.Parse(this.Find<TextBox>("GetSecondDate").Text);
            OutputFormat format = ((string) this.Find<ComboBox>("FormatBox").SelectedItem!).FromComboBoxString();
            var answer = this.Find<TextBox>("PrintOutput");
            answer.Text = format.ConvertToFormat(secondDate.Subtract(firstDate));
        }
    }
}