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
    /// Logique d'interaction pour RoomCircle.xaml
    /// </summary>
    public partial class RoomCircle : UserControl
    {
        public event EventHandler RoomClicked;
        public Room RoomData { get; set; }
        public RoomCircle()
        {
            InitializeComponent();
        }


        public void SetRoomData(Room room)
        {
            RoomData = room;
            roomName.Text = room.Name;

            try
            {
                var imagePath = new Uri($"pack://application:,,,/assets/images/{room.Image}", UriKind.RelativeOrAbsolute);
                BitmapImage image = new BitmapImage(imagePath);
                roomImage.ImageSource = image;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading image: " + ex.Message);
            }
        }

        private void GoToRoom(object sender, MouseButtonEventArgs e)
        {
            // When the border is clicked, raise the event
            RoomClicked?.Invoke(this, new EventArgs());
        }
    }
}
