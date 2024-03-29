﻿using MySpace.Entities;
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
        public MarsRoverPhotosViewModel()
        {
            _dataService = new DataService();
            LoadPhotos();
        }

        private async Task LoadPhotos()
        {
            var photosRoot = await _dataService.GetRoverPhotosAsync(1000, 1);

            Photos = new ObservableCollection<MarsRoverPhoto>(photosRoot.photos);
        }

        public ObservableCollection<MarsRoverPhoto> Photos { get; set; }
    }
}
