using ReadingClub.database;
using ReadingClub.models;
using ReadingClub.utils.shared;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ReadingClub.Controllers
{
    /// <summary>
    /// Logique d'interaction pour RoomDetailes.xaml
    /// </summary>
    public partial class RoomDetailes : UserControl
    {
        public event EventHandler BackButtonClicked;
        public int RoomId { get; set; }
        private Room CurrentRoom;
        private List<Book> Books;
        public RoomDetailes()
        {
            InitializeComponent();
        }

        public void SetRoomId(int roomId)
        {
            this.RoomId = roomId;
            this.CurrentRoom = DatabaseHelper.GetRoomById(roomId);
            GetBookList();
            PopulateBooks();
            roomName.Text = this.CurrentRoom.Name;
            roomDescription.Text = this.CurrentRoom.Description;
            roomBooksNumber.Text = this.CurrentRoom.numberOfBooks.ToString() + "  Book (s)";
            roomMembersNumber.Text = this.CurrentRoom.numberOfMembers.ToString() + "  Members (s)";
            try
            {
                // Construct the full path for the image
                var imagePath = new Uri($"pack://application:,,,/assets/images/{CurrentRoom.Image}", UriKind.Absolute);
                BitmapImage bitmap = new BitmapImage(imagePath);

                roomImage.Source = bitmap;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading image: " + ex.Message);
            }

        }

        private void GetBookList ()
        {
            this.Books = DatabaseHelper.GetBooks(this.RoomId);
        }

        private void PopulateBooks()
        {
            foreach (var room in this.Books)
            {
                BookControl bookControl = new BookControl();
                bookControl.SetBookData(room);
                booksList.Children.Add(bookControl);
                /*roomControl.NavigateButtonClicked += (sender, e) =>
                {
                    RoomNavigateButtonClicked?.Invoke(this, new RoomEventArgs(room.ID));
                };*/

            }
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            BackButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
