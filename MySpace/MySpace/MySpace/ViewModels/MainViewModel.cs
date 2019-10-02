using MySpace.Entities;
using MySpace.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MySpace.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        readonly DataService _dataService;
        public MainViewModel()
        {
            OpenFlyoutCommand = new Command(OpenFlyoutCommandExecute);
            _dataService = new DataService();

            LoadPhotoOfTheDay();
        }

        private void OpenFlyoutCommandExecute()
        {
            AppShell.Current.FlyoutIsPresented = true;
        }

        public Command OpenFlyoutCommand { get; set; }

        private async void LoadPhotoOfTheDay()
        {
            var photo = await _dataService?.GetPhotoOfTheDayAsync();

            if (photo != null)
            {
                Url = photo.url;
                Title = photo.title;
                Explanation = photo.explanation;
            }
        }
        public string SpaceShuttle
        {
            get
            {
                return "\uf197";
            }
        }

        private string _url;

        public string Url { get => _url; set => SetProperty(ref _url, value); }

        private string _title;

        public string Title { get => _title; set => SetProperty(ref _title, value); }

        private string _explanation;

        public string Explanation { get => _explanation; set => SetProperty(ref _explanation, value); }
    }
}
