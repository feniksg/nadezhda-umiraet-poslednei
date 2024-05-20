using Prism.Events;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMuseum.Shared.Events;

namespace TheMuseum.ViewModels
{
    internal class MainWindowViewModel : ReactiveObject
    {
        [Reactive] public double Height { get; set; } = 600;
        [Reactive] public double Width { get; set; } = 1000;
        public MainWindowViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<BiographyOpenEvent>().Subscribe(() =>
            {
                Height = 1080;
                Width = 1280;
            });
        }
    }
}
