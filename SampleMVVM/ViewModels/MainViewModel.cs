using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

using SampleMVVM.Commands;
using System.Collections.ObjectModel;
using SampleMVVM.Models;

namespace SampleMVVM.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public ObservableCollection<BookViewModel> BooksList { get; set; }

        public ObservableCollection<BookViewModel> SelectedBooksList
        {
            get
            {
                return sbList;
            }
            set
            {
                this.sbList = value;
                OnPropertyChanged("SelectedBooksList");
            }
        }

        private ObservableCollection<BookViewModel> sbList;

        private string fText;

        public string filterText
        {
            get { return fText; }
            set
            {
                fText = value;
                SelectedBooksList = FilterFunction(fText);
                OnPropertyChanged("filterText");
            }
        }

        public ObservableCollection<BookViewModel> FilterFunction(string ftext)
        {
            ObservableCollection<BookViewModel> result = new ObservableCollection<BookViewModel>();

            if (string.IsNullOrEmpty(fText))
                return this.BooksList;

            var t = fText.ToLower();
            foreach (var b in this.BooksList)
            {
                if (b.Title.ToLower().Contains(t))
                {
                    result.Add(b);
                }
            }

            return result;
        }

        //public void SelectNext()
        //{     
        //    SelectedBookIndex++;           
        //    SelectedBook = BooksList.ElementAt(SelectedBookIndex);
        //}

        //private BookViewModel sBook;
        //public BookViewModel SelectedBook
        //{
        //    get
        //    {
        //        return sBook;
        //    }
        //    set { sBook = value;
        //        OnPropertyChanged("SelectedBook");
        //    }
        //}

        private int SelectedBookIndex;

        #region Constructor

        public MainViewModel(List<Book> books)
        {
            BooksList = new ObservableCollection<BookViewModel>(books.Select(b => new BookViewModel(b)));
            SelectedBooksList = BooksList;
            // SelectedBook = BooksList.ElementAt(0);
            //SelectedBookIndex = 0;
        }

        #endregion

        //private DelegateCommand selectNextCommand;

        //public ICommand SelectNextBookCommand
        //{
        //    get
        //    {
        //        if (selectNextCommand == null)
        //        {
        //            selectNextCommand = new DelegateCommand(SelectNext, CanSelectNext);
        //        }
        //        return selectNextCommand;
        //    }
        //}

        //private bool CanSelectNext()
        //{
        //    if (SelectedBookIndex < BooksList.Count-1)
        //        return true;

        //    return false;
        //}
    }
}
