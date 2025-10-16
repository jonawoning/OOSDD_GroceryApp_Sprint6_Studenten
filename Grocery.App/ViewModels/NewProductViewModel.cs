using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.App.ViewModels;

public partial class NewProductViewModel : BaseViewModel
{
    // Hier moet code komen waar je een nieuw product kan aanmaken en alleen de role Admin dit kan doen
    private readonly IProductService _productService;
    public String Name { get; set; }
    public int Stock { get; set; }
    public DateOnly ShelfLife { get; set; }
    public decimal Price { get; set; }

    [ObservableProperty]
    private string errorMessage;

    [ObservableProperty]
    private string message;
    
    public event Action? OnProductAdd;
    
    public NewProductViewModel(IProductService productService)
    {
        _productService = productService;
        ShelfLife = DateOnly.FromDateTime(DateTime.Today);
    }

    [RelayCommand]
    public void AddProduct()
    {
        ErrorMessage = "";
        Message = "";
        if (productExists(Name))
        {
            ErrorMessage = "Product naam bestaat al, kies een andere naam.";
            return;
        }
        if (Stock < 0)
        {
            ErrorMessage = "Stock kan niet negatief zijn.";
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

        Product product = new Product(0, Name, Stock, ShelfLife, Price);
        _productService.Add(product);
        Message = "Product succesvol toegevoegd!";
        // Activeer het event
        OnProductAdd?.Invoke();
        // Navigeer terug naar producten scherm of vorige scherm
        Shell.Current.GoToAsync("..");
    }
    
    private bool productExists(string name)
    {
        return _productService.ProductExists(name);
    }
    
}