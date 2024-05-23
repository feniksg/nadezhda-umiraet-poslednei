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
        private readonly Window _window;
        public AddArtworkViewModel(Window window)
        {
            _window = window;


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

            _window.Tag = newArtwork;
            _window.DialogResult = true;
            _window.Close();
        }

        private void Cancel()
        {
            _window.DialogResult = false;
            _window.Close();
        }
    }
}
