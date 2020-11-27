using CountriesMobileApp.Services;
using CountriesMobileApp.ViewModels;
using CountriesMobileApp.Views;
using Prism;
using Prism.Ioc;
using Syncfusion.Licensing;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace CountriesMobileApp
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            SyncfusionLicenseProvider.RegisterLicense("MzU4MDE4QDMxMzgyZTMzMmUzMEMxQlhNZDFKV281MCtMMWNtUGFsS2NzL2lnY2dRUXB4WUJQQ2pTcStMQkE9");

            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/CountriesPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //MzU4MDE4QDMxMzgyZTMzMmUzMEMxQlhNZDFKV281MCtMMWNtUGFsS2NzL2lnY2dRUXB4WUJQQ2pTcStMQkE9
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<CountriesPage, CountriesPageViewModel>();
            containerRegistry.RegisterForNavigation<CountryDetailPage, CountryDetailPageViewModel>();
        }
    }
}
