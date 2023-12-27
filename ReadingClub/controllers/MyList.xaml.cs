using ReadingClub.database;
using ReadingClub.models;
using ReadingClub.utils.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReadingClub.Controllers
{
    /// <summary>
    /// Interaction logic for MyList.xaml
    /// </summary>
    public partial class MyList : UserControl
    {
        private List<Book> WantToReadBooks;
        private List<Book> CurrentlyReadingBooks { get; set; }
        private List<Book> FavoriteBooks { get; set; }

        public event EventHandler GoBackButtonClicked;
        public MyList()
        {
            InitializeComponent();
            GetBookList();
            PopulateWantToReadBooks();
            DataContext = this;
            PopulateCurrentlyReadingBooks();
            PopulateFavoriteBooks();
        }


        private void GetBookList()
        {
            var allBooks = DatabaseHelper.GetAllBooks();

            this.WantToReadBooks = allBooks.Where(book => book.WantToRead).ToList();
            this.CurrentlyReadingBooks = allBooks.Where(book => book.CurrentlyReading).ToList();
            this.FavoriteBooks = allBooks.Where(book => book.Favorite).ToList();
        
        }


        private void PopulateWantToReadBooks()
        {
            WantToReadList.Children.Clear();
            foreach (var book in WantToReadBooks)
            {
                BookControl bookControl = new BookControl();
                bookControl.SetBookData(book);
                WantToReadList.Children.Add(bookControl);
            }
        }

        private void PopulateCurrentlyReadingBooks()
        {
            CurrentlyReadingList.Items.Clear();
            foreach (var book in CurrentlyReadingBooks)
            {
                BookControl bookControl = new BookControl();
                bookControl.SetBookData(book);
                CurrentlyReadingList.Items.Add(bookControl);
            }
        }

        private void PopulateFavoriteBooks()
        {
            FavoritesList.Items.Clear();
            foreach (var book in FavoriteBooks)
            {
                BookControl bookControl = new BookControl();
                bookControl.SetBookData(book);
                FavoritesList.Items.Add(bookControl);
            }
        }


        private void GoBack(object sender, RoutedEventArgs e)
        {
            // Trigger the event
            GoBackButtonClicked?.Invoke(this, EventArgs.Empty);
        }


        
    }
}
