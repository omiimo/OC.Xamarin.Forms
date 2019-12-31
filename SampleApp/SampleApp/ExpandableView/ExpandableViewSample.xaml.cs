using OC.Xamarin.Forms.ExpandableView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.ExpandableView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpandableViewSample : ContentPage
    {
        public ExpandableViewSample()
        {
            InitializeComponent();
        }

        private ICommand _tapCommand;
        public ICommand TapCommand => _tapCommand ?? (_tapCommand = new Command(p =>
        {
            DisplayAlert("Tapped", p.ToString(), "Ok");
        }));

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ExpandableViewControl.StatusChanged += OnStatusChanged;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ExpandableViewControl.StatusChanged -= OnStatusChanged;
        }

        private async void OnStatusChanged(object sender, StatusChangedEventArgs e)
        {
            var rotation = 0;
            switch (e.Status)
            {
                case ExpandStatus.Collapsing:
                    break;
                case ExpandStatus.Expanding:
                    rotation = 180;
                    break;
                default:
                    return;
            }

            await arrow.RotateTo(rotation, 200, Easing.CubicInOut);
        }
    }
}