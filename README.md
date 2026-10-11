# Przepisy

Aplikacja WPF do zarządzania przepisami kulinarnymi.

## Autor

Exelka

## Temat

Książka kucharska — aplikacja do przechowywania i zarządzania przepisami.

## Opis

Aplikacja pozwala na dodawanie, edytowanie, usuwanie i przeglądanie przepisów kulinarnych. Dane są zapisywane w pliku JSON. Projekt wykonany w wzorcu MVVM (Model – ViewModel – View).

## Wymagania

- .NET 6.0 SDK
- Windows

## Uruchomienie

```bash
cd Przepisy
dotnet run
```

## Funkcje

- Dodawanie nowych przepisów
- Edytowanie istniejących przepisów
- Usuwanie przepisów (z potwierdzeniem)
- Wyszukiwanie po nazwie
- Filtrowanie po kategorii
- Sortowanie po nazwie, czasie, trudności i kategorii
- Podgląd szczegółów przepisu (składniki i instrukcje)
- Ciemny motyw
- Zapis do pliku JSON

## Struktura

- `Models/Recipe.cs` - model danych (INotifyPropertyChanged)
- `ViewModels/MainViewModel.cs` - logika listy przepisów
- `ViewModels/RecipeEditViewModel.cs` - logika okna edycji
- `ViewModels/RelayCommand.cs` - implementacja ICommand
- `Views/MainWindow.xaml` - ekran główny
- `Views/RecipeEditWindow.xaml` - okno dodawania/edycji
- `Views/RecipeDetailsWindow.xaml` - okno szczegółów
- `Views/ConfirmDialog.xaml` - okno potwierdzenia
- `Services/RecipeService.cs` - obsługa zapisu/odczytu JSON
- `Resources/Styles.xaml` - style aplikacji (w tym szablony ComboBox i TabControl)
- `Resources/CardStyles.xaml` - style kart przepisów
- `Resources/Animations.xaml` - animacje
- `App.xaml` - kolory motywu (jasny i ciemny)
