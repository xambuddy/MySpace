using MySpace.Entities;
using MySpace.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MySpace.ViewModels
{
    public class MarsRoverPhotosViewModel : BaseViewModel
    {
        readonly DataService _dataService;
        public MarsRoverPhotosViewModel()
        {
            _dataService = new DataService();

            LoadMarsRoverPhotos();
        }

        public ObservableCollection<MarsRoverPhoto> Photos { get; set; }

        private async void LoadMarsRoverPhotos()
        {
            var photosRoot = await _dataService?.GetRoverPhotosAsync(1000, 1);

            if (photosRoot != null)
            {
                Photos = new ObservableCollection<MarsRoverPhoto>(photosRoot.photos);
            }
        }
    }
}
