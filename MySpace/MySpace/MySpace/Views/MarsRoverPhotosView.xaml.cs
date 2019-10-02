using MySpace.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MySpace.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MarsRoverPhotosView : ContentPage
    {
        public MarsRoverPhotosView()
        {
            InitializeComponent();

            this.BindingContext = new MarsRoverPhotosViewModel();
        }
    }
}