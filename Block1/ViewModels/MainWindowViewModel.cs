using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Block1.Models;
using DynamicData.Binding;

namespace Block1.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public IObservableCollection<String> ColorNames { get; set; }

        public IObservableCollection<String> FillColorNameCollection()
        {
            IObservableCollection<String> output = new ObservableCollectionExtended<string>();
            ColorName[] temp = (ColorName[]) Enum.GetValues(typeof(ColorName));
            
            foreach(var getColor in temp)
                output.Add(getColor.ToString());

            return output;
        }

        public MainWindowViewModel()
        {
            ColorNames = FillColorNameCollection();
        }
    }
}