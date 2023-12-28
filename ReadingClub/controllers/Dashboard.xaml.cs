using ReadingClub.database;
using ReadingClub.models;
using ReadingClub.utils.shared;
using System.Windows;
using System.Windows.Controls;

namespace ReadingClub.Controllers
{
    /// <summary>
    /// Logique d'interaction pour Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        private int layout = 1;
        private int selectedRoomId;
        private List<Room> rooms = new List<Room>();
        public Dashboard(User user)
        {
            InitializeComponent();
            GlobalData.LoggedInUser = user;

            LoadUserData();

            UpdateLayout();

            LoadRooms();
            PopulateRooms();
        }

        private void LoadUserData()
        {
            if (GlobalData.LoggedInUser != null)
            {
                fullNameTextBlock.Text = GlobalData.LoggedInUser.firstName + " " + GlobalData.LoggedInUser.lastName;
                userNameTextBlock.Text = GlobalData.LoggedInUser.username;
                userFirstLetter.Text = GlobalData.LoggedInUser.firstName.ToUpper().Substring(0, 1);
            }
        }

        private new void UpdateLayout()
        {
            outletGrid.Children.Clear(); // Clear existing content

            switch (layout)
            {
                case 1:
                    var roomList = new RoomList();
                    roomList.RoomNavigateButtonClicked += new EventHandler<RoomEventArgs>(NavigateToRoomDetails);
                    roomList.BackButtonClicked += NavigateToMyList;
                    outletGrid.Children.Add(roomList);
                    break;

                case 2:
                    var roomDetails = new RoomDetailes();
                    roomDetails.SetRoomId(selectedRoomId);
                    roomDetails.BackButtonClicked += NavigateToRoomList;
                    roomDetails.RoomJoined += (sender, e) =>
                    {
                        LoadRooms();
                        PopulateRooms();
                    };
                    outletGrid.Children.Add(roomDetails);
                    break;
                case 3:
                    var myList = new MyList();
                    myList.GoBackButtonClicked += NavigateToRoomList;
                    outletGrid.Children.Add(myList);
                    break;
                
                default: break;
            }
        }

        private void LoadRooms()
        {
            rooms = DatabaseHelper.GetJoinedRooms(GlobalData.LoggedInUser.id);
        }
        private void PopulateRooms()
        {
            roomsList.Children.Clear();
            foreach (var room in rooms)
            {
                RoomCircle roomControl = new RoomCircle();
                roomControl.SetRoomData(room);
                roomControl.RoomClicked += (sender, e) =>
                {
                    selectedRoomId = room.ID;
                    layout = 2;
                    UpdateLayout();
                };
                roomsList.Children.Add(roomControl);
            }
        }

        private void NavigateToRoomDetails(object sender, RoomEventArgs e)
        {
            this.selectedRoomId = e.RoomId;
            this.layout = 2;
            UpdateLayout();
        }

        private void NavigateToRoomList(object sender, EventArgs e)
        {
            this.layout = 1;
            UpdateLayout();
        }

        private void NavigateToMyList(object sender, EventArgs e)
        {
            this.layout = 3;
            UpdateLayout();
        }
    }
}
