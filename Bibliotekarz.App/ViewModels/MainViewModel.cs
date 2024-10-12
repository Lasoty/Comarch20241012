using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Bibliotekarz.App.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Bibliotekarz.App.ViewModels;

[INotifyPropertyChanged]
public partial class MainViewModel : BaseViewModel
{
    public MainViewModel()
    {
        FilterText = "Hello world!";

        GenerateFakeData();
    }

    public string FilterText { get; set; }

    public ObservableCollection<BookDto> Books { get; set; }


    public ICommand CloseCommand => new RelayCommand(CloseApp);

    private void CloseApp()
    {
        Environment.Exit(0);
    }

    private void GenerateFakeData()
    {
        Books =
        [
            new BookDto
            {
                Id = 1,
                Author = "J.K. Rowling",
                Title = "Harry Potter and the Philosopher's Stone",
                PageCount = 223,
                IsBorrowed = false,
                Borrower = null
            },
            new BookDto
            {
                Id = 2,
                Author = "J.K. Rowling",
                Title = "Harry Potter and the Chamber of Secrets",
                PageCount = 251,
                IsBorrowed = true,
                Borrower = new CustomerDto
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                }
            },
        ];
    }
}