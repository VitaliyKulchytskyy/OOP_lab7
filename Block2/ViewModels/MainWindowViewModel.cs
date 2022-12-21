using System;
using Block2.Models;
using DynamicData.Binding;

namespace Block2.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public IObservableCollection<String> Students { get; set; }

        public IObservableCollection<String> FillStudentsCollection()
        {
            IObservableCollection<String> output = new ObservableCollectionExtended<string>();
            StudentOfKN[] temp = (StudentOfKN[]) Enum.GetValues(typeof(StudentOfKN));
            
            foreach(var getColor in temp)
                output.Add(getColor.ToString());

            return output;
        }

        public MainWindowViewModel()
        {
            Students = FillStudentsCollection();
        }
    }
}