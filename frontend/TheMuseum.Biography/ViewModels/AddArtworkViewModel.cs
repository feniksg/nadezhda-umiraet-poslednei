using Prism.Commands;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Windows;
using System.Windows.Input;
using TheMuseum.Biography.Models;

namespace TheMuseum.Biography.ViewModels
{
    public class AddArtworkViewModel : ReactiveObject
    {
        public AddArtworkViewModel()
        {
            AddCommand = new DelegateCommand(Add);
            CancelCommand = new DelegateCommand(Cancel);
        }

        [Reactive] public string Title { get; set; }
        [Reactive] public string Description { get; set; }

        public ICommand AddCommand { get; }
        public ICommand CancelCommand { get; }

        private void Add()
        {
            var newArtwork = new ArtworkModel
            {
                Title = this.Title,
                Description = this.Description
            };
            // Передача данных обратно в вызывающий код
            Application.Current.Windows[0].Tag = newArtwork;
            Application.Current.Windows[0].DialogResult = true;
            Application.Current.Windows[0].Close();
        }

        private void Cancel()
        {
            Application.Current.Windows[0].DialogResult = false;
            Application.Current.Windows[0].Close();
        }
    }
}
