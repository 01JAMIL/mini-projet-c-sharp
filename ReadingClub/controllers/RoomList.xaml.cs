using ReadingClub.models;
using System.Windows.Controls;

namespace ReadingClub.Controllers
{
    /// <summary>
    /// Logique d'interaction pour RoomList.xaml
    /// </summary>
    public partial class RoomList : UserControl
    {
        public event EventHandler RoomNavigateButtonClicked;
        private List<Room> rooms = new List<Room>();
        public RoomList()
        {
            InitializeComponent();
            LoadRooms();
            PopulateRooms();
        }

        private void LoadRooms()
        {
            // This will be replaced by the rooms saved in the database
            rooms = new List<Room>
            {
                new Room(1, "Fantasy", "Enter Mystic Haven, a cozy chamber where fantasy becomes reality. " +
                "Surrounded by walls depicting mythical creatures and enchanted forests, " +
                "this room is a sanctuary for dreamers and adventurers alike. " +
                "A small library of fantasy classics invites you to immerse yourself in otherworldly tales, " +
                "while the soft, mystical ambiance sets the perfect scene for a magical escape.", "gn.jpg", 120, 50),

                new Room(2, "Mystery", "Noir Escape offers an intriguing, detective-themed experience. " +
                "Its décor features vintage detective paraphernalia and classic mystery novels. " +
                "Dim lighting and shadowy corners create a mysterious atmosphere, " +
                "perfect for anyone who loves piecing together clues and solving enigmas. " +
                "It's like stepping into your favorite whodunit story.", "mystery.jpg", 80, 10),
            };
        }

        private void PopulateRooms()
        {
            foreach (var room in rooms)
            {
                RoomControl roomControl = new RoomControl();
                roomControl.SetRoomData(room);
                roomControl.NavigateButtonClicked += (sender, e) =>
                {
                    RoomNavigateButtonClicked?.Invoke(this, EventArgs.Empty);
                };
                roomsList.Children.Add(roomControl);
            }
        }
    }
}
