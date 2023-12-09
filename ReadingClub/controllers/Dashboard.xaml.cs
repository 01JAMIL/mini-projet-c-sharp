using ReadingClub.models;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace ReadingClub.Controllers
{
    /// <summary>
    /// Logique d'interaction pour Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        private User loggedInUser;
        private List<Room> rooms;
        public Dashboard(User user)
        {
            InitializeComponent();
            loggedInUser = user;

            LoadUserData();
            LoadRooms();
            PopulateRooms();
        }

        private void LoadUserData()
        {
            if (loggedInUser != null)
            {
                fullNameTextBlock.Text = loggedInUser.firstName + " " + loggedInUser.lastName;
                userNameTextBlock.Text = loggedInUser.username;
                userFirstLetter.Text = loggedInUser.firstName.ToUpper().Substring(0, 1);
            }
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
                "while the soft, mystical ambiance sets the perfect scene for a magical escape.", "gn.jpg"),

                new Room(2, "Mystery", "Noir Escape offers an intriguing, detective-themed experience. " +
                "Its décor features vintage detective paraphernalia and classic mystery novels. " +
                "Dim lighting and shadowy corners create a mysterious atmosphere, " +
                "perfect for anyone who loves piecing together clues and solving enigmas. " +
                "It's like stepping into your favorite whodunit story.", "mystery.jpg"),
            };
        }

        private void PopulateRooms()
        {
            foreach (var room in rooms)
            {
                RoomControl roomControl = new RoomControl();
                roomControl.SetRoomData(room);
                roomsList.Children.Add(roomControl);
            }
        }
    }
}
