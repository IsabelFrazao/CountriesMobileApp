using CountriesMobileApp.Common.Entities;
using CountriesMobileApp.Entities;
using CountriesMobileApp.ItemViewModels;
using CountriesMobileApp.Responses;
using CountriesMobileApp.Services;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace CountriesMobileApp.ViewModels
{
    public class CountriesPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;

        private bool _isRunning;

        private string _search;
        private List<Country> _myCountries;
        private DelegateCommand _searchCommand;

        private ObservableCollection<CountryItemViewModel> _countries;

        public CountriesPageViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = "Country";
            LoadCountriesAsync();
        }

        public DelegateCommand SearchCommand => _searchCommand ?? (_searchCommand = new DelegateCommand(ShowCountries));

        public string Search
        {
            get => _search;
            set
            {
                SetProperty(ref _search, value);
                ShowCountries();
            }
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public ObservableCollection<CountryItemViewModel> Countries
        {
            get => _countries;
            set => SetProperty(ref _countries, value);
        }

        private async void LoadCountriesAsync()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Connection Error", "Accept");
                return;
            }

            IsRunning = true;

            string url = App.Current.Resources["UrlAPI"].ToString();
            Response response = await _apiService.GetListAsync<Country>(
                url,
                "/rest",
                "/v2");

            IsRunning = false;

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }

            _myCountries = (List<Country>)response.Result;           
            ShowCountries();
        }

        private void ShowCountries()
        {
            if (string.IsNullOrEmpty(Search))
            {
                Countries = new ObservableCollection<CountryItemViewModel>(_myCountries.Select(c =>
                new CountryItemViewModel(_navigationService)
                {
                    Name = !string.IsNullOrEmpty(c.Name) ? c.Name : "N/A",
                    Capital = !string.IsNullOrEmpty(c.Capital) ? c.Capital : "N/A",
                    Region = !string.IsNullOrEmpty(c.Region) ? c.Region : "N/A",
                    Subregion = !string.IsNullOrEmpty(c.Subregion) ? c.Subregion : "N/A",
                    Gini = !string.IsNullOrEmpty(c.Gini) ? c.Gini : "N/A",
                    Area = c.Area,
                    Population = c.Population,
                    Flag = c.Flag,
                    Languages = c.Languages,
                })
                    .ToList());
            }
            else
            {
                Countries = new ObservableCollection<CountryItemViewModel>(_myCountries.Select(c =>
                 new CountryItemViewModel(_navigationService)
                 {
                     Name = !string.IsNullOrEmpty(c.Name) ? c.Name : "N/A",
                     Capital = !string.IsNullOrEmpty(c.Capital) ? c.Capital : "N/A",
                     Region = !string.IsNullOrEmpty(c.Region) ? c.Region : "N/A",
                     Subregion = !string.IsNullOrEmpty(c.Subregion) ? c.Subregion : "N/A",
                     Gini = !string.IsNullOrEmpty(c.Gini) ? c.Gini : "N/A",
                     Area = c.Area,
                     Population = c.Population,
                     Flag = c.Flag,
                     Languages = c.Languages,
                 })
                    .Where(p => p.Name.ToLower().Contains(Search.ToLower()))
                    .ToList());
            }
        }    
    }
}
