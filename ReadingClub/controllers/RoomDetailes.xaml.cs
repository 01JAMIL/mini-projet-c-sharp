using ReadingClub.database;
using ReadingClub.models;
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

        public void SetRoomId(int roomId)
        {
            this.RoomId = roomId;
            this.CurrentRoom = DatabaseHelper.GetRoomById(roomId);
            roomName.Text = this.CurrentRoom.Name;
            roomDescription.Text = this.CurrentRoom.Description;
            roomBooksNumber.Text = this.CurrentRoom.numberOfBooks.ToString();
            roomMembersNumber.Text = this.CurrentRoom.numberOfMembers.ToString();
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
        public RoomDetailes()
        {
            InitializeComponent();
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            BackButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
