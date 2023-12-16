using ReadingClub.database;
using ReadingClub.models;
using ReadingClub.utils.shared;
using System.Windows.Controls;

namespace ReadingClub.Controllers
{
    /// <summary>
    /// Logique d'interaction pour RoomList.xaml
    /// </summary>
    public partial class RoomList : UserControl
    {
        public event EventHandler<RoomEventArgs> RoomNavigateButtonClicked;
        private List<Room> rooms = new List<Room>();
        public RoomList()
        {
            InitializeComponent();
            LoadRooms();
            PopulateRooms();
        }

        private void LoadRooms()
        {
            rooms = DatabaseHelper.GetRooms(GlobalData.LoggedInUser.id);
        }

        private void PopulateRooms()
        {
            foreach (var room in rooms)
            {
                RoomControl roomControl = new RoomControl();
                roomControl.SetRoomData(room);
                roomControl.NavigateButtonClicked += (sender, e) =>
                {
                    RoomNavigateButtonClicked?.Invoke(this, new RoomEventArgs(room.ID));
                };
                roomsList.Children.Add(roomControl);
            }
        }
    }
}
