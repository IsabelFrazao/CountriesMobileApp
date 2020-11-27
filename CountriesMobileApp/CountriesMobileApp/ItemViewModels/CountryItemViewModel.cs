using CountriesMobileApp.Common.Entities;
using CountriesMobileApp.Responses;
using CountriesMobileApp.Services;
using CountriesMobileApp.Views;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CountriesMobileApp.ItemViewModels
{
    public class CountryItemViewModel : Country
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectProductCommand;
        
        public IApiService _apiService;

        public CountryItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectProductCommand => _selectProductCommand ??
            (_selectProductCommand = new DelegateCommand(SelectProductAsync));

        private async void SelectProductAsync()
        {
            NavigationParameters parameters = new NavigationParameters
            {
               { "country", this }
            };

            await _navigationService.NavigateAsync(nameof(CountryDetailPage), parameters);
        }        
    }
}
