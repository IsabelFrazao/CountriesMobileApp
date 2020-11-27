using CountriesMobileApp.Common.Entities;
using CountriesMobileApp.ItemViewModels;
using CountriesMobileApp.Responses;
using CountriesMobileApp.Services;
using Prism.Navigation;
using Syncfusion.XForms.ComboBox;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace CountriesMobileApp.ViewModels
{
    public class CountryDetailPageViewModel : ViewModelBase
    {
        private Country _country;

        public CountryDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Country";
        }

        public Country Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("country"))
            {
                Country = parameters.GetValue<Country>("country");
                Title = Country.Name;                
            }
        }
    }
}
