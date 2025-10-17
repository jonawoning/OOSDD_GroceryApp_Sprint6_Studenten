using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.App.ViewModels;

public partial class NewProductViewModel : BaseViewModel
{
    private readonly IProductService _productService;

    public string Name { get; set; } = string.Empty;
    public int Stock { get; set; }
    public DateOnly ShelfLife { get; set; } = DateOnly.FromDateTime(DateTime.Today);
    public decimal Price { get; set; }

    [ObservableProperty]
    private string _errorMessage = string.Empty;

    [ObservableProperty]
    private string _message = string.Empty;

    public event Action? OnProductAdd;

    public NewProductViewModel(IProductService productService)
    {
        _productService = productService;
    }

    [RelayCommand]
    public void AddProduct()
    {
        ClearMessages();

        if (Name.Length == 0 || !(Name.Length >= 3 && Name.Length <= 50))
        {
            ErrorMessage = "Productnaam moet tussen de 3 en 50 tekens lang zijn.";
            return;
        }

        if (_productService.ProductExists(Name))
        {
            ErrorMessage = "Productnaam bestaat al, kies een andere naam.";
            return;
        }

        if (Stock < 0)
        {
            ErrorMessage = "Voorraad kan niet negatief zijn.";
            return;
        }

        if (Price < 0)
        {
            ErrorMessage = "Prijs kan niet negatief zijn.";
            return;
        }

        if (ShelfLife < DateOnly.FromDateTime(DateTime.Today))
        {
            ErrorMessage = "Houdbaarheidsdatum kan niet in het verleden liggen.";
            return;
        }

        try
        {
            var product = new Product(0, Name, Stock, ShelfLife, Price);
            _productService.Add(product);

            Message = "Product succesvol toegevoegd!";
            OnProductAdd?.Invoke();
            Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Er is een fout opgetreden bij het toevoegen van het product: {ex.Message}";
        }
    }

    private void ClearMessages()
    {
        ErrorMessage = string.Empty;
        Message = string.Empty;
    }
}
