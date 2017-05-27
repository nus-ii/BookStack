using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using SampleMVVM.Models;
using SampleMVVM.ViewModels;
using SampleMVVM.Views;

namespace SampleMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            List<Book> books = new List<Book>()
            {
                new Book("Колобок", null, 3,@"C:\MyTempImg\2594300.jpg"),
                new Book("CLR via C#", "Джеффри Рихтер", 1,@"C:\MyTempImg\1495061605.jpg"),
                new Book("Война и мир", "Л.Н. Толстой", 2,@"C:\MyTempImg\Voyna_i_mir.jpg"),       

            };

            MainView view = new MainView(); // создали View
            MainViewModel viewModel = new ViewModels.MainViewModel(books); // Создали ViewModel
            view.DataContext = viewModel; // положили ViewModel во View в качестве DataContext
            view.Show();
        }
    }
}
