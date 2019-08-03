namespace Shop.UIForms.ViewModels
{
    using Shop.Common.Models;
    using Shop.Common.Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class ProductsViewModel : BaseViewModel
    {
        private readonly ApiService _apiService;
        private ObservableCollection<Product> _products;
        private bool _isRefreshing;

        public ObservableCollection<Product> Products
        {
            get => _products;
            set => SetValue(ref _products, value);
        }

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetValue(ref _isRefreshing, value);
        }

        public ProductsViewModel()
        {
            _apiService = new ApiService();
            LoadProducts();
        }

        private async void LoadProducts()
        {
            IsRefreshing = true;

            var response = await _apiService.GetListAsync<Product>(
                "https://shopluis.azurewebsites.net",
                "/api",
                "/products");

            IsRefreshing = false;

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }

            var myProducts = (List<Product>)response.Resuult;

            Products = new ObservableCollection<Product>(myProducts);
        }
    }
}
