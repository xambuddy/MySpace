using MySpace.Entities;
using MySpace.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace MySpace.ViewModels
{
    public class MarsRoverPhotosViewModel : BaseViewModel
    {
        readonly DataService _dataService;

        public int Page { get; set; }
        public MarsRoverPhotosViewModel()
        {
            RefreshCommand = new Command(RefreshCommandExecute);
            _dataService = new DataService();

            Page = 1;
            RefreshCommandExecute();
        }

        private void RefreshCommandExecute()
        {
            LoadMarsRoverPhotos();
            Page++;
        }

        public ObservableCollection<MarsRoverPhoto> Photos { get; set; }

        public Command RefreshCommand { get; set; }

        private bool _isRefreshing;

        public bool IsRefreshing { get => _isRefreshing; set => SetProperty(ref _isRefreshing, value); }

        private async void LoadMarsRoverPhotos()
        {
            var photosRoot = await _dataService?.GetRoverPhotosAsync(1000, Page);

            if (photosRoot != null)
            {
                Photos = new ObservableCollection<MarsRoverPhoto>(photosRoot.photos);
                IsRefreshing = false;
            }
        }
    }
}
