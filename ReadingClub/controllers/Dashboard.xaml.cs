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
        public Dashboard(User user)
        {
            InitializeComponent();
            GlobalData.LoggedInUser = user;

            LoadUserData();

            UpdateLayout();
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
                    outletGrid.Children.Add(roomList);
                    break;

                case 2:
                    var roomDetails = new RoomDetailes();
                    roomDetails.SetRoomId(selectedRoomId);
                    roomDetails.BackButtonClicked += NavigateToRoomList;
                    outletGrid.Children.Add(roomDetails);
                    break;
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
    }
}
