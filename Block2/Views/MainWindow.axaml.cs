using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Block2.Models;

namespace Block2.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_OnClick(object? sender, RoutedEventArgs e)
        {
            int percent = int.Parse(this.Find<TextBox>("GetPercent").Text);
            StudentOfKN getStudentByName = Enum.Parse<StudentOfKN>((string) this.Find<ComboBox>("StudentsBox").SelectedItem!);
            bool getReport = StudentCalc.IsOverPercentGroup(getStudentByName, percent);
            this.Find<Label>("StudentReport").Content = (getReport)
                ? $"This student done more then {percent}% of homeworks"
                : $"This student done less then {percent}% of homeworks";
        }
    }
}