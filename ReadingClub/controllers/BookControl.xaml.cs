using ReadingClub.models;
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

    }
}
