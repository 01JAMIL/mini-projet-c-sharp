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
    /// Logique d'interaction pour BookControl.xaml
    /// </summary>
    public partial class BookControl : UserControl
    {
        public event EventHandler<BookEventArgs> AddButtonClicked;
        public event EventHandler<BookEventArgs> ReadButtonClicked;
        public event EventHandler<BookEventArgs> FavButtonClicked;
        public Book BookData { get; set; }
        public BookControl()
        {
            InitializeComponent();
        }

        public void SetBookData(Book book)
        {
            BookData = book;
            bookName.Text = book.Name;
            bookDescription.Text = book.Description;
            bookNumberOfLikes.Text = book.NumberOfLikes.ToString() + " Like (s)";
            bookAuthor.Text = "By " + book.AuthorName;
            bookNumberOfPages.Text = book.NumberOfPages.ToString() + " Pages"; 

            try
            {
                var imagePath = new Uri($"pack://application:,,,/assets/images/{book.Image}", UriKind.RelativeOrAbsolute);
                BitmapImage image = new BitmapImage(imagePath);
                bookImage.Source = image;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading image: " + ex.Message);
            }
        }

        public void OnClickAddButton(object sender, RoutedEventArgs e)
        {
            BookData.WantToRead = true;
            BookData.CurrentlyReading = false;
            BookData.Favorite = false;

            UpdateBookStatusInDatabase(BookData);

            AddButtonClicked?.Invoke(this, new BookEventArgs(BookData.ID));

        }

        public void OnClickReadButton(object sender, RoutedEventArgs e)
        {
            BookData.WantToRead = false;
            BookData.CurrentlyReading = true;
            BookData.Favorite = false;

            UpdateBookStatusInDatabase(BookData);

            ReadButtonClicked?.Invoke(this, new BookEventArgs(BookData.ID));

        }

        public void OnClickFavButton(object sender, RoutedEventArgs e)
        {
            BookData.Favorite = true;
            BookData.CurrentlyReading = false;
            BookData.WantToRead = false;

            UpdateBookStatusInDatabase(BookData);

            FavButtonClicked?.Invoke(this, new BookEventArgs(BookData.ID));

        }

        private void UpdateBookStatusInDatabase(Book book)
        {
            try
            {
                DatabaseHelper.UpdateBookStatus(book.ID, book.WantToRead, book.CurrentlyReading, book.Favorite);
                Console.WriteLine("Book status updated successfully in the database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating book status in the database: " + ex.Message);
            }
        }




    }
}
