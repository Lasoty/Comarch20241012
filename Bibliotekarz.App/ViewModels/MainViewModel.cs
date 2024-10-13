using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Bibliotekarz.App.Views;
using Bibliotekarz.Services;
using Bibliotekarz.Services.DTOs;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Bibliotekarz.App.ViewModels;

[INotifyPropertyChanged]
public partial class MainViewModel : BaseViewModel
{
    BookService bookService = new();
    public MainViewModel()
    {
        FilterText = "Hello world!";
        GetAllBooks();
    }

    public string FilterText { get; set; }

    public ObservableCollection<BookDto> Books { get; set; } = [];


    public ICommand CloseCommand => new RelayCommand(CloseApp);

    private void CloseApp()
    {
        Environment.Exit(0);
    }

    public ICommand AddBookCommand => new RelayCommand(AddBook);

    private void AddBook()
    {
        BookWindow bookWindow = new();
        bookWindow.ShowDialog();

        GetAllBooks();
    }

    private void GetAllBooks()
    {
        var books = bookService.GetAllBooks();
        Books.Clear();
        foreach (var book in books)
        {
            Books.Add(book);
        }
    }
}