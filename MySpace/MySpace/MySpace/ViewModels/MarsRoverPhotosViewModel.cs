using MySpace.Entities;
using MySpace.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MySpace.ViewModels
{
    public class MarsRoverPhotosViewModel : BaseViewModel
    {
        readonly DataService _dataService;

        public int Page { get; set; }
        public MarsRoverPhotosViewModel()
        {
            Photos = new ObservableCollection<EarthImageMetaData>();
            _dataService = new DataService();

            Page = 1;
            LoadMarsRoverPhotos();
        }

        public ObservableCollection<EarthImageMetaData> Photos { get; set; }

        private async void LoadMarsRoverPhotos()
        {
            var photosRoot = await _dataService?.GetEarthImagesMetadataAsync();

            if (photosRoot != null)
            {
                foreach(var photo in photosRoot)
                {
                    Photos.Add(photo);
                }
            }
        }
    }
}
