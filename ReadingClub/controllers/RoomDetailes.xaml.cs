using ReadingClub.database;
using ReadingClub.models;
using ReadingClub.utils.shared;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ReadingClub.Controllers
{
    /// <summary>
    /// Logique d'interaction pour RoomDetailes.xaml
    /// </summary>
    public partial class RoomDetailes : UserControl
    {
        public event EventHandler BackButtonClicked;
        public event EventHandler RoomJoined;
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
            bool isInRoom = DatabaseHelper.IsUserInRoom(roomId, GlobalData.LoggedInUser.id);
            //MessageBox.Show("Your status is " + isInRoom.ToString() + "Room ID => " + roomId.ToString() + "User ID => " + GlobalData.LoggedInUser.id.ToString(), "STATUS");
            
            if (isInRoom)
            {
                GetBookList();
                PopulateBooks();
                joinButton.IsEnabled = false;
                joinButtonText.Text = "Joined";
                joinButtonIcon.Content = "\uf00c";
                joinButtonText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#17223B"));
                joinButtonIcon.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#17223B"));
            } else
            {
                joinButtonText.Text = "Join Room";
                joinButtonIcon.Content = "\uF090";
            }
            
            roomName.Text = this.CurrentRoom.Name;
            roomDescription.Text = this.CurrentRoom.Description;
            roomBooksNumber.Text = DatabaseHelper.RoomNumberOfBooks(roomId) + "  Book (s)";
            roomMembersNumber.Text = DatabaseHelper.RoomNumberOfMembers(roomId) + "  Members (s)";
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
            booksList.Children.Clear();
            foreach (var book in this.Books)
            {
                BookControl bookControl = new BookControl();
                bookControl.SetBookData(book);
                booksList.Children.Add(bookControl);
            }
        }

        private void OnJoinButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                DatabaseHelper.JoinRoom(this.RoomId, GlobalData.LoggedInUser.id);

                joinButton.IsEnabled = false;
                joinButtonText.Text = "Joined";
                joinButtonIcon.Content = "\uf00c";
                joinButtonText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#17223B"));
                joinButtonIcon.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#17223B"));


                roomMembersNumber.Text = DatabaseHelper.RoomNumberOfMembers(this.RoomId) + "  Members (s)";

                GetBookList();
                PopulateBooks();

                RoomJoined?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error joining room: " + ex.Message);
            }
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            BackButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
