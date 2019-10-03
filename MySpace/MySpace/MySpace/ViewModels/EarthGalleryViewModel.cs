using MySpace.Entities;
using MySpace.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MySpace.ViewModels
{
    public class EarthGalleryViewModel : BaseViewModel
    {
        readonly DataService _dataService;

        public EarthGalleryViewModel()
        {
            _dataService = new DataService();

            LoadPhotos();
        }

        private async Task LoadPhotos()
        {
            var photosRoot = await _dataService.GetEarthImagesMetadataAsync();

            Photos = new ObservableCollection<EarthImageMetaData>(photosRoot);
        }

        public ObservableCollection<EarthImageMetaData> Photos { get; set; }
    }
}
