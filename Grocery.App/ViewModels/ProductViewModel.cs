using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.App.Views;

namespace Grocery.App.ViewModels
{
    public partial class ProductViewModel : BaseViewModel
    {
        private readonly IProductService _productService;
        public ObservableCollection<Product> Products { get; set; }
        public Client Client { get; set; }

        public ProductViewModel(IProductService productService, GlobalViewModel globalViewModel)
        {
            _productService = productService;
            Products = [];
            Client = globalViewModel.Client;
            foreach (Product p in _productService.GetAll()) Products.Add(p);
        }
        
        public void RefreshProducts()
        {
            Products.Clear();
            foreach (Product p in _productService.GetAll())
            {
                Products.Add(p);
            }
        }

        [RelayCommand]
        public async Task ShowNewProduct()
        {
            if (Client.Role == Role.Admin)
            {
                // Geef refreshproducts mee zodat na toevoegen de lijst ververst wordt
                NewProductViewModel newProductViewModel = new NewProductViewModel(_productService);
                newProductViewModel.OnProductAdd += RefreshProducts;
                await Shell.Current.Navigation.PushAsync(new NewProductView(newProductViewModel));
            }
        }
    }
}
