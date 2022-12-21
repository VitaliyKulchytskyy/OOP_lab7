using System;
using Block3.Models;
using DynamicData.Binding;

namespace Block3.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public IObservableCollection<string> Formats { get; set; }

        public IObservableCollection<string> FillFormatsCollection()
        {
            IObservableCollection<string> output = new ObservableCollectionExtended<string>();
            OutputFormat[] temp = (OutputFormat[]) Enum.GetValues(typeof(OutputFormat));
            
            foreach(var getFormat in temp)
                output.Add(getFormat.ToComboBoxString());

            return output;
        }

        public MainWindowViewModel()
        {
            Formats = FillFormatsCollection();
        }
    }
}