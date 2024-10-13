using System.Windows;
using System.Windows.Input;
using Bibliotekarz.Data.Model;
using Bibliotekarz.Services;
using Bibliotekarz.Services.DTOs;
using CommunityToolkit.Mvvm.Input;

namespace Bibliotekarz.App.Views;

/// <summary>
/// Interaction logic for BookWindow.xaml
/// </summary>
public partial class BookWindow : Window
{
    private BookService bookService = new();
    public BookWindow()
    {
        InitializeComponent();
        DataContext = this;
    }

    public string BookTitle { get; set; }

    public string Author { get; set; }

    public int PageCount { get; set; }

    public bool IsBorrowed { get; set; }

    public ICommand SaveCommand => new RelayCommand(Save);

    private void Save()
    {
        bookService.AddBook(new BookDto
        {
            Author = Author,
            Title = BookTitle,
            PageCount = PageCount,
            IsBorrowed = IsBorrowed
        });

        DialogResult = true;
        Close();
    }
}