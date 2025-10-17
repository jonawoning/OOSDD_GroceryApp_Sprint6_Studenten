using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using Grocery.App.Views;

namespace Grocery.App.ViewModels;

public partial class ProductViewModel : BaseViewModel
{
    private readonly IProductService _productService;

    public ObservableCollection<Product> Products { get; } = new();

    public Client Client { get; }

    public ProductViewModel(IProductService productService, GlobalViewModel globalViewModel)
    {
        _productService = productService;
        Client = globalViewModel.Client;
        LoadProducts();
    }

    private void LoadProducts()
    {
        Products.Clear();
        foreach (var product in _productService.GetAll())
        {
            Products.Add(product);
        }
    }

    public void RefreshProducts() => LoadProducts();

    [RelayCommand]
    public async Task ShowNewProduct()
    {
        if (Client.Role != Role.Admin)
        {
            await Shell.Current.DisplayAlert("Toegang geweigerd", "Alleen admins kunnen nieuwe producten toevoegen.", "OK");
            return;
        }

        var newProductViewModel = new NewProductViewModel(_productService);
        newProductViewModel.OnProductAdd += RefreshProducts;

        await Shell.Current.Navigation.PushAsync(new NewProductView(newProductViewModel));
    }
}